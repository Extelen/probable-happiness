using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clases.PA2024.Inventory
{
    public class ScriptableReferences : Singleton<ScriptableReferences>
    {
        // Variables
        [SerializeField] private List<SOWeapon> weapons;
        [SerializeField] private List<SOArmor> armors;
        [SerializeField] private List<SOPotion> potions;
        [SerializeField] private List<SOMaterial> materials;

        // Properties
        protected override bool Persistent => false;

        public List<SOWeapon> Weapons => weapons;
        public List<SOArmor> Armors => armors;
        public List<SOPotion> Potions => potions;
        public List<SOMaterial> Materials => materials;

        // Methods
        public SOWeapon GetWeapon(string identifier) => Get(weapons, identifier);
        public SOArmor GetArmor(string identifier) => Get(armors, identifier);
        public SOMaterial GetMaterial(string identifier) => Get(materials, identifier);
        public SOPotion GetPotion(string identifier) => Get(potions, identifier);

        private T Get<T>(List<T> list, string identifier) where T : ScriptableReference
        {
            foreach (T item in list)
            {
                if (item.Identifier == identifier)
                {
                    return item;
                }
            }

            return null;
        }
    }
}