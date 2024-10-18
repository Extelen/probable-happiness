using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Threading.Tasks;
using System;

[System.Serializable]
public class SlimeState_Idle : SlimeStateBase
{
    public float timeToWalk;

    public override async void Enter()
    {
        base.Enter();
        Debug.Log("Me quede quieto");


        Debug.Log("Voy a empezar a esperar");
        // TimeSpan waitSeconds = new TimeSpan(0, 0, timeToWalk);
        // await Task.Delay(waitSeconds);

        await Task.Delay((int)(timeToWalk * 1000));

        await Task.Yield();
        Debug.Log("Termine de esperar y me voy a patrol");

        // Controller.stateMachine.SwitchState(Controller.states.patrol);
    }

    public override void Logic()
    {
        base.Logic();

        // if (DetectPlayer())
        // {
        // Controller.stateMachine.SwitchState(Controller.states.followPlayer);
        // }

    }
}
