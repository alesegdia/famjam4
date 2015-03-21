using UnityEngine;
using System.Collections;

public class EnemyAgent : MonoBehaviour {

    public bool aggresive = false;
    public bool vampire = false;
    public FollowController followController;
    public LookAtController lookAtController;
    public AlwaysAttack alwaysAttack;
    public GameObject humanModel;
    public GameObject vampireModel;

	// Use this for initialization
	void Start () {
        followController.enabled = aggresive;
        lookAtController.enabled = aggresive;
        alwaysAttack.enabled = aggresive;

        GameObject humanGO = ((GameObject)GameObject.Instantiate(humanModel, Vector3.zero, Quaternion.identity));
        humanGO.transform.parent = this.transform;
		humanGO.transform.localPosition = Vector3.zero;
        humanModel = humanGO;
        GameObject vampireGO = ((GameObject)GameObject.Instantiate(vampireModel, Vector3.zero, Quaternion.identity));
        vampireGO.transform.parent = this.transform;
		vampireGO.transform.localPosition = Vector3.zero;
        vampireModel = vampireGO;
	}

    void TransformIntoVampire()
    {
    }
	
	// Update is called once per frame
	void Update () {
        followController.enabled = aggresive;
        lookAtController.enabled = aggresive;
        alwaysAttack.enabled = aggresive;
        humanModel.SetActive(vampire);
        vampireModel.SetActive(vampire);
	}
}
