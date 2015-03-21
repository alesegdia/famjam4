using UnityEngine;
using System.Collections;

public class FootAnimationController : MonoBehaviour {

    public Animator animator;
    public MovementKeyboardController keyboardController;

	// Use this for initialization
	void Start () {
	
	}

	int dir = 0;
	
	// Update is called once per frame
	void Update () {
		if( keyboardController.up && keyboardController.left ) dir = 7;
		else if( keyboardController.up && keyboardController.right ) dir = 1;
		else if( keyboardController.down && keyboardController.left ) dir = 5;
		else if( keyboardController.down && keyboardController.right ) dir = 3;
		else if( keyboardController.up ) dir = 0;
		else if( keyboardController.down ) dir = 4;
		else if( keyboardController.left ) dir = 6;
		else if( keyboardController.right ) dir = 2;
        animator.SetInteger("Direction", dir);
	}
}
