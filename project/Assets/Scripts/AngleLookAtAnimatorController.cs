using UnityEngine;
using System.Collections;

public class AngleLookAtAnimatorController : MonoBehaviour {

    public Animator animator;
    public GameObject pawn;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		int dir = 1;
		//this.transform.localRotation = Quaternion.identity;
		Quaternion rot = pawn.transform.rotation;
		float angle = rot.eulerAngles.z;
        dir = ((int)((360f-angle+23f) / 45f));
		animator.SetInteger("Direction", dir);
	}
}
