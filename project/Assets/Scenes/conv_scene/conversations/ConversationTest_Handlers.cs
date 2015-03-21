using UnityEngine;
using System.Collections;

public class ConversationTest_Handlers : MonoBehaviour 
{
    public Npc NpcThatShouldLook;

    //private MessageACK messageToken;

    void ConversationTest_LookPlayer( MessageACK messageToken )
    {
        messageToken.received = true;
        //this.messageToken = messageToken;
        NpcThatShouldLook.Blackboard.prev_rotation = NpcThatShouldLook.transform.rotation;
        messageToken.callback();
    }


    void ConversationTest_TurnBack(MessageACK messageToken)
    {
        messageToken.received = true;
        //this.messageToken = messageToken;
        NpcThatShouldLook.transform.rotation = NpcThatShouldLook.Blackboard.prev_rotation;
    }
}
