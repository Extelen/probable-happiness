using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clases.PA2024.Inventory
{
    [CreateAssetMenu(menuName = "Clase/PA2024/Inventory/Weapon", fileName = "Weapon")]
    public class SOWeapon : ScriptableReference, IInventoriable
    {
        // Variables
        [SerializeField] private Sprite icon;

        [SerializeField] private int damage;
        [SerializeField] private float fireRate;

        public override ItemData.ItemType Type => ItemData.ItemType.Weapon;

        public Sprite Icon => icon;
    }
}