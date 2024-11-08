using UnityEngine;

namespace Clases.PA2024.Inventory
{
    public abstract class ScriptableReference : ScriptableObject
    {
        // Variables
        [SerializeField] private int maxStack = 64;

        // Properties
        public string Identifier => name;
        public abstract ItemData.ItemType Type { get; }

        public int MaxStack => maxStack;
    }
}
