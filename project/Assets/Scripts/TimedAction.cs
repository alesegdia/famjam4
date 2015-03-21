using UnityEngine;
using System.Collections;

public class TimedAction : MonoBehaviour {

    public float timeToTrigger = 0;

	// Use this for initialization
	void Start () {
        timeToTrigger += Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if( Time.time > timeToTrigger )
        {
            Trigger();
        }
	}

	public virtual void Trigger()
    {

    }
}
