using UnityEngine;
using System.Collections;

public class FollowController : MonoBehaviour {

    public string targetTag;
    public Rigidbody2D pawn;
    GameObject target;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag(targetTag);
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 vel = target.transform.position - this.transform.position;
        pawn.velocity = vel.normalized;
	}
}
