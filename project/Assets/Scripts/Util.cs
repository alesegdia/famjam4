using UnityEngine;
using System.Collections;

public class Util : MonoBehaviour {

	public static bool CheckIfLayer( int mask, int layer )
    {
        return (mask & 1 << layer) == 1 << layer;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
