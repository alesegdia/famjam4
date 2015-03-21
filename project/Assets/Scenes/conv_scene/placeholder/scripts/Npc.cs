using UnityEngine;
using System.Collections;

public class Npc : MonoBehaviour 
{
    public void Interact()
    {
        Player player = LogicManager.Instance.Player;
        // disable controls
        //player.DisableAllControllers();

        // look at the player
        Vector3 delta = player.pawn.transform.position - transform.position;
        float rot_z = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

        // set the conversation mode

        // start a conversation
    }
}
