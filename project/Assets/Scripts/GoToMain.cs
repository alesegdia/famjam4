using UnityEngine;
using System.Collections;

public class GoToMain : MonoBehaviour {

    float time;

	// Use this for initialization
	void Start () {
        time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

		if( Time.time > time + 1 && Input.anyKey )
        {
            Application.LoadLevel("mainmenu");
        }
	
	}
}
