using UnityEngine;
using System.Collections;

public class LockStock2SmokingBarrels_Handlers : MonoBehaviour 
{
    public Npc barman;

    public Npc jstatan;

    void LockStock2SmokingBarrels_LookJason( MessageACK msg )
    {
        msg.received = true;
        //barman.Blackboard.prev_rotation = barman.transform.rotation;
        // look at statan
        //Vector3 delta = jstatan.transform.position - barman.transform.position;
        //float rot_z = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;
        //barman.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        barman.transform.localScale = new Vector3(-barman.transform.localScale.x, barman.transform.localScale.y, barman.transform.localScale.z );
        msg.callback();
    }

    void LockStock2SmokingBarrels_LookBack(MessageACK msg)
    {
        msg.received = true;
        //barman.transform.rotation = barman.Blackboard.prev_rotation;
        barman.transform.localScale = new Vector3(-barman.transform.localScale.x, barman.transform.localScale.y, barman.transform.localScale.z);
        msg.callback();
    }
}
