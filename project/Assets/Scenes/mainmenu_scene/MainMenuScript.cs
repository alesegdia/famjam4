using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

    public SpriteRenderer StartScreen;

    public SpriteRenderer HowToPlay;

    public FaderUI fader;

	// Use this for initialization
	IEnumerator Start () {
	    // wait for input
        while( !Input.anyKeyDown )
        {
            yield return 0;
        }

        // do a fade
        yield return StartCoroutine( fadeOut() );



        StartScreen.enabled = false;
        HowToPlay.enabled = true;
        yield return StartCoroutine( fadeIn() );
        // wait for input
        while (!Input.anyKeyDown)
        {
            yield return 0;
        }

        // do a fade
        yield return StartCoroutine(fadeOut());

        Application.LoadLevel( "conv_scene" );
	}

    IEnumerator fadeOut()
    {
        while (fader.guiTexture.color.a < 0.95)
        {
            fader.FadeOut();
            yield return 0;
        }
    }

    IEnumerator fadeIn()
    {
        while (fader.guiTexture.color.a > 0.05 )
        {
            fader.FadeIn();
            yield return 0;
        }
    }
}
