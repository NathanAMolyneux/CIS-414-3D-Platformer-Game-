using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static NMShipType;

public class NMShipSpawner : MonoBehaviour
{
    [SerializeField] private NMShipFactory factory;
    //[SerializeField] private ShipType shipTypeToSpawn = ShipType.Fast;

    [Header("Spawn Zone")]
    [SerializeField] private Transform waypointA;
    [SerializeField] private float spawnWidth = 50f;
    [SerializeField] private float spawnHeight = 200f;
    [SerializeField] private float spawnDepth = 200f;
    [SerializeField] private float spawnInterval = 2f;

    [Header("Target")]
    [SerializeField] private Transform deleteZoneTarget;

    private float spawnTimer;

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0f;
            SpawnShip();
        }
    }

    private void SpawnShip()
    {
        if (factory == null || waypointA == null || deleteZoneTarget == null)
        {
            Debug.LogWarning("Missing factory, waypointA, or deleteZoneTarget.");
            return;
        }

        Vector3 spawnPosition = GetRandomSpawnPosition();
        ShipType randomType = (ShipType)Random.Range(0, System.Enum.GetValues(typeof(ShipType)).Length);
        factory.CreateShip(randomType, spawnPosition, deleteZoneTarget);
    }

    private Vector3 GetRandomSpawnPosition()
    {
        float randomX = Random.Range(-spawnWidth * 0.5f, spawnWidth * 0.5f);
        float randomY = Random.Range(-spawnHeight * 0.5f, spawnHeight * 0.5f);
        float randomZ = Random.Range(-spawnDepth * 0.5f, spawnDepth * 0.5f);

        return waypointA.position + new Vector3(randomX, randomY, randomZ);
    }

    private void OnDrawGizmos()
    {
        if (waypointA == null) return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(
            waypointA.position,
            new Vector3(spawnWidth, spawnHeight, spawnDepth)
        );
    }
}
