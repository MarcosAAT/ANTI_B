using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryWine : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other){
       
        if(other.gameObject.tag == "Player"){
            FindObjectOfType<GameManager>().DecreaseScore();
            Destroy(gameObject);
        }
    }
}
