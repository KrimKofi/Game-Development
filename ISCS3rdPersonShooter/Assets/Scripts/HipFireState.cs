using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HipFireState : AimBaseState
{
    public override void EnterState(AimStateManager manager)
    {
        manager.anim.SetBool("Aiming", false);
    }
    public override void UpdateState(AimStateManager manager)
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            manager.switchState(manager.aim);
        }
    }
}
