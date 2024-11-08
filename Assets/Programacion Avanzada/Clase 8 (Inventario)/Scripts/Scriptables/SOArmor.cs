using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clases.PA2024.Inventory
{
    [CreateAssetMenu(menuName = "Clase/PA2024/Inventory/Armor", fileName = "Armor")]
    public class SOArmor : ScriptableReference, IInventoriable
    {
        // Variables
        [SerializeField] private Sprite icon;

        [SerializeField] private int defense;

        // Properties

        public override ItemData.ItemType Type => ItemData.ItemType.Armor;

        public Sprite Icon => icon;

    }
}