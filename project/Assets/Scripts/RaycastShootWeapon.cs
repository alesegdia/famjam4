using UnityEngine;
using System.Collections;

public class RaycastShootWeapon : MonoBehaviour {

    public float angle;
    public float rateOfFire;
    public bool tryShotLastFrame;
    private float nextShoot = 0;
    public LayerMask layerMask;

    public float spreadAngle = 1;
    public int numBullets = 1;
    
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
    void Shot(Vector2 dir)
    {
        RaycastHit2D hit;
        for (int i = 0; i < numBullets; i++)
        {
			Quaternion angle = Quaternion.Lerp(quatSpreadAngleFrom, quatSpreadAngleTo, 1f/((float)numBullets) * ((float)i));
            tmp = dir;
            Debug.Log(angle.eulerAngles);
            tmp = angle * tmp;
			Debug.DrawRay(this.transform.position, tmp, Color.green, 5);
            hit = Physics2D.Raycast(this.transform.position, tmp, Mathf.Infinity, layerMask);
            if (hit != null && hit.collider != null && hit.collider.gameObject.tag == "Enemy")
            {
                Debug.Log(Time.time + ": hit enemy!");
            }
        }
    }

	public void TryShot(Vector2 dir)
    {
		if( Time.time > nextShoot )
		{
			nextShoot = Time.time + rateOfFire;
			Shot(dir);
			tryShotLastFrame = false;
		}

    }

}
