using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyPool : MonoBehaviour {

    public GameObject prefab;
    public int maxElements = 10;
    Queue<GameObject> pool = new Queue<GameObject>();
    public List<Transform> initialSpawns;
    GameObject player;

    public GameObject enemyRenderPrefab;
    public GameObject cloudPrefab;

	// Use this for initialization
	void Start () {

        player = GameObject.FindGameObjectWithTag("Player");
		for( int i = 0; i < maxElements; i++ )
        {
            GameObject go = (GameObject)GameObject.Instantiate(((Object)prefab));
            go.transform.position = new Vector3(1000, 1000, 1000);

            FollowController fc = go.GetComponent<FollowController>();
            fc.target = player;
            
            LookAtController lac = go.GetComponent<LookAtController>();
            lac.target = player;
            
            Enemy enemy = go.GetComponent<Enemy>();
            enemy.pool = this;
            
            AlwaysAttack aa = go.GetComponent<AlwaysAttack>();
            aa.objective = player;

            EnemyAgent agent = go.GetComponent<EnemyAgent>();
            agent.followController = fc;
            fc.enabled = false;
            agent.lookAtController = lac;
            lac.enabled = false;
            agent.alwaysAttack = aa;
            aa.enabled = false;
            EnemyAgent.vampire = false;
            EnemyAgent.aggresive = false;
            agent.player = player;
            agent.pawn = go.rigidbody2D;
            agent.SetupAgent();

            go.SetActive(false);

            GameObject render = (GameObject) GameObject.Instantiate(enemyRenderPrefab);
            AngleLookAtAnimatorController alaac = render.GetComponent<AngleLookAtAnimatorController>();
            FixedFollowController ffc = render.GetComponent<FixedFollowController>();
            ffc.toFollow = go;
            alaac.pawn = go;
            alaac.animator = render.GetComponent<Animator>();
            alaac.numDirections = 4;
            enemy.render = render;
            render.SetActive(false);

            pool.Enqueue(go);
        }

	}

	public void NotifyDead( Enemy e )
    {
        e.isDead = false;
        e.gameObject.SetActive(false);
        e.render.SetActive(false);
        pool.Enqueue(e.gameObject);
	}

    public GameObject SpawnEnemy( Vector3 position )
    {
        if (pool.Count > 0)
        {
            GameObject go = pool.Dequeue();
            go.SetActive(true);
            Enemy e = go.GetComponent<Enemy>();
            e.render.SetActive(true);
            Health h = go.GetComponent<Health>();
            h.currentHealth = h.maxHealth;
            go.transform.position = position;
            position.z = -2;
            GameObject.Instantiate(cloudPrefab, position, Quaternion.identity);
            return go;
        }
		else
        {
            return null;
        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}
