using UnityEngine;
using System.Collections;

public class AlwaysAttack : MonoBehaviour {

    Weapon weapon;
    public GameObject objective;

	// Use this for initialization
	void Start () {
        weapon = GetComponent<Weapon>();
	}
	
	// Update is called once per frame
	void Update () {
        weapon.TryShot(objective.transform.position - this.transform.position);
	}
}
