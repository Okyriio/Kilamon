using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{    
    // The amount of time between each spawn.
    private const float SpawnRateSeconds = 6f;
    // The amount of time before spawning starts.
    private const float SpawnDelaySeconds = 2f;
    [SerializeField] GameObject[] enemiesPrefabs;
    private Vector3 _enemySpawnPosition = Vector3.zero;
    void Start ()
    {
        // Start calling the Spawn function repeatedly after a delay.
        InvokeRepeating("Spawn", SpawnDelaySeconds, SpawnRateSeconds);
    }
    void Spawn ()
    {
        //Instantiate a random enemy.
        int enemyIndex = Random.Range(0, enemiesPrefabs.Length);
        Instantiate(enemiesPrefabs[enemyIndex], _enemySpawnPosition, transform.rotation);
    }
}

