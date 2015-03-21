using UnityEngine;
using System.Collections;

public class LookAtMouse : MonoBehaviour {

    [SerializeField]
    private Transform pawn;

	// Use this for initialization
	void Start () {
	    if( !pawn )
        {
            Debug.LogError( "No pawn given!" );
            Destroy(this);
        }
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 mouse = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        mouse.z = pawn.position.z;
        //Debug.Log( mouse );
        if( ( mouse - pawn.position ).sqrMagnitude > 0.01f )
        {
            Vector3 delta = mouse - pawn.position;
            float rot_z = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;
            pawn.rotation = Quaternion.AngleAxis( rot_z - 90 , Vector3.forward);
            //pawn.LookAt(mouse, Vector3.forward);
        }
	}

    /*void OnDrawGizmos()
    {
        Gizmos.DrawLine( pawn.position, Camera.main.ScreenToWorldPoint( Input.mousePosition ) );
        Gizmos.DrawSphere( Camera.main.ScreenToWorldPoint( Input.mousePosition ), 1f );
    }*/
}
