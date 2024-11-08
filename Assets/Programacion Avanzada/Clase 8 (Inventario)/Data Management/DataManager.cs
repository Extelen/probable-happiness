using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clases.PA2024.Inventory
{
    public class DataManager : MonoBehaviour
    {
        // Data
        private static GameData m_data;
        public static GameData Data => m_data;

        // Methods
        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        private void Awake()
        {
            if (Data != null) return;
            SaveSystem.LoadInfo info = SaveSystem.LoadOrCreate("Inventory", out m_data);
            if (info == SaveSystem.LoadInfo.Created) Save();
        }

        public static void Save()
        {
            SaveSystem.Save(Data, "Inventory");
        }

        public void ResetData()
        {
            m_data = new GameData();
        }
    }
}