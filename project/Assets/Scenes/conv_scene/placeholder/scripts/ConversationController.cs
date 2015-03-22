using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ConversationController : MonoBehaviour 
{
    private Dictionary<string, Npc> nearNpcs = new Dictionary<string,Npc>();

    private Player player;

    private bool Interact
    {
        get { return  LogicManager.Instance.CurrentState == LogicManager.LogicStates.PLAYING_CONVERSATION_PART && Input.GetMouseButtonDown(0); }
    }

    void Start()
    {
        player = FindObjectOfType<Player>();
        if( !player )
        {
            Debug.LogError( "No player in the scene" );
            Destroy( this );
        }
    }

    void Update()
    {
        if( Interact )
        {
            // get the one we ar elooking at
            KeyValuePair<Npc,float> nearest = new KeyValuePair<Npc,float>( null, float.MaxValue );
            Vector3 dir = player.GetLookDirection();
            foreach (var npc in nearNpcs.Values)
            {
                Vector3 dist = npc.transform.position - player.pawn.transform.position;
                RaycastHit2D rh = Physics2D.Raycast( player.pawn.transform.position, dir, dist.magnitude, LayerMask.GetMask( "NPC" ) );
                if( rh.collider == npc.collider2D && rh.distance < nearest.Value )
                {
                    nearest = new KeyValuePair<Npc, float>( npc, rh.distance );
                }
            }

            if( nearest.Key )
            {
                    nearest.Key.Interact();
            }
        }
    }

    void OnTriggerEnter2D( Collider2D other )
    {
        if( !nearNpcs.ContainsKey( other.name ) )
        {
            Npc npc = other.GetComponent<Npc>();
            if( npc )
            {
                nearNpcs.Add( npc.name, npc );
            }
        }
    }

    void OnTriggerExit2D( Collider2D other )
    {
        if( nearNpcs.ContainsKey( other.name ) )
        {
            nearNpcs.Remove( other.name );
        }
    }
}
