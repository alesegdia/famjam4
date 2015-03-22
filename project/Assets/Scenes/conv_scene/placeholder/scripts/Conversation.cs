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
    public ConversationLine()
    {
        JumpOffset = 1;
    }

    [SerializeField]
    private string line;

    public string Line
    {
        get { return line; }
        set { line = value; }
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

    [SerializeField]
    public int JumpOffset = 1;
}