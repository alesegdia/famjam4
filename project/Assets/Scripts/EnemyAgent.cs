using UnityEngine;
using System.Collections;

public class EnemyAgent : MonoBehaviour {

    public bool aggresive = false;
    public FollowController followController;
    public LookAtController lookAtController;
    public AlwaysAttack alwaysAttack;

	// Use this for initialization
	void Start () {
        followController.enabled = aggresive;
        lookAtController.enabled = aggresive;
        alwaysAttack.enabled = aggresive;
	}
	
	// Update is called once per frame
	void Update () {
        followController.enabled = aggresive;
        lookAtController.enabled = aggresive;
        alwaysAttack.enabled = aggresive;
	}
}
