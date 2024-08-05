using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAcross : MonoBehaviour
{
    private float leftEdge;
    public float speed = 5f;
    public float acceleration = 1f; // The rate at which speed increases over time
    public float maxSpeed = 20f; // The maximum speed limit

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 10f;
    }

    private void Update()
    {
        // Increase speed over time
        speed += acceleration * Time.deltaTime;

        // Clamp the speed to the maximum speed limit
        speed = Mathf.Min(speed, maxSpeed);

        // Move the object to the left
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Destroy the object if it goes off-screen
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}
