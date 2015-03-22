using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AlternativeEnding : MonoBehaviour {

    public Conversation[] conversations;

    private Dictionary<string, bool> conversationsTriggered = new Dictionary<string, bool>();

	// Use this for initialization
	void Start () {

        ConversationManager cmgr = FindObjectOfType<ConversationManager>();
        if( cmgr )
        {
            cmgr.ConvStartedCallback +=cmgr_ConvStartedCallback;
        }
        else
        {
            Debug.LogError( "No ConversationManager in the scene. No alternative ending" );
        }

        for (int i = 0; i < conversations.Length; i++)
        {
            conversationsTriggered[ conversations[i].name ] = false;
        }
	}

    private void cmgr_ConvStartedCallback(string convName)
    {
        if (conversationsTriggered.ContainsKey(convName))
            conversationsTriggered[convName] = true;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public int CalculateConversationsLeft()
    {
        int cDone = 0;
        foreach (bool done in conversationsTriggered.Values)
        {
            if( done )
            {
                ++cDone;
            }
        }
        return conversations.Length - cDone;
    }
}
