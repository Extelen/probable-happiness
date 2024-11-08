using System.Collections;
using System.Collections.Generic;
using Clases.PA2024.Inventory;
using UnityEngine;

public class GrabbableObject : MonoBehaviour
{
    // Variables
    [SerializeField] private int count;
    [SerializeField] private ScriptableReference scriptable;

    // Properties
    public ScriptableReference Scriptable => scriptable;

    // Methods
    public void Interact()
    {
        for (int i = 0; i < count; i++)
        {
            DataManager.Data.TryAdd(scriptable);
        }

        DataManager.Save();

        Destroy(gameObject);
    }
}
