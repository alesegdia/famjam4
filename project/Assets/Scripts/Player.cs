using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public MovementKeyboardController MovementController;
    public LookAtController LookAtController;
    public LookAtMouse LookAtMouseCtrl;
    public Rigidbody2D pawn;
    public Weapon WeaponInUse;
    public ConversationController ConvController;

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
}
