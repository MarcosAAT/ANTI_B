using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPlane : MonoBehaviour
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
        GameObject plane = Instantiate(prefab, transform.position, Quaternion.identity);
        plane.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);

    }
}
