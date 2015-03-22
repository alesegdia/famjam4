using UnityEngine;
using System.Collections;

public class AltEndingController : MonoBehaviour {

    public GUIText subtitle;
    public FaderUI fader;

    // Use this for initialization
    IEnumerator Start()
    {
        // wait for input
        while (!Input.anyKeyDown)
        {
            yield return 0;
        }

        subtitle.enabled = true;
        yield return new WaitForEndOfFrame();
        // wait for input
        while (!Input.anyKeyDown)
        {
            yield return 0;
        }

        // do a fade
        yield return StartCoroutine(fadeOut());

        Application.LoadLevel("mainmenu");
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
        while (fader.guiTexture.color.a > 0.05)
        {
            fader.FadeIn();
            yield return 0;
        }
    }
}
