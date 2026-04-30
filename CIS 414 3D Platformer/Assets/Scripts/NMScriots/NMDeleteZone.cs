using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NMDeleteZone : MonoBehaviour

{
    private void OnTriggerEnter(Collider other)
    {
     
        NMBaseShip ship = other.GetComponentInParent<NMBaseShip>();

        if (ship != null)
        {
            Destroy(ship.gameObject);
        }
    }
}
