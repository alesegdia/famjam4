using UnityEngine;
using System.Collections;

public class LogicManager : MonoBehaviour {

    public enum LogicStates
    {
        PLAYING_CONVERSATION_PART = 0,
        CONVERSATION,
    };

    private LogicStates currentState;

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
        if( !player )
        {
            Debug.LogError( "No player in the scene" );
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetState( LogicStates newState )
    {
        currentState = newState;
        // make some changes according to the new state
        switch( currentState )
        {
            case LogicStates.PLAYING_CONVERSATION_PART:
                // enable some controls
                break;
            case LogicStates.CONVERSATION:
                // show the UI
                break;
        }
    }

    void OnDestroy()
    {
        if( this == instance )
        {
            instance = null;
        }
    }
}
