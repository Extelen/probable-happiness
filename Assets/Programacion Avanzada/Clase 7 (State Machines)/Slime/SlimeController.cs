using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clases.PA2024.StateMachines
{
    // Nuestro SlimeController sera el padre de nuestro objeto, el script principal, ya que este se encargara
    // de tener las funciones y variables principales.
    // En el debe estar la state machine que creamos para nuestro objeto y debe ser inicializada
    // en el Awake para que se inicialicen los estados y se escoja el estado inicial.
    public class SlimeController : MonoBehaviour
    {
        // Variables
        [Header("States")]
        [SerializeField] private SlimeStateMachine stateMachine;

        // Properties
        public SlimeStateMachine StateMachine => stateMachine;

        // Methods
        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        private void Awake()
        {
            stateMachine.Initialize(this, stateMachine.Idle);
        }

        /// <summary>
        /// Esta funcion esta hecha para demostrar que se pueden convertir algunas de nuestras funciones
        /// de MonoBehaviour en Coroutinas.
        /// </summary>
        private IEnumerator Start()
        {
            yield return new WaitForSeconds(3);
            Debug.Log("Pasaron 3 segundos");
        }

        /// <summary>
        /// Funcion que si recibo daño hará que me muera, lo que cambiará el estado a muerto.
        /// </summary>
        public void GetDamage()
        {
            Debug.Log("Solo tengo un punto de vida asi que me mori");
            stateMachine.SwitchState(stateMachine.Death);
        }
    }
}