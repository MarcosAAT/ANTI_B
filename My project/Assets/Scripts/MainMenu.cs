using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public int selectedLevel = 1;

    public Image birdImage;
    public Image birdImageTutorial;
    public Image birdImageTutorial_2;
    public Image birdImageTutorial_3;
    public Image birdImageTutorial_4;
    public Image arrowImage;


    public TextMeshProUGUI ANTIText;

    private int spriteIndex;
    public Sprite[] sprites;

    public float moveDistance = 1.0f; 
    public float moveSpeed = 1.0f;
    public float animationSpeed = 0.45f;

    public TextMeshProUGUI highScoreValue;


    private Vector3 startPosition;

    private void Start()
    {
        InvokeRepeating(nameof(AnimateBirdSprite), animationSpeed, animationSpeed);

        startPosition = birdImage.transform.position;

        highScoreValue.text = PlayerPrefs.GetInt("Highscore").ToString();

        StartCoroutine(GrowShrinkFont());

    }

    void Update()
    {
        // Bird Annimation up and down
        Vector3 newPosition = startPosition + Vector3.up * Mathf.Sin(Time.time * moveSpeed) * moveDistance;
        birdImage.transform.position = newPosition;

    }

    private void AnimateBirdSprite()
    {
        
        spriteIndex++;

        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }


        birdImage.sprite = sprites[spriteIndex];
        birdImageTutorial.sprite = sprites[spriteIndex];
        birdImageTutorial_2.sprite = sprites[spriteIndex];
        birdImageTutorial_3.sprite = sprites[spriteIndex];
        birdImageTutorial_4.sprite = sprites[spriteIndex];

    }
    public void PlayGame()
    {
        SceneManager.LoadScene(selectedLevel);
    }

    public void ResetHighscore()
    {
        PlayerPrefs.DeleteKey("Highscore");
        highScoreValue.text = PlayerPrefs.GetInt("Highscore").ToString();

    }

    private IEnumerator GrowShrinkFont()
    {
        float duration = 2f; // Duration for grow and shrink
        float halfDuration = duration / 2f;
        int minFontSize = 150;
        int maxFontSize = 220;

        while (true)
        {
            // Grow font size
            float elapsed = 0f;
            while (elapsed < halfDuration)
            {
                ANTIText.fontSize = Mathf.Lerp(minFontSize, maxFontSize, elapsed / halfDuration);
                elapsed += Time.deltaTime;
                yield return null;
            }

            // Ensure max size is set
            ANTIText.fontSize = maxFontSize;

            // Shrink font size
            elapsed = 0f;
            while (elapsed < halfDuration)
            {
                ANTIText.fontSize = Mathf.Lerp(maxFontSize, minFontSize, elapsed / halfDuration);
                elapsed += Time.deltaTime;
                yield return null;
            }

            // Ensure min size is set
            ANTIText.fontSize = minFontSize;
        }
    }


}
