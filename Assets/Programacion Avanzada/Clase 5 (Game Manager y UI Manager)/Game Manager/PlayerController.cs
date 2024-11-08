using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clases.PA2024.Management
{
    // Este es un script generico para mover un jugador, pero está suscrito al 
    public class PlayerController : MonoBehaviour
    {
        // Events
        public static event HealthDelegate OnHealthChange;

        // Variables
        [Header("Settings")]
        [SerializeField] private float m_speed = 4f;
        [SerializeField] private int m_maxHealth = 4;

        [Header("References")]
        [SerializeField] private CharacterController m_characterController;

        private int m_currentHealth = 4;

        // Properties
        public int CurrentHealth => m_currentHealth;
        public int MaxHealth => m_maxHealth;

        private void Start()
        {
            m_currentHealth = MaxHealth;
            OnHealthChange?.Invoke(m_currentHealth, m_maxHealth);
        }

        // Si quiero detectar el cambio de estado del GameManager, aca puedo suscribirme.
        private void OnEnable()
        {
            GameManager.OnStateChange += OnStateChange;
        }

        // Y, para evitar que si el objeto se destruye, el GameManager erroje error, 
        // es preferible que lo desuscribamos siempre.
        private void OnDisable()
        {
            GameManager.OnStateChange -= OnStateChange;
        }

        // Esta seria la función que se ejecutará cuando se reciba la señal de que el 
        // estado del GameManager cambio, enviandonos state para que podamos comprobar.
        private void OnStateChange(GameState state)
        {
            // Si el nuevo estado es GameOver, arrojaremos un Debug que lo dirá.
            if (state == GameState.GameOver)
            {
                Debug.Log("Game over");
            }

            // En cambio, si es victoria, arrojaremos otro Debug.
            else if (state == GameState.Victory)
            {
                Debug.Log("Victory");
            }
        }

        /// <summary>
        /// OnControllerColliderHit is called when the controller hits a
        /// collider while performing a Move.
        /// </summary>
        /// <param name="hit">The ControllerColliderHit data associated with this collision.</param>
        protected virtual void OnControllerColliderHit(ControllerColliderHit hit) { }

        // Aca haré el codigo generico de mover al personaje, pero tendre una tecla de Debug para 
        // hacerme daño a mi mismo.
        private void Update()
        {
            // Pero esto ocurrira siempre y cuando el estado actual del GameManager sea
            // Gameplay.
            if (GameManager.CurrentState == GameState.Gameplay)
            {
                Move();
                if (Input.GetKeyDown(KeyCode.G))
                {
                    GetDamage();
                }
            }
        }

        // Codigo generico de movimiento de personaje 👍
        private void Move()
        {
            Vector3 input = Vector3.zero;
            input.x = Input.GetAxisRaw("Horizontal");
            input.z = Input.GetAxisRaw("Vertical");

            m_characterController.Move(input * m_speed * Time.deltaTime);
        }

        // Codigo generico para hacerme daño a mi mismo 😔
        public virtual void GetDamage()
        {
            m_currentHealth--;
            OnHealthChange?.Invoke(m_currentHealth, m_maxHealth);

            if (m_currentHealth == 0)
            {
                OnDeath();
            }
        }

        // En esta funcion, cuando mi vida sea igual a 0, destruire el objeto,
        // pero, tambien cambiaré el estado del GameManager a GameOver. 
        public virtual void OnDeath()
        {
            GameManager.SwitchState(GameState.GameOver);
            Destroy(gameObject);
        }

        // Delegates
        public delegate void HealthDelegate(int health, int maxHealth);
    }
}