using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : MovementStateBase
{
    // Start is called before the first frame update
    public override void EnterState(MovementManager movement)
    {

    }
    public override void UpdateState(MovementManager movement)
    {
        //Debug.Log("idle");
        if (movement.dir.magnitude > 0.1) {
            movement.switchState(movement.move);
            //Debug.Log("Walking");
        }
    }




}
