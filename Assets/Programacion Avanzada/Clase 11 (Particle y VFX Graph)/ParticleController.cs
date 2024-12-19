using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] private ParticleSystem m_particleSystem;
    [SerializeField] private Gradient m_gradient;
    [SerializeField] private float m_speed;

    private ParticleSystem.MainModule m_mainModule;
    private float m_value;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        m_mainModule = m_particleSystem.main;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        m_value += m_speed * Time.deltaTime;
        m_value %= 1;

        m_mainModule.startColor = m_gradient.Evaluate(m_value);
    }
}
