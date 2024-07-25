using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyANTI : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.IncreaseANTI();
            gameManager.AntiPickedUp();
            gameManager.ReduceGravity(); 
            Destroy(gameObject);
        }
    }
}
