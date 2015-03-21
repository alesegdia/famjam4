using UnityEngine;
using System.Collections;

public class ConversationManager : MonoBehaviour 
{
    public ConversationUI UI;

    public delegate void ConversationCallback( string convName );

    public delegate void ConversationLineCallback( );

    public event ConversationCallback ConvFinishedCallback;
    public event ConversationCallback ConvStartedCallback;

    private ConversationCallback callback;

    public enum ConversationLineState
    {
        SHOWING,
        WAITING_FOR_CLICK,
        WAITING_FOR_HANDLER_TO_COMPLETE,
        NONE
    };

    private ConversationLineState currentLineState;

    private Conversation currentConversation;
    private int currentIndex;

	// Use this for initialization
	void Start () 
    {
        currentLineState = ConversationLineState.NONE;
	}
	
	// Update is called once per frame
	void Update () 
    {
	    switch( currentLineState )
        {
            case ConversationLineState.SHOWING:
                UI.SetText( currentConversation.lines[currentIndex].Line, currentConversation.lines[currentIndex].Color );
                currentLineState = ConversationLineState.WAITING_FOR_CLICK;
                break;
            case ConversationLineState.WAITING_FOR_CLICK:
                if( Input.GetMouseButtonDown( 0 ) )
                {
                    if (!string.IsNullOrEmpty(currentConversation.lines[currentIndex].SendMessage))
                    {
                        MessageACK ack = new MessageACK();
                        ack.received = false;
                        ack.callback = ConversationLineEvent_Completed;
                        string methodName = string.Format("{0}_{1}", currentConversation.name, currentConversation.lines[currentIndex].SendMessage);
                        BroadcastMessage( methodName, ack );
                        if ( ack.received )
                        {
                            // little fix for instan events
                            if( currentLineState == ConversationLineState.WAITING_FOR_CLICK )
                            {
                                currentLineState = ConversationLineState.WAITING_FOR_HANDLER_TO_COMPLETE;
                            }
                        }
                        else
                        {
                            Debug.Log("No entity received the message jump go to the next line");
                            if (nextLine())
                            {
                                currentLineState = ConversationLineState.SHOWING;
                            }
                            else
                            {
                                EndConversation();
                            }
                        }
                    }
                    else
                    {
                        if ( nextLine( ) )
                        {
                            currentLineState = ConversationLineState.SHOWING;
                        }
                        else
                        {
                            EndConversation();
                        }
                    }
                }
                break;
        }
	}

    private bool nextLine()
    {
        if (++currentIndex < currentConversation.lines.Length)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void PlayConversation( Conversation conv, ConversationCallback callback )
    {
        // clean the previous text
        UI.SetText( "", Color.white );
        this.callback = callback;
        ConvFinishedCallback += this.callback;
        currentConversation = conv;
        currentIndex = 0;
        currentLineState = ConversationLineState.SHOWING;
        // show the ui
        UI.ShowConversationUI( true );

        if (ConvStartedCallback != null)
        {
            ConvStartedCallback(conv.name);
        }
    }

    private void EndConversation()
    {
        if ( ConvFinishedCallback != null )
        {
            ConvFinishedCallback( currentConversation.name );
        }
        ConvFinishedCallback -= callback;
        currentLineState = ConversationLineState.NONE;
        currentIndex = 0;
        currentConversation = null;
        UI.ShowConversationUI( false );
    }

    private void ConversationLineEvent_Completed()
    {
        if (nextLine())
        {
            currentLineState = ConversationLineState.SHOWING;
        }
        else
        {
            EndConversation();
        }
    }
}

public class MessageACK
{
    public bool received;
    public ConversationManager.ConversationLineCallback callback;
}