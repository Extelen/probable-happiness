using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clases.PA2024.StateMachines
{
    // SlimeStateBase heredara de StateBase y le pasaremos SlimeController como variable generica
    // para asi poder acceder a cada una de las funciones y variables que contenga nuestro SlimeController
    // por ejemplo, la funcion GetDamage o la maquina de estados con todos sus estados.
    // Tambien podemos crear funciones que podra implementar cada uno de los estados que hereden de esta base,
    // por ejemplo, en este caso, la funcion DetectPlayer.
    public class SlimeStateBase : StateBase<SlimeController>
    {
        /// <summary>
        /// Esta funcion detecta si el jugador esta cerca de un rango, pero para simplificar la clase,
        /// hicimos que aleatoriamente dijera que si.
        /// </summary>
        public bool DetectPlayer()
        {
            // if (Physics.OverlapSphere(Controller.transform.position))
            // Debug.Log("Buscando al jugador");

            if (Random.Range(0, 100) == 0)
            {
                return true;
            }

            return false;
        }
    }
}