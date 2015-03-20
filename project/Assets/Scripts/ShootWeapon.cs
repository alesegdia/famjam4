using UnityEngine;
using System.Collections;

public class ShootWeapon : MonoBehaviour {

    public float rateOfFire;
    public Object projectile;
    public bool tryShotLastFrame;
    private float nextShoot = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if( tryShotLastFrame )
        {
			if( Time.time > nextShoot )
            {
                nextShoot = Time.time + rateOfFire;
                ShotBullet();
                tryShotLastFrame = false;
            }
        }
	}

	void ShotBullet()
    {
        Object go = GameObject.Instantiate(projectile, this.transform.position, Quaternion.identity);
    }
}
