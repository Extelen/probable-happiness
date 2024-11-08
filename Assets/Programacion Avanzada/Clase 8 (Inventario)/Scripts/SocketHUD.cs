using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.EventSystems;

namespace Clases.PA2024.Inventory
{
    public class SocketHUD : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler,
    IBeginDragHandler,
    IDragHandler,
    IEndDragHandler
    {
        // Variables
        [SerializeField] private Image iconRenderer;
        [SerializeField] private TextMeshProUGUI countRenderer;

        private Vector2 startPosition;

        // Properties

        // Methods
        /// <summary>
        /// Start is called on the frame when a script is enabled just before
        /// any of the Update methods is called the first time.
        /// </summary>
        void Start()
        {
            startPosition = transform.position;
        }

        public void SetScriptable(IInventoriable inventoriable, int count)
        {
            if (inventoriable == null)
            {
                iconRenderer.enabled = false;
                countRenderer.enabled = false;
            }

            else
            {
                iconRenderer.enabled = true;
                iconRenderer.sprite = inventoriable.Icon;

                countRenderer.enabled = true;
                countRenderer.text = count.ToString();
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            transform.localScale = Vector3.one * 1.25f;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            transform.localScale = Vector3.one;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {

        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            transform.position = startPosition;

            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);

            if (results.Count > 0)
            {
                foreach (var item in results)
                {
                    if (item.gameObject.TryGetComponent(out SocketHUD otherSocket))
                    {
                        if (otherSocket == this) continue;




                    }
                }
            }
        }
    }
}