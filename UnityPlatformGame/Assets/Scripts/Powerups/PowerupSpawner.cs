using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        
    }

    // Public variables to reference the power-up prefabs
    public GameObject jumpPowerupPrefab;
    public GameObject speedPowerupPrefab;

    // Define separate spawn locations for jump and speed power-ups using Vector3 coordinates
    public Vector3[] jumpPowerupSpawnPoints;
    public Vector3[] speedPowerupSpawnPoints;

    private void Start()
    {
        // Spawn power-ups at the beginning of the game
        SpawnPowerups();
    }

    private void SpawnPowerups()
    {
        // Spawn jump power-ups at specified spawn points
        foreach (Vector3 spawnPoint in jumpPowerupSpawnPoints)
        {
            Instantiate(jumpPowerupPrefab, spawnPoint, Quaternion.identity);
        }

        // Spawn speed power-ups at specified spawn points
        foreach (Vector3 spawnPoint in speedPowerupSpawnPoints)
        {
            Instantiate(speedPowerupPrefab, spawnPoint, Quaternion.identity);
        }
    }
}
