using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class DayTimerUI : MonoBehaviour 
{
    public Rect SkipBtVPCoords;

    public Rect TimerLabelBtVPCoords;

    public GUISkin skin;

    public int SecondsPerHour = 60;

    public int InitialTimeHours = 12;

    private int currentHour = 12;

    private bool showPoints = true;

	// Use this for initialization
	void Start () {
        if (skin == null)
        {
            skin = new GUISkin();
        }
        currentHour = InitialTimeHours;

        StartCoroutine( UpdateTime() );
        StartCoroutine( UpdatePoints() );
	}

    IEnumerator UpdateTime()
    {
        while ( currentHour != 0 )
        {
            yield return new WaitForSeconds( SecondsPerHour );
            ++currentHour;
            currentHour = currentHour % 24;
        }
        // notify the midnight
        NotifyMidnight();
    }

    IEnumerator UpdatePoints()
    {
        while( true )
        {
            yield return new WaitForSeconds( 1 );
            showPoints = !showPoints;
        }
    }

    void OnGUI()
    {
        Rect screenRect = new Rect(Screen.width * SkipBtVPCoords.x, Screen.height * (1 - SkipBtVPCoords.y - SkipBtVPCoords.height), Screen.width * SkipBtVPCoords.width, Screen.height * SkipBtVPCoords.height);
        if( GUI.Button( screenRect, "Wait until midnight", skin.button ) )
        {
            StopAllCoroutines();
            //notify the midnight
            NotifyMidnight();
        }

        screenRect = new Rect(Screen.width * TimerLabelBtVPCoords.x, Screen.height * (1 - TimerLabelBtVPCoords.y - TimerLabelBtVPCoords.height), Screen.width * TimerLabelBtVPCoords.width, Screen.height * TimerLabelBtVPCoords.height);
        string time = null;
        if( showPoints )
        {
            time = string.Format( "{0}:00", currentHour.ToString() );
        }
        else
        {
            time = string.Format("{0} 00", currentHour.ToString());
        }

        GUIStyle style = skin.FindStyle( "timer" );
        if (style != null)
        {
            GUI.Label(screenRect, time, skin.label);
        }
        else
        {
            GUI.Label(screenRect, time, skin.label );
        }
    }

    void NotifyMidnight()
    {
        if( LogicManager.Instance.CurrentState != LogicManager.LogicStates.ALTERNATIVE_ENDING )
        {
            LogicManager.Instance.LoadScene( "ActionScene" );
        }
        this.enabled = false;
    }
}
