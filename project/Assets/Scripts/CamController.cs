using UnityEngine;
using System.Collections;

public class CamController : MonoBehaviour {

    GameObject toFollow;

	// Use this for initialization
	void Start () {

        toFollow = GameObject.FindGameObjectWithTag("Player");
	
	}
	
	// Update is called once per frame
	void Update () {
        //this.transform.position = toFollow.transform.position;
        this.transform.position = new Vector3(toFollow.transform.position.x, toFollow.transform.position.y, this.transform.position.z );
	}
}
