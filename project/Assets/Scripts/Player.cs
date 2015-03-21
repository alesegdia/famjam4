using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public MovementKeyboardController MovementController;
    public LookAtController LookAtController;
    public LookAtMouse LookAtMouseCtrl;
    public Rigidbody2D pawn;

    public void DisableAllControllers()
    {
        MovementController.enabled = false;
        LookAtController.enabled = false;
        LookAtMouseCtrl.enabled = false;
    }
}
