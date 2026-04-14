using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace ALScripts.Factory
{
    public class BreachFactory : MonoBehaviour
    {
        [SerializeField] private GameObject breachPrefab;

        public GameObject CreateBreach(Vector3 position)
        {
            if (breachPrefab == null)
            {
                Debug.LogWarning("BreachFactory: No breach prefab assigned.");
                return null;
            }

            return Instantiate(breachPrefab, position, Quaternion.identity);
        }
    }
}