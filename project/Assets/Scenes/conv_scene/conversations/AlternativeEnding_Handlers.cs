using UnityEngine;
using System.Collections;

public class AlternativeEnding_Handlers : MonoBehaviour {

    public AlternativeEnding AlternativeEnd;

    private ConversationManager cMgr;

	// Use this for initialization
	void Start () {
        cMgr = FindObjectOfType<ConversationManager>();
        if( !cMgr )
        {
            Debug.LogError( "No conversation manager in the scene" );
        }
	}
	

    void AlternativeEndingConv_NextJump(MessageACK msg)
    {
        msg.received = true;
        int conversations_left = AlternativeEnd.CalculateConversationsLeft();
        ConversationLine currentLine = cMgr.CurrentLine;
        if ( conversations_left > 0 )
        {
            // put the next line
            currentLine.JumpOffset = 1;
            if ( conversations_left == 1 )
            {
                string message = "You need to hear 1 more person";
                cMgr.CurrentConversation.lines[2].Line = message;
            }
            else
            {
                string message = string.Format("You need to hear {0} more people", conversations_left);
                cMgr.CurrentConversation.lines[2].Line = message;
            }
        }
        else
        {
            // ending
            currentLine.JumpOffset = 3;
        }
        msg.callback();
    }

    void AlternativeEndingConv_LoadEnding(MessageACK msg)
    {
        msg.received = true;
        LogicManager.Instance.SetState(LogicManager.LogicStates.ALTERNATIVE_ENDING);
        DayTimerUI ui = FindObjectOfType<DayTimerUI>();
        ui.enabled = false;
        LogicManager.Instance.LoadScene( "alternative_ending" );
    }
}
