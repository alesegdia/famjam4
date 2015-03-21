using UnityEngine;
using System.Collections;

public class PlayerShootKeyboardController : MonoBehaviour {

    GameObject crosshair;
    Weapon weaponInUse;

	// Use this for initialization
	void Start () {
        crosshair = GameObject.FindGameObjectWithTag("Crosshair");
        weaponInUse = GameObject.FindObjectOfType<Player>().WeaponInUse;
	}
	
	// Update is called once per frame
	void Update () {

		if( Input.GetMouseButton(0) )
        {
            weaponInUse.TryShot(crosshair.transform.position - this.transform.position);
        }

	}
}
