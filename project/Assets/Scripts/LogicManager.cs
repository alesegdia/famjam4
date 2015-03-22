using UnityEngine;
using System.Collections;

public class LogicManager : MonoBehaviour {

    public FaderUI fader;

    public bool DoFadeIn = true;

    public enum LogicStates
    {
        PLAYING_CONVERSATION_PART = 0,
        CONVERSATION,
        ALTERNATIVE_ENDING
    };

    [SerializeField]
    private LogicStates currentState;

    public LogicStates CurrentState
    {
        get { return currentState; }
    }

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

    private ConversationManager conversationMgr;

    public ConversationManager ConversationMgr
    {
        get { return conversationMgr; }
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

        conversationMgr = FindObjectOfType<ConversationManager>();
        if ( conversationMgr )
        {
            conversationMgr.ConvFinishedCallback += conversationMgr_ConversationEndedCallback;
            conversationMgr.ConvStartedCallback += conversationMgr_ConvStartedCallback;
        }
        else
        {
            Debug.LogWarning("No conversation manager in the scene. Maybe we are in the action now?");
        }
	}

    void conversationMgr_ConvStartedCallback( string convName )
    {
        SetState( LogicStates.CONVERSATION );
    }

    void conversationMgr_ConversationEndedCallback(string convName)
    {
        if( currentState == LogicStates.CONVERSATION )
        {
            // [HACK] do a little wait before returning to the playing part
            StartCoroutine( waitAndSetState( 1, LogicStates.PLAYING_CONVERSATION_PART )  );
            //SetState( LogicStates.PLAYING_CONVERSATION_PART );
        }
    }

    IEnumerator waitAndSetState( int frames, LogicStates newState)
    {
        while( frames > 0 )
        {
            yield return 0;
            --frames;
        }
        SetState( newState );
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
                player.EnableAllMovementControllers( true );
                break;
            case LogicStates.CONVERSATION:
                player.EnableAllMovementControllers( false );
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

    public void LoadScene( string sceneName )
    {
        player.EnableAll(false);
        if (fader)
        {
            //Application.LoadLevel(sceneName);
            //fader.FadeOut();
            StartCoroutine( fadeOutCoroutine( sceneName ) );
        }
        else 
        {
            Application.LoadLevel(sceneName);
        }
    }

    IEnumerator fadeOutCoroutine( string sceneToLoad )
    {
        while( fader.guiTexture.color.a < 0.95 )
        {
            fader.FadeOut();
            yield return 0;
        }
        Application.LoadLevel(sceneToLoad);
    }
}
