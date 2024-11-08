using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clases.PA2024.Management
{
    // Nuestro InventoryManager se encargará de cambiar el panel de la UI a "Inventory"
    // si es que esta desactivado, o al estado "Game Status" si es que está activo.
    public class InventoryManager : MonoBehaviour
    {
        // Aca haré que si estoy en el estado Gameplay y presiono Tabulador
        // se alternará el estado del inventario dependiendo del identificador actual que tenga,
        // nuestro UIManager.
        private void Update()
        {
            if (GameManager.CurrentState == GameState.Gameplay)
            {
                if (Input.GetKeyDown(KeyCode.Tab))
                {
                    ToggleInventory();
                }
            }
        }

        // Esta funcion se encargará de cambiar el valor de la UI dependiendo del valor
        // actual del UIManager
        private void ToggleInventory()
        {
            // Aca guardaré un bool el cual será true si el identificador es "Inventory"
            // y false, si es cualquier otro.
            bool isActive = UIManager.Instance.CurrentIdentifier == "Inventory";

            // Acá estableceremos el identificador al que queramos cambiar dependiendo del estado
            // actual de la UI.
            // Si la UI es "Inventory", el nuevo panel será "Game Status"
            // En cambio, si es "Game Status", el nuevo panel será "Inventory".
            string newPanel = isActive ? "Game Status" : "Inventory";

            bool canToggle = false;

            if (UIManager.Instance.CurrentIdentifier == "Game Status") canToggle = true;
            else if (UIManager.Instance.CurrentIdentifier == "Inventory") canToggle = true;

            if (!canToggle) return;

            UIManager.Instance.SwitchPanel(newPanel);
        }
    }
}
