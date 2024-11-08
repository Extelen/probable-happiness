using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Para crear una maquina de estados es necesario crear y heredar 3 scripts distintos
// entre ellos StateMachine, StateFactory y en cada uno de los estados, StateBase.
public abstract class StateMachine<TState, TController> : MonoBehaviour
where TState : StateBase<TController>
where TController : MonoBehaviour
{
    // Variables
    [Header("State Machine")]
    [SerializeField] private bool debugMode = false;

    private TState currentState;

    // Methods
    /// <summary>
    /// Esta funcion es la encargada de inicializar nuestra StateMachine y deberemos pasarle el 
    /// controlador del objeto y el estado inicial, el cual puede ser null si se quisiera.
    /// </summary>
    public void Initialize(TController controller, TState defaultState)
    {
        InitializeStates(controller);
        SwitchState(defaultState);
    }

    /// <summary>
    /// Utilizando SwitchState ejecutaremos la funcion Exit del estado actual si es que hay uno corriendo
    /// y posteriormente utilizaremos la funcion Enter del nuevo estado.
    /// </summary>
    public void SwitchState(TState newState)
    {
        if (debugMode)
        {
            Debug.Log($"{gameObject.name} changed its state from: {currentState} to {newState}");
        }

        if (currentState != null) currentState.Exit();
        currentState = newState;
        if (currentState != null) currentState.Enter();
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        if (currentState != null)
        {
            currentState.Logic();
        }
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void FixedUpdate()
    {
        if (currentState != null)
        {
            currentState.FixedLogic();
        }
    }

    /// <summary>
    /// Funcion que debe ser implementada si o si por el hijo de nuestro StateMachine 
    /// donde se debera inicializar cada uno de nuestros estados para darle el controlador
    /// principal del objeto.
    /// </summary>
    protected abstract void InitializeStates(TController controller);
}