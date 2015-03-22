using UnityEngine;
using System.Collections;

public class NonsenseConv1_Handlers : MonoBehaviour {

    public FixedFollowController CameraFollow;

    private MessageACK msg;

    public GameObject weirdo1;

    public GameObject weirdo2;

    public Animator UpperPartAnimator;

    void NonsenseConv1_MoveCam1(MessageACK msg)
    {
        this.msg = msg;
        this.msg.received = true;
        StartCoroutine( movecam1_coroutine() );
    }

    void NonsenseConv1_MoveCam2(MessageACK msg)
    {
        this.msg = msg;
        this.msg.received = true;
        StartCoroutine(movecam2_coroutine());
    }


    IEnumerator movecam1_coroutine()
    {
        CameraFollow.enabled = false;
        float t = 0;
        Vector3 start = LogicManager.Instance.Player.pawn.transform.position;
        start.z = Camera.main.transform.position.z;
        Vector3 end = weirdo1.transform.position;
        end.z = Camera.main.transform.position.z;
        // look there
        /*Quaternion original_rot = LogicManager.Instance.Player.pawn.transform.rotation;
        Vector3 delta = end - LogicManager.Instance.Player.pawn.transform.position;
        float rot_z = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;
        LogicManager.Instance.Player.pawn.transform.rotation = Quaternion.AngleAxis(rot_z - 90, Vector3.forward);*/
        int currentDir = UpperPartAnimator.GetInteger("Direction");
        Vector3 delta = end - LogicManager.Instance.Player.pawn.transform.position;
        float rot_z = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;
        Quaternion rot = Quaternion.AngleAxis(rot_z - 90, Vector3.forward);
        float angle = rot.eulerAngles.z;
        int dir = ((int)((360f - angle + 180f / 8) / (360f / 8)));
        UpperPartAnimator.SetInteger("Direction", dir);

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
        //LogicManager.Instance.Player.pawn.transform.rotation = original_rot;
        UpperPartAnimator.SetInteger("Direction", currentDir);
        msg.callback();
    }

    IEnumerator movecam2_coroutine()
    {
        CameraFollow.enabled = false;
        float t = 0;
        Vector3 start = LogicManager.Instance.Player.pawn.transform.position;
        start.z = Camera.main.transform.position.z;
        Vector3 end = weirdo2.transform.position;
        end.z = Camera.main.transform.position.z;

        int currentDir = UpperPartAnimator.GetInteger("Direction");
        Vector3 delta = end - LogicManager.Instance.Player.pawn.transform.position;
        float rot_z = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;
        Quaternion rot = Quaternion.AngleAxis(rot_z - 90, Vector3.forward);
        float angle = rot.eulerAngles.z;
        int dir = ((int)((360f - angle + 180f / 8) / (360f / 8)));
        UpperPartAnimator.SetInteger("Direction", dir);

        while (t < 1)
        {
            t += Time.deltaTime;
            Camera.main.transform.position = Vector3.Lerp(start, end, t);
            yield return 0;
        }
        yield return new WaitForSeconds(1);
        t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            Camera.main.transform.position = Vector3.Lerp(end, start, t);
            yield return 0;
        }
        CameraFollow.enabled = true;
        //LogicManager.Instance.Player.pawn.transform.rotation = original_rot;
        UpperPartAnimator.SetInteger("Direction", currentDir);
        msg.callback();
    }
}
