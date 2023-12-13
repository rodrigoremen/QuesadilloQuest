using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingState : PlayerBaseState
{
    public RotatingState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
      
    }

    public override void Exit()
    {
        
    }

    public override void Tick()
    {
        stateMachine.transform.Rotate(0f, 10f * Time.deltaTime, 0f);
    }

}
