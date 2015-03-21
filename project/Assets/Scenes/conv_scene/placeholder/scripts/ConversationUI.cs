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

    void Start()
    {
        if( skin == null )
        {
            skin = new GUISkin();
        }
    }

    void OnGUI()
    {
        if (visible)
        {
            // pass from vp coords to screen
            Rect screenRect = new Rect(Screen.width * ConversationBoxVPArea.x, Screen.height * (1 - ConversationBoxVPArea.y - ConversationBoxVPArea.height ), Screen.width * ConversationBoxVPArea.width, Screen.height * ConversationBoxVPArea.height);
            //Rect screenRect = ConversationBoxVPArea;
            //GUI.DrawTexture(screenRect, conv_box, ScaleMode.StretchToFill); 
            GUI.Box( screenRect, "" );
            screenRect = new Rect(Screen.width * ConversationLabelVPArea.x, Screen.height * (1 - ConversationLabelVPArea.y - ConversationLabelVPArea.height), Screen.width * ConversationLabelVPArea.width, Screen.height * ConversationLabelVPArea.height);
            GUI.Label( screenRect, text, skin.label );
        }
    }

    public void ShowConversationUI( bool visible )
    {
        this.visible = visible;
    }

    public void SetText( string text, Color color )
    {
        skin.label.normal.textColor = color;
        skin.label.hover.textColor = color;
        skin.label.active.textColor = color;
        this.text = text;
    }
}
