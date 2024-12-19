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
        public IInventoriable Inventoriable { get; private set; }
        public int Count { get; private set; }

        // Methods
        /// <summary>
        /// Start is called on the frame when a script is enabled just before
        /// any of the Update methods is called the first time.
        /// </summary>
        void OnEnable()
        {
            startPosition = transform.position;
        }

        public void SetScriptable(IInventoriable inventoriable, int count)
        {
            if (inventoriable == null)
            {
                iconRenderer.enabled = false;
                countRenderer.enabled = false;

                Inventoriable = null;
                Count = 0;
            }

            else
            {
                iconRenderer.enabled = true;
                iconRenderer.sprite = inventoriable.Icon;

                countRenderer.enabled = true;
                countRenderer.text = count.ToString();

                Inventoriable = inventoriable;
                Count = count;
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            iconRenderer.transform.localScale = Vector3.one * 1.25f;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            iconRenderer.transform.localScale = Vector3.one;
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

                        IInventoriable otherInventoriable = otherSocket.Inventoriable;
                        int otherCount = otherSocket.Count;

                        otherSocket.SetScriptable(Inventoriable, Count);
                        SetScriptable(otherInventoriable, otherCount);
                    }
                }
            }
        }
    }
}