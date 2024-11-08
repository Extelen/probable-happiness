using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clases.PA2024.StateMachines
{
    [System.Serializable]
    public class SlimeState_Patrol : SlimeStateBase
    {
        // Variables
        [SerializeField] private float walkTime;

        private float currentTime;

        // Methods
        public override void Enter()
        {
            base.Enter();
            currentTime = walkTime;
            Debug.Log("Me estoy empezando a mover aleatoriamente hacia un punto");
        }

        public override void Logic()
        {
            base.Logic();

            if (DetectPlayer())
            {
                Controller.StateMachine.SwitchState(Controller.StateMachine.FollowPlayer);
            }

            Debug.Log("Me estoy moviendo");

            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                Controller.StateMachine.SwitchState(Controller.StateMachine.Idle);
            }
        }
    }
}