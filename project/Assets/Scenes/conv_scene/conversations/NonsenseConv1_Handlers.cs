using UnityEngine;
using System.Collections;

public class NonsenseConv1_Handlers : MonoBehaviour {

    public FixedFollowController CameraFollow;

    private MessageACK msg;

    public GameObject weirdo1;

    public GameObject weirdo2;

    void NonsenseConv1_MoveCam1(MessageACK msg)
    {
        this.msg = msg;
        this.msg.received = true;
        StartCoroutine( movecam1_coroutine() );
    }

    void NonsenseConv1_MoveCam2(MessageACK msg)
    {
        this.msg = msg;
    }


    IEnumerator movecam1_coroutine()
    {
        CameraFollow.enabled = false;
        float t = 0;
        Vector3 start = LogicManager.Instance.Player.pawn.transform.position;
        start.z = Camera.main.transform.position.z;
        Vector3 end = weirdo1.transform.position;
        end.z = Camera.main.transform.position.z;
        while (t < 1)
        {
            t += Time.deltaTime;
            Camera.main.transform.position = Vector3.Lerp(start, end, t);
            yield return 0;
        }
        yield return new WaitForSeconds( 1 );
        t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            Camera.main.transform.position =  Vector3.Lerp(end, start, t);
            yield return 0;
        }
        CameraFollow.enabled = true;
        msg.callback();
    }
}
