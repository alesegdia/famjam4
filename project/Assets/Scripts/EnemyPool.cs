using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyPool : MonoBehaviour {

    public GameObject prefab;
    public int maxElements = 30;
    Queue<GameObject> pool = new Queue<GameObject>();
    public List<Transform> initialSpawns;

	// Use this for initialization
	void Start () {

		for( int i = 0; i < maxElements; i++ )
        {
            GameObject go = (GameObject)GameObject.Instantiate(((Object)prefab));
            FollowController fc = go.GetComponent<FollowController>();
            fc.targetTag = "Player";
            LookAtController lac = go.GetComponent<LookAtController>();
            lac.target = GameObject.FindGameObjectWithTag("Player");
            Enemy enemy = go.GetComponent<Enemy>();
            enemy.pool = this;
            go.SetActive(false);
            pool.Enqueue(go);
        }

		foreach( Transform t in initialSpawns )
        {
            SpawnEnemy(t.transform.position);
        }
	}

	public void NotifyDead( Enemy e )
    {
        e.isDead = false;
        e.gameObject.SetActive(false);
        pool.Enqueue(e.gameObject);
        Debug.Log("DEAD! " + pool.Count);
	}

    public GameObject SpawnEnemy( Vector3 position )
    {
        if (pool.Count > 0)
        {
            GameObject go = pool.Dequeue();
            go.SetActive(true);
            Health h = go.GetComponent<Health>();
            h.currentHealth = h.maxHealth;
            go.transform.position = position;
			Debug.Log("SPAWN! " + pool.Count);
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
