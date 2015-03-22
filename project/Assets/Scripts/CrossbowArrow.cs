using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CrossbowArrow : MonoBehaviour {

    List<GameObject> hittedTargets = new List<GameObject>();
    public int damage = 5;
    public int maxTargetsPenetration = 3;
    public LayerMask damageLayer;

	// Use this for initialization
	void Start () {
	
	}
	
	public void OnTriggerEnter2D(Collider2D collider)
    {
		if( !hittedTargets.Contains(collider.gameObject) )
        {
            Debug.Log("HIT!");
            if (Util.CheckIfLayer(damageLayer.value, collider.gameObject.layer))
            {
                hittedTargets.Add(collider.gameObject);
                Health h = collider.gameObject.GetComponent<Health>();
                h.currentHealth -= damage;
            }
        }
    }

	// Update is called once per frame
	void Update () {
		if( hittedTargets.Count >= maxTargetsPenetration )
        {
            Destroy(this.gameObject);
        }
	}
}
