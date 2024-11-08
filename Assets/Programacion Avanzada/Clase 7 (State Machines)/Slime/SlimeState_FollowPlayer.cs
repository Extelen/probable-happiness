using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clases.PA2024.StateMachines
{
    [System.Serializable]
    public class SlimeState_FollowPlayer : SlimeStateBase
    {
        // Methods
        public override void Enter()
        {
            base.Enter();

            //Controller.Rigidbody.velocity = Vector3.forward;
        }

        public override void Logic()
        {
            base.Logic();

            Debug.Log("Me estoy moviendo hacia el jugador");

            if (Random.Range(0, 10) == 0)
            {
                Debug.Log("Perdi de vista al jugador");
                Controller.StateMachine.SwitchState(Controller.StateMachine.Idle);
            }
        }

        public override void Exit()
        {
            base.Exit();

            //Controller.Rigidbody.velocity = Vector3.zero;
        }
    }
}