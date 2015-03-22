using UnityEngine;
using System.Collections;

public class AndaleController : MonoBehaviour {

    AudioSource andale;

    float nextAndale = 5f;
    float andaleRate = 10f;

	// Use this for initialization
	void Start () {
        andale = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if( Time.time > nextAndale )
        {
            nextAndale = Time.time + Random.Range(10f, 14f);
            andale.volume = Random.RandomRange(4f, 6f) / 10f;
            andale.Play();
        }
	}
}
