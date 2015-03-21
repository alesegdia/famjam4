﻿using UnityEngine;
using System.Collections;

public class RaycastShootWeapon : Weapon {

    public float angle;
    public LayerMask collisionLayer;
    public LayerMask damageLayer;

    public float spreadAngle = 1;
    public int numBullets = 1;

    public float rayLimit = Mathf.Infinity;

    public GameObject spark;
    
    float anglePerBullet;
    Quaternion quatSpreadAngleFrom;
    Quaternion quatSpreadAngleTo;

	// Use this for initialization
	void Start () {
        anglePerBullet = spreadAngle / numBullets;
        spreadAngle /= 2;
        quatSpreadAngleFrom = Quaternion.Euler(new Vector3(0, 0, -spreadAngle));
        quatSpreadAngleTo = Quaternion.Euler(new Vector3(0, 0, spreadAngle));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    Vector3 tmp = new Vector3();
    override protected void Shot(Vector2 dir)
    {
        RaycastHit2D hit;
        for (int i = 0; i < numBullets; i++)
        {
			Quaternion angle = Quaternion.Lerp(quatSpreadAngleFrom, quatSpreadAngleTo, 1f/((float)numBullets) * ((float)i));
            tmp = dir;
            tmp = angle * tmp;
			Debug.DrawRay(this.transform.position, tmp, Color.green, 5);
            hit = Physics2D.Raycast(this.transform.position, tmp, rayLimit, collisionLayer);
            if (hit != null && hit.collider != null)
            {
                GameObject.Instantiate(spark, hit.centroid, Quaternion.identity);
                if (Util.CheckIfLayer(damageLayer.value, hit.collider.gameObject.layer))
                {
                    hit.collider.gameObject.GetComponent<Health>().currentHealth--;
                }
            }
        }
    }
}
