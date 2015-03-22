using UnityEngine;
using System.Collections;

public class ShakeFollowCam : MonoBehaviour {

    public Rigidbody2D follow;
    public float shake = 0f;
    public float shakeDecay = 0.9f;
    public float maxShake = 2f;

	// Use this for initialization
	void Start () {
	
	}

    Vector3 pos = new Vector3();
    Vector3 tmp = new Vector3();
	// Update is called once per frame
	void Update () {
        pos = follow.transform.position;
        tmp.x = Random.RandomRange(-2f, 2f) * shake;
        tmp.y = Random.RandomRange(-2f, 2f) * shake;
        tmp.z = -10;
        pos += tmp;
        this.transform.position = pos;
	}

	void FixedUpdate()
    {
        shake *= shakeDecay;
    }

	public void AddShake(float shakeamount)
    {
        this.shake += shakeamount;
        if (this.shake > this.maxShake)
            this.shake = this.maxShake;
    }
}
