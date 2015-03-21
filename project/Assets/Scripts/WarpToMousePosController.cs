using UnityEngine;
using System.Collections;

public class WarpToMousePosController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 mousepos = Input.mousePosition;
        Vector2 worldmousepos = Camera.main.ScreenToWorldPoint(mousepos);
        this.transform.position = worldmousepos;
    }
}
