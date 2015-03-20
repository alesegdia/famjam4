using UnityEngine;
using System.Collections;

public class CamController : MonoBehaviour {

    GameObject toFollow;
    Vector3 pos = new Vector3(0, 0);

	// Use this for initialization
	void Start () {

        toFollow = GameObject.FindGameObjectWithTag("Player");
	
	}
	
	// Update is called once per frame
	void Update () {
        pos.x = toFollow.transform.position.x;
        pos.y = toFollow.transform.position.y;
		pos.z = this.transform.position.z;
        this.transform.position = pos;
	}
}
