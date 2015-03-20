using UnityEngine;
using System.Collections;

public class PlayerKeyboardController : MonoBehaviour {

    Rigidbody2D rigidbody;
    public Vector2 max_speed = new Vector2(4, 4);

	// Use this for initialization
	void Start () {
        rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        Vector2 dir = new Vector2(0,0);
		if( Input.GetKey(KeyCode.A) )
		{
            dir.x = -1;
		}
		else if( Input.GetKey(KeyCode.D) )
        {
            dir.x = 1;
		}

		if( Input.GetKey(KeyCode.W) )
        {
            dir.y = 1;
		}
		else if( Input.GetKey(KeyCode.S) )
        {
            dir.y = -1;
        }

        rigidbody.velocity = Vector2.Scale(dir, max_speed);
	}
}
