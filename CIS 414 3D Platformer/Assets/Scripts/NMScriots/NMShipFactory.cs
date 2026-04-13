using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static NMShipType;

public class NMShipFactory : MonoBehaviour
{
    [SerializeField] private NMBaseShip NMFastShip;
    [SerializeField] private NMBaseShip NMSlowShip;
    [SerializeField] private NMBaseShip NMLaserShip;
    public NMBaseShip CreateShip(ShipType type, Vector3 spawnPosition, Transform target)
    {
        NMBaseShip prefabToSpawn = null;

        switch (type)
        {
            case ShipType.Fast:
                prefabToSpawn = NMFastShip;
                break;

            case ShipType.Slow:
                prefabToSpawn = NMSlowShip;
                break;

            case ShipType.Laser:
                prefabToSpawn = NMLaserShip;
                break;
        }

        if (prefabToSpawn == null)
        {
            Debug.LogWarning("No ship prefab assigned for type: " + type);
            return null;
        }

        NMBaseShip newShip = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        newShip.SetTarget(target);
        return newShip;
    }
}