using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAcross : MonoBehaviour
{
    private float leftEdge;
    private GameManager gameManager;

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 10f;
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (gameManager != null)
        {
            // Get the speed from the GameManager
            float moveSpeed = gameManager.GetCurrentSpeed();

            // Move the object to the left
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }

        // Destroy the object if it goes off-screen
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}
