using UnityEngine;
using System.Collections;

public class MovementKeyboardController : MonoBehaviour {

    public GameObject pawn;
    Rigidbody2D pawnRigidbody;
    public float maxSpeed = 4;

    public bool left, right, up, down;

	// Use this for initialization
	void Start () {
        pawnRigidbody = pawn.GetComponent<Rigidbody2D>();
        left = right = up = down = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        Vector2 dir = new Vector2(0,0);

        left = Input.GetKey(KeyCode.A);
        right = Input.GetKey(KeyCode.D);
        up = Input.GetKey(KeyCode.W);
        down = Input.GetKey(KeyCode.S);

		if( left ) dir.x = -1;
		else if( right ) dir.x = 1;

		if( up ) dir.y = 1;
		else if( down ) dir.y = -1;

        pawnRigidbody.velocity = dir * maxSpeed;
	}
}
