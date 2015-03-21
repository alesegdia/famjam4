using UnityEngine;
using System.Collections;

public class PlayerShootKeyboardController : MonoBehaviour {

    ProjectileShootWeapon crossbow;
    RaycastShootWeapon shotgun;
    GameObject crosshair;
    Weapon weaponInUse;

	// Use this for initialization
	void Start () {
        crossbow = GameObject.FindGameObjectWithTag("Crossbow").GetComponent<ProjectileShootWeapon>();
        shotgun = GameObject.FindGameObjectWithTag("Shotgun").GetComponent<RaycastShootWeapon>();
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
