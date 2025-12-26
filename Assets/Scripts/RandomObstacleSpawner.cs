using System.Collections.Generic;
using UnityEngine;

public class RandomObstacleSpawner : MonoBehaviour
{
    public GameObject[] PrefabsToSpawn;
    public Transform CenterPoint; 
    public int NumberOfObjects = 10; 
    public float MinDistance = 1f; 
    public float MaxDistance = 10f; 
    public float MinSeparationDistance = 2f; 
    public int MaxPlacementAttempts = 100;

    List<Vector3> spawnedPositions = new List<Vector3>();

    void Start()
    {
        SpawnPrefabs();
    }

    private void SpawnPrefabs()
    {
        for (int i = 0; i < NumberOfObjects; i++)
        {
            GameObject randomPrefab = PrefabsToSpawn[Random.Range(0, PrefabsToSpawn.Length)];
            Vector3 position = GetValidPosition();
            if (position != Vector3.zero)
            {
                Instantiate(randomPrefab, position, Quaternion.identity);
                spawnedPositions.Add(position);
            }
        }
    }

    private Vector3 GetValidPosition()
    {
        for (int attempt = 0; attempt < MaxPlacementAttempts; attempt++)
        {
            float angle = Random.Range(0f, 360f);
            float radius = Random.Range(MinDistance, MaxDistance);
            Vector3 candidatePosition = new Vector3(
                CenterPoint.position.x + radius * Mathf.Cos(angle * Mathf.Deg2Rad),
                CenterPoint.position.y + radius * Mathf.Sin(angle * Mathf.Deg2Rad),
                -1);
            if (IsValidPosition(candidatePosition))
                return candidatePosition;
        }
        Debug.LogWarning("Could not find a valid position after multiple attempts.");
        return Vector3.zero;
    }

    private bool IsValidPosition(Vector3 pos)
    {
        foreach (var existingPos in spawnedPositions)
        {
            if (Vector3.Distance(pos, existingPos) < MinSeparationDistance)
                return false;
        }
        return true;
    }
}