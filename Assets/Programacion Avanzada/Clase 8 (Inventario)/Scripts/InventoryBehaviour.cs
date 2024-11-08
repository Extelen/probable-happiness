using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clases.PA2024.Inventory
{
    public class InventoryBehaviour : MonoBehaviour
    {
        // Variables
        [SerializeField] private SocketHUD[] sockets1;
        [SerializeField] private SocketHUD[] sockets2;
        [SerializeField] private SocketHUD[] sockets3;
        [SerializeField] private SocketHUD[] sockets4;

        // Methods
        /// <summary>
        /// This function is called when the object becomes enabled and active.
        /// </summary>
        private void OnEnable()
        {

            void SetItem(SocketHUD[] hudItems, int y)
            {
                for (int i = 0; i < hudItems.Length; i++)
                {
                    SocketHUD item = hudItems[i];

                    ItemData data = DataManager.Data.GetItem(i, y);
                    IInventoriable inventoriable = null;

                    switch (data.Type)
                    {
                        case ItemData.ItemType.Weapon:
                            inventoriable = ScriptableReferences.Instance.GetWeapon(data.Identifier);
                            break;

                        case ItemData.ItemType.Armor:
                            inventoriable = ScriptableReferences.Instance.GetArmor(data.Identifier);
                            break;

                        case ItemData.ItemType.Potion:
                            inventoriable = ScriptableReferences.Instance.GetPotion(data.Identifier);
                            break;

                        case ItemData.ItemType.Material:
                            inventoriable = ScriptableReferences.Instance.GetMaterial(data.Identifier);
                            break;
                    }

                    item.SetScriptable(inventoriable, data.Count);
                }
            }

            SetItem(sockets1, 0);
            SetItem(sockets2, 1);
            SetItem(sockets3, 2);
            SetItem(sockets4, 3);
        }
    }
}
