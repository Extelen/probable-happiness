using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Clases.PA2024.Inventory
{
    public class PlayerController : Management.PlayerController
    {
        // Variables
        [SerializeField] private Volume m_volume;

        // Methods
        protected override void OnControllerColliderHit(ControllerColliderHit hit)
        {
            base.OnControllerColliderHit(hit);

            if (hit.gameObject.TryGetComponent(out GrabbableObject grabbable))
            {
                grabbable.Interact();
            }
        }

        public override void GetDamage()
        {
            base.GetDamage();

            TimeScaleBehaviour.Instance.GetHit();
            StartCoroutine(DoHit());
        }

        // Coroutines
        private IEnumerator DoHit()
        {
            m_volume.weight = 1;

            for (float i = 0; i < 0.5f; i += Time.unscaledDeltaTime)
            {
                m_volume.weight = Mathf.Lerp(1, 0, i / 0.5f);
                yield return null;
            }

            m_volume.weight = 0;
        }

    }
}