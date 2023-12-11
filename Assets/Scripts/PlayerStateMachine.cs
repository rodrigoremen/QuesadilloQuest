using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    // Start is called before the first frame update
    void Start()
    {
        SwitchState(new MovingForwardState(this));
    }

    // Update is called once per frame
    
}
