using UnityEngine;
using System.Collections;

public class UpperBodyLookAtMouse : MonoBehaviour {

    [SerializeField]
    private Animator animator;

	// Use this for initialization
	void Start () {
	    if( !animator )
        {
            Debug.LogError( "No pawn given!" );
            Destroy(this);
        }
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 mouse = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        mouse.z = animator.transform.position.z;
        //Debug.Log( mouse );
        if ((mouse - animator.transform.position).sqrMagnitude > 0.01f)
        {
            Vector3 delta = mouse - animator.transform.position;
            float rot_z = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;
            Quaternion rot = Quaternion.AngleAxis(rot_z - 90, Vector3.forward);
            float angle = rot.eulerAngles.z;
            int dir = ((int)((360f - angle + 180f / 8) / (360f / 8)));
            animator.SetInteger("Direction", dir);
        }
	}

    /*void OnDrawGizmos()
    {
        Gizmos.DrawLine( pawn.position, Camera.main.ScreenToWorldPoint( Input.mousePosition ) );
        Gizmos.DrawSphere( Camera.main.ScreenToWorldPoint( Input.mousePosition ), 1f );
    }*/
}
