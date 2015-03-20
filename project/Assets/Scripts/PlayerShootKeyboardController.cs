using UnityEngine;
using System.Collections;

public class PlayerShootKeyboardController : MonoBehaviour {

    ShootWeapon shotgun;
    GameObject crosshair;

	// Use this for initialization
	void Start () {
        shotgun = GameObject.FindGameObjectWithTag("shotgun").GetComponent<ShootWeapon>();
        crosshair = GameObject.FindGameObjectWithTag("crosshair");
	}
	
	// Update is called once per frame
	void Update () {

		if( Input.GetMouseButton(0) )
        {
            shotgun.TryShot(crosshair.transform.position - this.transform.position);
        }

	}
}
