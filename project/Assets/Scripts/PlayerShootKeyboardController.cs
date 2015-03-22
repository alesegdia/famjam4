using UnityEngine;
using System.Collections;

public class PlayerShootKeyboardController : MonoBehaviour {

    GameObject crosshair;
    Weapon weaponInUse;
    ShakeFollowCam shakeCam;

	// Use this for initialization
	void Start () {
        crosshair = GameObject.FindGameObjectWithTag("Crosshair");
        weaponInUse = GameObject.FindObjectOfType<Player>().WeaponInUse;
        shakeCam = GameObject.FindObjectOfType<ShakeFollowCam>();
	}
	
	// Update is called once per frame
	void Update () {

		if( Input.GetMouseButtonDown(0) )
        {
           if( weaponInUse.TryShot(crosshair.transform.position - this.transform.position) )
           {
               shakeCam.AddShake(0.1f);
           }
        }

	}
}
