using UnityEngine;
using System.Collections;

public class ProjectileShootWeapon : Weapon {

    public Object projectile;
    public float projectileSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	override protected void Shot(Vector2 dir)
    {
        GameObject go = ((GameObject)GameObject.Instantiate(projectile, this.transform.position, Quaternion.identity));
        Rigidbody2D rb2d = go.GetComponent<Rigidbody2D>();
        rb2d.velocity = dir.normalized * projectileSpeed;
    }

}
