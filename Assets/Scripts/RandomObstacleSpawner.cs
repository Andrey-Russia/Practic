using System.Collections.Generic;
using UnityEngine;

public class RandomObstacleSpawner : MonoBehaviour
{
    public GameObject[] ObstaclePrefabs;
    public Transform RoomTransform;
    public float ObstacleSpacing = 10;
    public int ObstaclesCount = 25;

    private void Start()
    {
        SpriteRenderer spriteRenderer = RoomTransform.GetComponent<SpriteRenderer>();

        if (spriteRenderer != null && spriteRenderer.sprite != null)
        {
            float roomWight = spriteRenderer.sprite.bounds.size.x;
            float roomHeight = spriteRenderer.sprite.bounds.size.y;

            SpawnObstacles(roomWight, roomHeight);
        }
    }

    private void SpawnObstacles(float roomWight, float roomHeight)
    {
        List<Vector2> possiblePositions = GeneratePossiblePositions(roomWight, roomHeight);
        ShuffleList(possiblePositions);

        for (int i = 0; i < Mathf.Min(ObstaclesCount, possiblePositions.Count); i++)
        {
            Vector2 positon = possiblePositions[i];
            int randomPrefabIndex = Random.Range(0, ObstaclePrefabs.Length);
            Instantiate(ObstaclePrefabs[randomPrefabIndex], positon, Quaternion.identity);
        }
    }

    private List<Vector2> GeneratePossiblePositions(float roomWidth, float roomHeight)
    {
        List<Vector2> positions = new List<Vector2>();

        for (float x = -roomWidth / 2 + ObstacleSpacing; x <= roomWidth / 2 - ObstacleSpacing; x += ObstacleSpacing * 2)
        {
            for (float y = -roomHeight / 2 + ObstacleSpacing; y <= roomHeight / 2 - ObstacleSpacing; y +=ObstacleSpacing * 2)
            {
                positions.Add(new Vector2(x, y));
            }
        }

        return positions;
    }

    private void ShuffleList<T>(IList<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int r = Random.Range(i, list.Count);
            T temp = list[r];
            list[r] = list[i];
            list[i] = temp;
        }
    }
}