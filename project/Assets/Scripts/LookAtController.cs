using UnityEngine;
using System.Collections;

public class LookAtController : MonoBehaviour {

    public GameObject pawn;
    public GameObject target;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	    Vector3 delta = target.transform.position - pawn.transform.position;
        float rot_z = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;
        pawn.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

	}
}
