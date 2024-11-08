using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clases.PA2024.Inventory
{
    [CreateAssetMenu(menuName = "Clase/PA2024/Inventory/Material", fileName = "Material")]
    public class SOMaterial : ScriptableReference, IInventoriable
    {
        // Enum
        public enum MaterialType { Rock, Wood, Plant }

        // Variables
        [SerializeField] private Sprite icon;

        [SerializeField] private MaterialType materialType;
        [SerializeField] private string description;

        // Properties
        public override ItemData.ItemType Type => ItemData.ItemType.Material;

        public Sprite Icon => icon;
    }
}