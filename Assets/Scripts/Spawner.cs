using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script was inspired in the tutorial: https://gamedevbeginner.com/how-to-spawn-an-object-in-unity-using-instantiate/
// and chat GPT
public class Spawner : MonoBehaviour
{
    private Vector3[] positions;
    private int lastSpawnIndex = -1;

    public GameObject objectToSpawn;

    void Awake()
    {
        InitializePositions();
    }

    // Function to initialize the possible spawn positions
    void InitializePositions()
    {
        positions = new Vector3[]
        {
            new Vector3(6f, 0.5f, 0f),
            new Vector3(5.2f, 0.5f, 3f),
            new Vector3(3f, 0.5f, 5.2f),
            new Vector3(-3f, 0.5f, 5.2f),
            new Vector3(-5.2f, 0.5f, 3f),
            new Vector3(-5.2f, 0.5f, -3f),
            new Vector3(-3f, 0.5f, -5.2f),
            new Vector3(3f, 0.5f, -5.2f),
            new Vector3(5.2f, 0.5f, -3f),
            new Vector3(0f, 0.5f, 6f),
            new Vector3(-6f, 0.5f, 0f),
            new Vector3(0f, 0.5f, -6f)
        };
    }

    void Start()
    {
        SpawnCollectible();
    }

    // Function to spawn a new collectible at a different position
    public void SpawnCollectible()
    {
        if (positions.Length == 0)
        {
            Debug.LogError("No positions defined for spawning collectibles.");
            return;
        }

        // Randomly select a position different from the last one
        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, positions.Length);
        } while (randomIndex == lastSpawnIndex);

        // Use the selected position
        Vector3 spawnPosition = positions[randomIndex];
        InstantiateCollectible(spawnPosition);

        // Update lastSpawnPosition and lastSpawnIndex
        lastSpawnIndex = randomIndex;
    }

    // Function to instantiate a collectible at a given position
    void InstantiateCollectible(Vector3 position)
    {
        Instantiate(objectToSpawn, position, Quaternion.identity);
    }

}
