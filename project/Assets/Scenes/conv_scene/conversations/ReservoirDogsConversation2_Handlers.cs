using UnityEngine;
using System.Collections;

public class ReservoirDogsConversation2_Handlers : MonoBehaviour 
{
    public Npc MrBlue;

    private MessageACK messageToken;

    public void ReservoirDogsConversation2_LookPlayerAndBack(MessageACK messageToken)
    {
        this.messageToken = messageToken;
        this.messageToken.received = true;
        //StartCoroutine( lookCoroutine() );
        Vector3 scale = MrBlue.transform.localScale;
        scale.x *= -1;
        MrBlue.transform.localScale = scale;
        this.messageToken.callback();
    }

    private IEnumerator lookCoroutine()
    {
        //MrBrown.Blackboard.prev_rotation = MrBrown.transform.rotation;
        //Player player = LogicManager.Instance.Player;
        // look at the player
        //Vector3 delta = player.pawn.transform.position - MrBrown.transform.position;
        //float rot_z = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;
        //MrBrown.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        Vector3 scale = MrBlue.transform.localScale;
        scale.x *= -1;
        MrBlue.transform.localScale = scale;
        yield return new WaitForSeconds( 1 );
        scale.x *= -1;
        //MrBrown.transform.rotation = MrBrown.Blackboard.prev_rotation;
        MrBlue.transform.localScale = scale;
        messageToken.callback();
    }
}
