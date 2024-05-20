using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public int selectedLevel = 1;

    public Image birdImage;
    private int spriteIndex;
    public Sprite[] sprites;

    public float moveDistance = 1.0f; 
    public float moveSpeed = 1.0f;
    public float animationSpeed = 0.45f;

    private Vector3 startPosition;

    private void Start()
    {
        InvokeRepeating(nameof(AnimateBirdSprite), animationSpeed, animationSpeed);

        startPosition = birdImage.transform.position;
    }

    void Update()
    {
        // Bird Annimation up and down
        Vector3 newPosition = startPosition + Vector3.up * Mathf.Sin(Time.time * moveSpeed) * moveDistance;
        birdImage.transform.position = newPosition;
    }

    private void AnimateBirdSprite()
    {
        Debug.Log("calling annimation");
        spriteIndex++;

        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }


        birdImage.sprite = sprites[spriteIndex];

    }
    public void PlayGame()
    {
        SceneManager.LoadScene(selectedLevel);
    }
}
