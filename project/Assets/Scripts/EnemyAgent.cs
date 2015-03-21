using UnityEngine;
using System.Collections;

public class EnemyAgent : MonoBehaviour {

    public bool aggresive = false;
    public bool vampire = false;
    public FollowController followController = null;
    public LookAtController lookAtController = null;
    public AlwaysAttack alwaysAttack = null;
    public GameObject humanModel;
    public GameObject vampireModel;

	// Use this for initialization
	void Start () {
	}

	public void SetupAgent()
    {
        followController.enabled = aggresive;
        lookAtController.enabled = aggresive;
        alwaysAttack.enabled = aggresive;
        humanModel = GameObject.Find("humanmodel");
        vampireModel = GameObject.Find("vampiremodel");
        humanModel.SetActive(!vampire);
        vampireModel.SetActive(vampire);
    }

    void TransformIntoVampire()
    {
        vampire = true;
    }
	
	// Update is called once per frame
	void Update () {
        followController.enabled = aggresive;
        lookAtController.enabled = aggresive;
        alwaysAttack.enabled = aggresive;
        humanModel.SetActive(!vampire);
        vampireModel.SetActive(vampire);
	}
}
