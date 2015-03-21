using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera)), ExecuteInEditMode]
public class ConversationUI : MonoBehaviour 
{
    public Rect ConversationBoxVPArea;

    public Rect ConversationLabelVPArea;

    public Texture conv_box;

    public GUISkin skin;

    [SerializeField]
    private bool visible = true;

    [SerializeField]
    private string text;
    private Color color;

    private GUIStyle style;

    void Start()
    {
        if( skin == null )
        {
            skin = new GUISkin();
        }
        style = new GUIStyle(skin.label);
    }

    void OnGUI()
    {
        if (visible)
        {
            // pass from vp coords to screen
            Rect screenRect = new Rect(Screen.width * ConversationBoxVPArea.x, Screen.height * (1 - ConversationBoxVPArea.y - ConversationBoxVPArea.height ), Screen.width * ConversationBoxVPArea.width, Screen.height * ConversationBoxVPArea.height);
            //Rect screenRect = ConversationBoxVPArea;
            //GUI.DrawTexture(screenRect, conv_box, ScaleMode.StretchToFill); 
            GUI.Box( screenRect, "", skin.box );
            screenRect = new Rect(Screen.width * ConversationLabelVPArea.x, Screen.height * (1 - ConversationLabelVPArea.y - ConversationLabelVPArea.height), Screen.width * ConversationLabelVPArea.width, Screen.height * ConversationLabelVPArea.height);
            GUI.Label(screenRect, text, style);
        }
    }

    public void ShowConversationUI( bool visible )
    {
        this.visible = visible;
    }

    public void SetText( string text, Color color )
    {
        style.normal.textColor = color;
        style.hover.textColor = color;
        style.active.textColor = color;
        this.text = text;
    }
}
