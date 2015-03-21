﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera)), ExecuteInEditMode]
public class ConversationUI : MonoBehaviour 
{
    public Rect ConversationBoxVPArea;

    public Texture conv_box;

    [SerializeField]
    private bool visible = true;

    void Start()
    {
    }

    void OnGUI()
    {
        if (visible)
        {
            // pass from vp coords to screen
            Rect screenRect = new Rect(Screen.width * ConversationBoxVPArea.x, Screen.height * (1 - ConversationBoxVPArea.y - ConversationBoxVPArea.height ), Screen.width * ConversationBoxVPArea.width, Screen.height * ConversationBoxVPArea.height);
            //Rect screenRect = ConversationBoxVPArea;
            //GUI.DrawTexture(screenRect, conv_box, ScaleMode.StretchToFill);  
            GUI.Box( screenRect, "jar" );
        }
    }

    public void ShowconversationUI( bool visible )
    {
        this.visible = visible;
    }
}