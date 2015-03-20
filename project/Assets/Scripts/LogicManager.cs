using UnityEngine;
using System.Collections;

public class LogicManager : MonoBehaviour {

    private static LogicManager instance;

    public static LogicManager Instance
    {
        get { return LogicManager.instance; }
    }

    private Player player;

    public Player Player
    {
        get { return player; }
        set { player = value; }
    }

    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy( this );
        }
    }

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDestroy()
    {
        if( this == instance )
        {
            instance = null;
        }
    }
}
