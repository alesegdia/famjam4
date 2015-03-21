using UnityEngine;
using System.Collections;

public class Npc : MonoBehaviour 
{
    public Conversation Conv;

    private NpcBlackboard blackboard = new NpcBlackboard();

    public NpcBlackboard Blackboard
    {
        get { return blackboard; }
    }

    public void Interact()
    {
        if( Conv )
        {
            Player player = LogicManager.Instance.Player;
            // look at the player
            blackboard.prev_rotation = transform.rotation;
            Vector3 delta = player.pawn.transform.position - transform.position;
            float rot_z = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

            // start a conversation
            LogicManager.Instance.ConversationMgr.PlayConversation(Conv, Conversation_OnFinished);
        }
    }

    private void Conversation_OnFinished( string convName )
    {
        // turn to its original rotation
        transform.rotation = blackboard.prev_rotation;
    }
}


public class NpcBlackboard
{
    public Quaternion prev_rotation;
}