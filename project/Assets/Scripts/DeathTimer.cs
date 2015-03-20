using UnityEngine;
using System.Collections;

public class DeathTimer : MonoBehaviour {

    public float secondsAlive;
    float timeToDie;

	// Use this for initialization
	void Start () {
        timeToDie = Time.time + secondsAlive;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > timeToDie) GameObject.Destroy(this.gameObject);
	}
}
