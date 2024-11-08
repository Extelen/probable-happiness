using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clases.PA2024.Inventory
{
    [CreateAssetMenu(menuName = "Clase/PA2024/Inventory/Potion", fileName = "Potion")]
    public class SOPotion : ScriptableReference, IInventoriable
    {
        // Variables
        [SerializeField] private Sprite icon;
        [SerializeField] private int healthValue;

        public override ItemData.ItemType Type => ItemData.ItemType.Potion;

        public Sprite Icon => icon;
    }
}