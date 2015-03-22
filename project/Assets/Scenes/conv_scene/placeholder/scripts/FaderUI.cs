using UnityEngine;
using System.Collections;

[RequireComponent( typeof(GUITexture) )]
public class FaderUI : MonoBehaviour {
    public float fadeSpeed = 1.5f;          // Speed that the screen fades to and from black.


    void Awake()
    {
        // Set the texture so that it is the the size of the screen and covers it.
        guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
    }

    public void FadeIn()
    {
        // Lerp the colour of the texture between itself and transparent.
        guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, fadeSpeed * Time.deltaTime);
    }


    public void FadeOut()
    {
        // Lerp the colour of the texture between itself and black.
        guiTexture.color = Color.Lerp(guiTexture.color, Color.black, fadeSpeed * Time.deltaTime);
    }
}
