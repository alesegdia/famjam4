using UnityEngine;
using System.Collections;

public class AngleLookAtAnimatorController : MonoBehaviour {

    public Animator animator;
    public GameObject pawn;
    public int numDirections;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		int dir = 1;
		//this.transform.localRotation = Quaternion.identity;
		Quaternion rot = pawn.transform.rotation;
		float angle = rot.eulerAngles.z;
        dir = ((int)(( 360f - angle + 180f/numDirections ) / (360f/numDirections) ));
		animator.SetInteger("Direction", dir);
	}
}
