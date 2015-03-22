using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public MovementKeyboardController MovementController;
    public LookAtController LookAtController;
    //public LookAtMouse LookAtMouseCtrl;
    public UpperBodyLookAtMouse LookAtMouseCtrl;
    public Rigidbody2D pawn;
    public Weapon WeaponInUse;
    public ConversationController ConvController;
    public Animator UpperBodyAnimator;

    public void EnableAllMovementControllers( bool enabled )
    {
        if ( MovementController )
            MovementController.enabled = enabled;
        if( LookAtController )
            LookAtController.enabled = enabled;
        if( LookAtMouseCtrl )
            LookAtMouseCtrl.enabled = enabled;
    }

    public void EnableAll(bool enabled)
    {
        if (MovementController)
            MovementController.enabled = enabled;
        if (LookAtController)
            LookAtController.enabled = enabled;
        if (LookAtMouseCtrl)
            LookAtMouseCtrl.enabled = enabled;
        if (ConvController)
            ConvController.enabled = enabled;
    }

    public Vector3 GetLookDirection()
    {
        if( UpperBodyAnimator )
        {
            int dir = UpperBodyAnimator.GetInteger("Direction");
            switch (dir)
            {
                case 0:
                    return Vector3.up;
                case 1:
                    return new Vector3( 1, 1, 0 ).normalized;
                case 2:
                    return Vector3.right;
                case 3:
                    return new Vector3( 1, -1, 0).normalized;
                case 4:
                    return Vector3.down;
                case 5:
                    return new Vector3( -1, -1, 0).normalized;
                case 6:
                    return Vector3.left;
                case 7:
                    return new Vector3(-1, 1, 0).normalized;
                default:
                    return Vector3.up;
            }
        }
        else
        {
            return Vector3.up;
        }
    }
}
