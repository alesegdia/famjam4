using UnityEngine;
using System.Collections;

public class PlayerShootKeyboardController : MonoBehaviour {

    ProjectileShootWeapon crossbow;
    RaycastShootWeapon shotgun;
    GameObject crosshair;

	// Use this for initialization
	void Start () {
        crossbow = GameObject.FindGameObjectWithTag("Crossbow").GetComponent<ProjectileShootWeapon>();
        shotgun = GameObject.FindGameObjectWithTag("Shotgun").GetComponent<RaycastShootWeapon>();
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
