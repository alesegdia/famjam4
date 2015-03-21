using UnityEngine;
using System.Collections;

public class FollowController : MonoBehaviour {

    public GameObject target;
    public Rigidbody2D pawn;
    public float maxSpeed = 3;
    public float followForce = 0.3f;

    // Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 dir = target.transform.position - pawn.transform.position;
		dir.Normalize();
        Vector2 vel = pawn.velocity + dir * followForce;
        if (Mathf.Abs(vel.x) > maxSpeed) vel.x = maxSpeed * Mathf.Sign(vel.x);
        if (Mathf.Abs(vel.y) > maxSpeed) vel.y = maxSpeed * Mathf.Sign(vel.y);
        pawn.velocity = vel;
	}
}
