using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEditorInternal;

public class Generate : MonoBehaviour
{
    public GameObject StartPrefab;
    public GameObject EndPrefab;
    public List<GameObject> PathsPrefabs;
    public List<GameObject> Prepatsvia;
    public int MinPaths = 5;
    public int MaxPaths = 10;
    public float PrepatsviaShans = 0.2f;

    private void Start()
    {
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        Vector3 startPos = new Vector3(-10f, 0f, 0f);
        Instantiate(StartPrefab, startPos, Quaternion.identity);
        int platformsCount = Random.Range(MinPaths, MaxPaths + 1);

        for (int i = 0; i < platformsCount; i++)
        {
            GameObject selestedPaths = PathsPrefabs[Random.Range(0, PathsPrefabs.Count)];

            float xOffset = Random.Range(-5f, 5f);

            float yOffset = Random.Range(-2f, 2f);

            Vector3 nextPos = new Vector3(startPos.x + xOffset, startPos.y + yOffset, 0f);

            Instantiate(selestedPaths, nextPos, Quaternion.identity);

            PlacePrepatsvia(nextPos);
        }

        Instantiate(EndPrefab, startPos, Quaternion.identity);
    }

    private void PlacePrepatsvia(Vector3 pos)
    {
        foreach(GameObject prepatstvia in Prepatsvia)
        {
            if(Random.value <= PrepatsviaShans)
            {
                float randomRotation = Random.Range(0f, 360f);
                float xOffset = Random.Range(-3f, 3f);         
                float yOffset = Random.Range(-3f, 3f);

                Vector3 finalPosition = pos + new Vector3(xOffset, yOffset, 0f);

                Quaternion rotation = Quaternion.Euler(0f, 0f, randomRotation); 

                Instantiate(prepatstvia, finalPosition, rotation);
            }
        }
    }
}