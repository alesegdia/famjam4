using UnityEngine;
using System.Collections;

public class Conversation : ScriptableObject 
{
    //public string ConversationName;
    public ConversationLine[] lines;
}

[System.Serializable]
public class ConversationLine
{
    [SerializeField]
    private string line;

    public string Line
    {
        get { return line; }
    }

    [SerializeField]
    private Color color;

    public Color Color
    {
        get { return color; }
    }

    [SerializeField]
    private string sendMessage = null;

    public string SendMessage
    {
        get { return sendMessage; }
    }
}