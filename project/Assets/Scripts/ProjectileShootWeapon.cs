using UnityEngine;
using System.Collections;

public class ProjectileShootWeapon : MonoBehaviour {

    public float rateOfFire;
    public Object projectile;
    public bool tryShotLastFrame;
    private float nextShoot = 0;
    public float projectileSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void ShotBullet(Vector2 dir)
    {
        GameObject go = ((GameObject)GameObject.Instantiate(projectile, this.transform.position, Quaternion.identity));
        Rigidbody2D rb2d = go.GetComponent<Rigidbody2D>();
        rb2d.velocity = dir.normalized * projectileSpeed;
    }

	public void TryShot(Vector2 dir)
    {
		if( Time.time > nextShoot )
		{
			nextShoot = Time.time + rateOfFire;
			ShotBullet(dir);
			tryShotLastFrame = false;
		}

    }
}
