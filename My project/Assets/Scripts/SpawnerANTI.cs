using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerANTI : MonoBehaviour
{
   
  public GameObject prefab; 
  public float spawnRate = 1f; 
  public float minHeight = -1f; 
  public float maxHeight = 5f; 

  private void OnEnable(){
    InvokeRepeating(nameof(Spawn), spawnRate, spawnRate); 
  }

    private void Disbale(){
        CancelInvoke(nameof(Spawn));
    }
  private void Spawn(){
    GameObject ANTI = Instantiate(prefab, transform.position, Quaternion.identity);
    ANTI.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
  }
}