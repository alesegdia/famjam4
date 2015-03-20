using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public EnemyPool pool;
    public bool isDead = false;
    Health health;

	// Use this for initialization
	void Start () {
        health = GetComponent<Health>();
	}
	
	// Update is called once per frame
	void Update () {
		if( health.currentHealth <= 0 )
        {
            pool.NotifyDead(this);
        }
	}
}
