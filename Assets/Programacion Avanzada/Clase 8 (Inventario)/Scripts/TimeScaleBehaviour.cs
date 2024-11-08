using System.Collections;
using System.Collections.Generic;
using Clases.PA2024.Management;
using UnityEngine;

namespace Clases.PA2024.Inventory
{
    public class TimeScaleBehaviour : Singleton<TimeScaleBehaviour>
    {
        // Variables
        private float m_timeScaleMultiplier = 1;

        // Properties
        protected override bool Persistent => false;

        // Methods
        /// <summary>
        /// Update is called every frame, if the MonoBehaviour is enabled.
        /// </summary>
        private void Update()
        {
            float timeScale = 1;

            switch (UIManager.Instance.CurrentIdentifier)
            {
                case "Game Status": timeScale = 1; break;
                case "Dialogue": timeScale = 1; break;
                default: timeScale = 0; break;
            }

            Time.timeScale = timeScale * m_timeScaleMultiplier;
        }

        public void GetHit()
        {
            IEnumerator HitBehaviour()
            {
                for (float i = 0; i < 0.25f; i += Time.deltaTime)
                {
                    m_timeScaleMultiplier = Mathf.Lerp(0f, 1f, i / 0.25f);
                    yield return null;
                }
            }

            StartCoroutine(HitBehaviour());
        }

    }
}