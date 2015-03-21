using UnityEngine;
using System.Collections;

public class ReservoirDogsConversation_Handlers : MonoBehaviour 
{
    public Npc MrBrown;

    private MessageACK messageToken;

    public void ReservoirDogsConversation_LookPlayerAndBack(MessageACK messageToken)
    {
        this.messageToken = messageToken;
        this.messageToken.received = true;
        StartCoroutine( lookAndBackCoroutine() );
    }

    private IEnumerator lookAndBackCoroutine()
    {
        MrBrown.Blackboard.prev_rotation = MrBrown.transform.rotation;
        Player player = LogicManager.Instance.Player;
        // look at the player
        Vector3 delta = player.pawn.transform.position - MrBrown.transform.position;
        float rot_z = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;
        MrBrown.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        yield return new WaitForSeconds( 1 );
        MrBrown.transform.rotation = MrBrown.Blackboard.prev_rotation;
        messageToken.callback();
    }
}
