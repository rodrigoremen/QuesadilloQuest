using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingForwardState : PlayerBaseState
{
    public MovingForwardState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.transform.position = new Vector3(-20f, 2f, 13f);
    }

    public override void Exit()
    {
        
    }

    public override void Tick()
    {
        stateMachine.transform.position += Vector3.forward*Time.deltaTime;
        if (stateMachine.transform.position.z>=20f)
        {
            stateMachine.SwitchState(new RotatingState(stateMachine));
        }

    }
}
