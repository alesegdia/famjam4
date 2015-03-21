using UnityEngine;
using System.Collections;

public class ConversationManager : MonoBehaviour 
{
    public ConversationUI UI;

    public delegate void ConversationCallback( string convName );

    public delegate void ConversationLineCallback( );

    public event ConversationCallback ConvCallback;

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
                if( Input.GetMouseButton( 0 ) )
                {
                    if (!string.IsNullOrEmpty(currentConversation.lines[currentIndex].SendMessage))
                    {
                        MessageACK ack;
                        ack.received = false;
                        ack.callback = ConversationLineEvent_Completed;
                        BroadcastMessage(string.Format("{0}_{1}", currentConversation.ConversationName, currentConversation.lines[currentIndex].SendMessage), ack);
                        if (ack.received)
                        {
                            currentLineState = ConversationLineState.WAITING_FOR_HANDLER_TO_COMPLETE;
                        }
                        else
                        {
                            Debug.Log("No entity received the message jump go to the next line");
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
        currentConversation = conv;
        currentIndex = 0;
        currentLineState = ConversationLineState.SHOWING;
        // show the ui
        UI.ShowConversationUI( true );
    }

    private void EndConversation()
    {
        if ( ConvCallback != null )
        {
            ConvCallback( currentConversation.ConversationName );
        }
        ConvCallback -= callback;
        currentLineState = ConversationLineState.NONE;
        currentIndex = 0;
        currentConversation = null;
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

public struct MessageACK
{
    public bool received;
    public ConversationManager.ConversationLineCallback callback;
}