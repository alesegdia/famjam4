using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RaycastMeleeWeapon : Weapon {

    public float angle;
    public LayerMask collisionLayer;
    public LayerMask damageLayer;

    public float spreadAngle = 1;
    public int numHits = 1;

    public float rayLimit = Mathf.Infinity;

    public int damage = 1;
    
    float anglePerBullet;
    Quaternion quatSpreadAngleFrom;
    Quaternion quatSpreadAngleTo;

	// Use this for initialization
	void Start () {
        anglePerBullet = spreadAngle / numHits;
        spreadAngle /= 2;
        quatSpreadAngleFrom = Quaternion.Euler(new Vector3(0, 0, -spreadAngle));
        quatSpreadAngleTo = Quaternion.Euler(new Vector3(0, 0, spreadAngle));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    Vector3 tmp = new Vector3();
	List<Collider2D> alreadyHit = new List<Collider2D>();
    override protected void Shot(Vector2 dir)
    {
        RaycastHit2D hit;
        alreadyHit.Clear();
        for (int i = 0; i < numHits; i++)
        {
			Quaternion angle = Quaternion.Lerp(quatSpreadAngleFrom, quatSpreadAngleTo, 1f/((float)numHits) * ((float)i));
            tmp = dir;
            tmp = angle * tmp;
			Debug.DrawRay(this.transform.position, tmp, Color.green, 5);
            hit = Physics2D.Raycast(this.transform.position, tmp, rayLimit, collisionLayer);
            if (hit != null && hit.collider != null && Util.CheckIfLayer(damageLayer.value, hit.collider.gameObject.layer) && !alreadyHit.Contains(hit.collider) )
            {
				alreadyHit.Add(hit.collider);
                Debug.Log(Time.time + ": hit enemy!");
                hit.collider.gameObject.GetComponent<Health>().currentHealth -= damage;
            }
        }
    }
}
