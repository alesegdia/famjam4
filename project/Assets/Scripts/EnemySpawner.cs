using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	EnemyPool enemyPool;
    public float rateOfSpawn = 1f;
    float nextSpawn = 0f;

	// Use this for initialization
	void Start () {
        enemyPool = GameObject.FindObjectOfType<EnemyPool>();
	}
	
	// Update is called once per frame
	void Update () {
		if( Time.time > nextSpawn )
        {
            enemyPool.SpawnEnemy( this.transform.position );
            nextSpawn = Time.time + rateOfSpawn;
        }
	}
}
