using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemySpawnPoint
{
    public Vector3 position;
    // You can add more properties here if needed, such as rotation or enemy type
}

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Reference to your enemy prefab
    public EnemySpawnPoint[] spawnPoints; // Array of spawn points

    public void SpawnEnemies()
    {
        // Loop through all spawn points
        foreach (EnemySpawnPoint spawnPoint in spawnPoints)
        {
            // Instantiate the enemy prefab at the spawn point's position
            Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}


