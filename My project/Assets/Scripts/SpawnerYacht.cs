using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerYacht : MonoBehaviour
{
    public GameObject prefab;
    private MoveAcross moveAcross;
    public float minHeight = -1f;
    public float maxHeight = 5f;

    public float minSpawnRate = 5f;
    public float maxSpawnRate = 15f;

    private void OnEnable() //begin first random spawn
    {
        float spawnRate = Random.Range(minSpawnRate, maxSpawnRate);
        Invoke(nameof(Spawn), spawnRate);
    }

    private void Spawn()
    {
        GameObject yacht = Instantiate(prefab, transform.position, Quaternion.identity);
        yacht.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
        Vector3 newPosition = yacht.transform.position;
        newPosition.z = -2f;
        yacht.transform.position = newPosition;

        // Schedule the next random spawn
        float spawnRate = Random.Range(minSpawnRate, maxSpawnRate);
        Invoke(nameof(Spawn), spawnRate);
    }
}
