using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class StateBase<TController>
where TController : MonoBehaviour
{
    // Variables
    private TController controller;

    // Properties;
    protected TController Controller
    {
        get
        {
            if (controller == null)
            {
                Debug.LogError("El controlador no ha sido asignado, lo que significa que el estado no ha sido inicializado");
                return null;
            }

            return controller;
        }
    }

    // Methods
    public void Initialize(TController controller)
    {
        this.controller = controller;
    }

    public virtual void Enter() { }
    public virtual void Logic() { }
    public virtual void FixedLogic() { }
    public virtual void Exit() { }
}
