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
            Debug.Log("asd");
            SpawnEnemy(t.transform.position);
        }
	}

	public void NotifyDead( Enemy e )
    {
        e.isDead = false;
        e.gameObject.SetActive(false);
        pool.Enqueue(e.gameObject);
	}

    GameObject SpawnEnemy( Vector3 position )
    {
        GameObject go = pool.Dequeue();
        go.SetActive(true);
        go.transform.position = position;
        return go;
    }

	// Update is called once per frame
	void Update () {
	
	}
}
