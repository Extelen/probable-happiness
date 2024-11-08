using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clases.PA2024.StateMachines
{
    // Al heredar StateMachine con los genericos creados anteriormente llamados
    //  SlimeStateBase, el cual hereda de StateBase y
    //  SlimeController, el cual seria el controlador con las referencias principales de nuestro objeto,
    // podremos utilizar nuestro SlimeStateMachine para transicionar, guardar e inicializar correctamente
    // los distintos estados de nuestro objeto.

    // Anteriormente utilizabamos un State Factory que se encargaba de eso, pero para facilitar un poco
    // y no tener que crear varios scripts, podemos utilizar el StateMachine para guardar nuestros estados sin 
    // ningun problema.
    public class SlimeStateMachine : StateMachine<SlimeStateBase, SlimeController>
    {
        // Variables
        [Header("States")]
        [SerializeField] private SlimeState_Idle idle;
        [SerializeField] private SlimeState_Patrol patrol;
        [SerializeField] private SlimeState_FollowPlayer followPlayer;
        [SerializeField] private SlimeState_Death death;

        // Properties
        public SlimeState_Idle Idle => idle;
        public SlimeState_Patrol Patrol => patrol;
        public SlimeState_FollowPlayer FollowPlayer => followPlayer;
        public SlimeState_Death Death => death;

        // Methods
        protected override void InitializeStates(SlimeController controller)
        {
            idle.Initialize(controller);
            patrol.Initialize(controller);
            followPlayer.Initialize(controller);
            death.Initialize(controller);
        }
    }
}