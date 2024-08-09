using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Player player;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI pauseScoreText;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI bestScoreTextPauseMenu;

    public int highScore;
    public int score;
    public GameObject gameOverCanvas;
    public GameObject pauseMenuCanvas;
    public GameObject gameCanvas;
    public int consecutiveAntiCount = 0;
    public bool bonusActive = false;

    // Speed variables
    public float initialSpeed = 5f; // Initial speed for moving objects
    public float acceleration = 0.1f; // Acceleration over time
    public float maxSpeed = 20f; // Maximum speed limit

    private float currentSpeed;

    private void Start()
    {
        gameOverCanvas.SetActive(false);

        highScore = PlayerPrefs.GetInt("Highscore");
        bestScoreTextPauseMenu.text = PlayerPrefs.GetInt("Highscore").ToString();
        bestScoreText.text = PlayerPrefs.GetInt("Highscore").ToString();

        currentSpeed = initialSpeed;
    }

    private void Update()
    {
        // Increase speed over time
        currentSpeed += acceleration * Time.deltaTime;
        // Clamp the speed to the maximum speed limit
        currentSpeed = Mathf.Min(currentSpeed, maxSpeed);

        Debug.Log($"GameManager Update: Current Speed: {currentSpeed}");
    }

    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }

    public void DecreaseScore()
    {
        score--; 
        scoreText.text = score.ToString();
        finalScoreText.text = score.ToString();
        pauseScoreText.text = score.ToString();
    }

    public void IncreseScore()
    {
        if (bonusActive)
        {
            score += 200; // Add 200 points during bonus
        }
        else
        {
            score += 100; // Add 100 points normally
        }

        scoreText.text = score.ToString();
        finalScoreText.text = score.ToString();
        pauseScoreText.text = score.ToString();

        if (score > highScore) // save highscore to player prefs
        {
            highScore = score;
            PlayerPrefs.SetInt("Highscore", highScore);
            bestScoreText.text = PlayerPrefs.GetInt("Highscore").ToString();
            bestScoreTextPauseMenu.text = PlayerPrefs.GetInt("Highscore").ToString();
        }
    }

    public void IncreaseANTI()
    {
        score += 250; // Add 250 points for ANTI

        scoreText.text = score.ToString();
        finalScoreText.text = score.ToString();
        pauseScoreText.text = score.ToString();

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("Highscore", highScore);
            bestScoreText.text = PlayerPrefs.GetInt("Highscore").ToString();
            bestScoreTextPauseMenu.text = PlayerPrefs.GetInt("Highscore").ToString();
        }
    }

    public void Pause() // pause button when pressing settings
    {
        Time.timeScale = 0f;
        pauseMenuCanvas.SetActive(true);
    }

    public void Resume() // resume button
    {
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
        gameCanvas.SetActive(false);
    }

    public void PlayGame() // play again button
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void ReturnMainMenu() // main menu button
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void ActivateBonus()
    {
        bonusActive = true;
        player.Invincibility();
        Invoke(nameof(DeactivateBonus), 10f); // Bonus active for 10 seconds
    }

    private void DeactivateBonus()
    {
        bonusActive = false;
        player.transform.localScale = Vector3.one;
        player.DeactivateInvinsibility();
    }

    public void AntiPickedUp()
    {
        consecutiveAntiCount++;
        if (consecutiveAntiCount >= 5)
        {
            ActivateBonus();
            consecutiveAntiCount = 0;
        }
    }

    public void ReduceGravity()
    {
        player.ReduceGravity(); 
    }

    public void IncreaseGravity()
    {
        player.IncreaseGravity(); 
    }
}
