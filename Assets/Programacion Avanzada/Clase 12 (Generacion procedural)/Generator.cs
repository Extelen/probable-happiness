using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clases.PA2024.PGeneration
{
    public class Generator : MonoBehaviour
    {
        // Variables
        [Header("Settings")]
        [SerializeField] private int generationCount = 1000;

        [Header("References")]
        [SerializeField] private GameObject floor;

        private Dictionary<Vector2, GameObject> floors;

        // Methods
        void Start()
        {
            floors = new Dictionary<Vector2, GameObject>();
            ResetGeneration();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ResetGeneration();
            }
        }

        private void ResetGeneration()
        {
            foreach (var floor in floors.Values)
            {
                Destroy(floor);
            }

            floors.Clear();

            int currentCount = 0;
            Vector2 position = Vector2.zero;

            while (currentCount < generationCount)
            {
                Vector2 direction = Random.Range(0, 4) switch
                {
                    0 => Vector2.up,
                    1 => Vector2.down,
                    2 => Vector2.right,
                    3 => Vector2.left,
                    _ => Vector2.zero
                };

                position += direction;

                for (int x = 0; x < 2; x++)
                {
                    for (int y = 0; y < 2; y++)
                    {
                        if (TryCreateFloor(position + new Vector2(x, y)))
                        {
                            currentCount++;
                        }
                    }
                }
            }
        }

        private bool TryCreateFloor(Vector2 position)
        {
            if (floors.ContainsKey(position))
            {
                return false;
            }

            GameObject obj = Instantiate(floor, position, Quaternion.identity);
            floors.Add(position, obj);
            return true;
        }
    }
}
