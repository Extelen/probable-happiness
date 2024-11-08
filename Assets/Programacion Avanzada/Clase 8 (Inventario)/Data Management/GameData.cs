using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clases.PA2024.Inventory
{
    [System.Serializable]
    public class GameData
    {
        // Variables
        [SerializeField] private ItemData[] items1;
        [SerializeField] private ItemData[] items2;
        [SerializeField] private ItemData[] items3;
        [SerializeField] private ItemData[] items4;

        // Constructor
        public GameData()
        {
            items1 = new ItemData[9];
            items2 = new ItemData[9];
            items3 = new ItemData[9];
            items4 = new ItemData[9];
        }

        // Methods
        public ItemData GetItem(int x, int y)
        {
            if (y == 0) return items1[x];
            if (y == 1) return items2[x];
            if (y == 2) return items3[x];
            if (y == 3) return items4[x];

            return null;
        }

        public void SetItem(int x, int y, ItemData item)
        {
            if (y == 0)
            {
                items1[x] = item;
                return;
            }

            if (y == 1)
            {
                items2[x] = item;
                return;
            }

            if (y == 2)
            {
                items3[x] = item;
                return;
            }

            if (y == 3)
            {
                items4[x] = item;
                return;
            }
        }

        public void TryAdd(ScriptableReference scriptable)
        {
            bool TryAddCountToItem(ItemData[] items)
            {
                for (int i = 0; i < items.Length; i++)
                {
                    ItemData item = items[i];
                    if (item.Identifier == scriptable.Identifier)
                    {
                        bool wasAdded = item.TryAddCount(scriptable.MaxStack);
                        if (wasAdded) return true;
                    }
                }

                return false;
            }

            if (TryAddCountToItem(items1)) return;
            if (TryAddCountToItem(items2)) return;
            if (TryAddCountToItem(items3)) return;
            if (TryAddCountToItem(items4)) return;

            bool TryAddNewToArray(ItemData[] items)
            {
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i].Identifier == "")
                    {
                        items[i] = new ItemData(scriptable.Type, scriptable.Identifier);
                        return true;
                    }
                }

                return false;
            }

            if (TryAddNewToArray(items1)) return;
            if (TryAddNewToArray(items2)) return;
            if (TryAddNewToArray(items3)) return;
            if (TryAddNewToArray(items4)) return;
        }
    }

    [System.Serializable]
    public class ItemData
    {
        public enum ItemType { Armor, Weapon, Potion, Material }

        [SerializeField] private ItemType type;
        [SerializeField] private string identifier;
        [SerializeField] private int count;

        public int Count => count;

        public ItemData(ItemType type, string identifier)
        {
            this.type = type;
            this.identifier = identifier;
            count = 1;
        }

        public ItemType Type { get => type; set => type = value; }
        public string Identifier { get => identifier; set => identifier = value; }

        public bool TryAddCount(int max)
        {
            if (count >= max)
            {
                return false;
            }

            count++;
            return true;
        }

        public void RemoveCount()
        {
            count--;
            count = Mathf.Clamp(count, 0, 100);
        }
    }
}