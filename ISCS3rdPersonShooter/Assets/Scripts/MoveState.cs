using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : MovementStateBase
{
    // Start is called before the first frame update
    public override void EnterState(MovementManager movement) {
        movement.anim.SetBool("Moving", true);
    }
    public override void UpdateState(MovementManager movement) {
        if (movement.dir.magnitude < 0.1f) ExitState(movement, movement.idle);
    }
    void ExitState(MovementManager movement, MovementStateBase state) {

        movement.anim.SetBool("Moving", false);
        movement.switchState(state);
    }
    
}
