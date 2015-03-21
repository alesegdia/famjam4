using UnityEngine;
using System.Collections;

public class ConversationTest_Handlers : MonoBehaviour 
{
    public Npc NpcThatShouldLook;

    //private MessageACK messageToken;

    public void ConversationTest_LookPlayer( MessageACK messageToken )
    {
        messageToken.received = true;
        //this.messageToken = messageToken;
        NpcThatShouldLook.Blackboard.prev_rotation = NpcThatShouldLook.transform.rotation;
        Player player = LogicManager.Instance.Player;
        // look at the player
        Vector3 delta = player.pawn.transform.position - NpcThatShouldLook.transform.position;
        float rot_z = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;
        NpcThatShouldLook.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        messageToken.callback();
    }


    public void ConversationTest_TurnBack(MessageACK messageToken)
    {
        messageToken.received = true;
        //this.messageToken = messageToken;
        NpcThatShouldLook.transform.rotation = NpcThatShouldLook.Blackboard.prev_rotation;
        messageToken.callback();
    }
}
