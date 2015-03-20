using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    EnemyPool pool;
    public bool isDead = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (isDead) pool.NotifyDead(this);
	}
}
