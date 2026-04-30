using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static NMShipType;

public class NMShipFactory : MonoBehaviour
{
 
    [SerializeField] private NMBaseShip[] fastShips;
    [SerializeField] private NMBaseShip[] slowShips;
    [SerializeField] private NMBaseShip[] laserShips;

    public NMBaseShip CreateShip(ShipType type, Vector3 spawnPosition, Transform target)
    {
        NMBaseShip prefabToSpawn = GetRandomPrefabByType(type);

        if (prefabToSpawn == null)
        {
            Debug.LogWarning("No ship prefab assigned for type: " + type);
            return null;
        }

        NMBaseShip newShip = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        newShip.SetTarget(target);
        return newShip;
    }

    private NMBaseShip GetRandomPrefabByType(ShipType type)
    {
        NMBaseShip[] selectedArray = null;

        switch (type)
        {
            case ShipType.Fast:
                selectedArray = fastShips;
                break;

            case ShipType.Slow:
                selectedArray = slowShips;
                break;

            case ShipType.Laser:
                selectedArray = laserShips;
                break;
        }

        if (selectedArray == null || selectedArray.Length == 0)
        {
            return null;
        }

        int randomIndex = Random.Range(0, selectedArray.Length);
        return selectedArray[randomIndex];
    }
}