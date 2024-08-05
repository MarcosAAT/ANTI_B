using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerYacht : MonoBehaviour
{

    public GameObject prefab;
    private MoveAcross moveAcross;
    public float spawnRate = 10f;
    public float minHeight = -1f;
    public float maxHeight = 5f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void Spawn()
    {
        GameObject yacht = Instantiate(prefab, transform.position, Quaternion.identity);
        yacht.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);

        Vector3 newPosition = yacht.transform.position;
        newPosition.z = -2f;
        yacht.transform.position = newPosition;
    }
}
