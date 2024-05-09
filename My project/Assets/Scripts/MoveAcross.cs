using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAcross : MonoBehaviour
{

    private float leftEdge;
  public float speed = 5f; 

  private void Start(){
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x -2f;
  }

  private void Update(){
    transform.position += Vector3.left * speed* Time.deltaTime;

    if(transform.position.x < leftEdge){
        Destroy(gameObject);
    }
  }

 

}
