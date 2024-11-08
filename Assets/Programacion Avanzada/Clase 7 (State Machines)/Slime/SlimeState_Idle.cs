using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clases.PA2024.StateMachines
{
    [System.Serializable]
    public class SlimeState_Idle : SlimeStateBase
    {
        // Variables
        [SerializeField] private float timeToWalk;

        private Coroutine m_example;

        // Methods
        public override void Enter()
        {
            base.Enter();
            Debug.Log("Me quede quieto");
            m_example = Controller.StartCoroutine(CoroutineExample());
        }

        public override void Logic()
        {
            base.Logic();

            if (DetectPlayer())
            {
                Controller.StateMachine.SwitchState(Controller.StateMachine.FollowPlayer);
            }
        }

        public override void Exit()
        {
            base.Exit();
            Controller.StopCoroutine(m_example);
        }

        /// <summary>
        /// Ya que como no se hereda de MonoBehaviour, no es posible utilizar coroutinas
        /// entonces para solucionar esto, las enviaremos al controlador para que el se encargue de ejecutarlas.
        /// </summary>
        private IEnumerator CoroutineExample()
        {
            Debug.Log("Voy a empezar a esperar");

            yield return new WaitForSeconds(timeToWalk);

            Debug.Log("Termine de esperar y me voy a patrol");

            Controller.StateMachine.SwitchState(Controller.StateMachine.Patrol);
        }
    }
}