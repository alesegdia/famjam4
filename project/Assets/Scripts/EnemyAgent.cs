using UnityEngine;
using System.Collections;

public class EnemyAgent : MonoBehaviour {

    public static bool aggresive = false;
    public static bool vampire = false;
    public FollowController followController = null;
    public LookAtController lookAtController = null;
    public AlwaysAttack alwaysAttack = null;
    public GameObject humanModel;
    public GameObject vampireModel;
    public Rigidbody2D pawn;
    public GameObject player;

	// Use this for initialization
	void Start () {
	}

	public void SetupAgent()
    {
        followController.enabled = aggresive;
        lookAtController.enabled = aggresive;
        alwaysAttack.enabled = aggresive;
    }

	// Update is called once per frame
	void Update () {
        followController.enabled = aggresive;
        lookAtController.enabled = aggresive;
        alwaysAttack.enabled = aggresive;
		if( Vector2.Distance(pawn.transform.position, player.transform.position) < 0.5 )
        {
            followController.enabled = false;
            Vector2 vel = pawn.velocity;
            vel *= 0.9f;
            pawn.velocity = vel;
        }
		else
        {
            followController.enabled = aggresive;
        }
	}
}
