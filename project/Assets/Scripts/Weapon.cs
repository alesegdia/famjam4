using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    public float rateOfFire;
    public bool tryShotLastFrame;
    private float nextShoot = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool TryShot(Vector2 dir)
    {
		if( Time.time > nextShoot )
		{
			nextShoot = Time.time + rateOfFire;
			Shot(dir);
			tryShotLastFrame = false;
            return true;
		}
        return false;
    }

	protected virtual void Shot(Vector2 dir) {
		/** OVERRIDE **/
    }

}
