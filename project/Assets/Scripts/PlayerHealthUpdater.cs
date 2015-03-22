using UnityEngine;
using System.Collections;

public class PlayerHealthUpdater : MonoBehaviour {

    public Health playerHealth;
    public Texture2D bgImage;
    public Texture2D fgImage;
    public float healthBarLength;

	// Use this for initialization
	void Start () {
        healthBarLength = Screen.width / 2f;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
	}
	
	void OnGUI()
    {
        GUI.BeginGroup(new Rect(0, 0, 100, 32));
        GUI.Box(new Rect(0, 0, 100, 32), bgImage);
        GUI.BeginGroup(new Rect(0, 0, playerHealth.currentHealth / playerHealth.maxHealth * healthBarLength, 32));
        GUI.Box(new Rect(0, 0, 100, 32), fgImage);
        GUI.EndGroup();
        GUI.EndGroup();
    }

	// Update is called once per frame
	void Update () {
		
	}
}
