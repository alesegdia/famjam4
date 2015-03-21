using UnityEngine;
using UnityEditor;

public class CreateConversation
{
    [MenuItem("Assets/Create/Conversation")]
    public static void CreateAsset()
    {
        ScriptableObjectUtility.CreateAsset<Conversation>();
    }
}
