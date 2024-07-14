using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Player player; 
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI pauseScoreText;

    public int score;
    public GameObject gameOverCanvas;
    public GameObject pauseMenuCanvas;
    public GameObject gameCanvas;

    public int consecutiveAntiCount = 0;
    public bool bonusActive = false;


    private void Start()
    {
        gameOverCanvas.SetActive(false);
    }
    public void DecreaseScore(){
        score--; 
        scoreText.text =  score.ToString();
        finalScoreText.text = score.ToString();
        pauseScoreText.text = score.ToString();

    }

    public void IncreseScore()
    {
        if (bonusActive)
        {
            score += 2; // Double the points during bonus
        }
        else
        {
            score++;
        }

        scoreText.text = score.ToString();
        finalScoreText.text = score.ToString();
        pauseScoreText.text = score.ToString();

        if (score % 10 == 0 && score != 0)
        {
            player.UpdateGravity(score);
        }
    }

    public void Pause(){
        Time.timeScale= 0f;
        //player.enabled= false; 


        pauseMenuCanvas.SetActive(true);

    }

    public void Resume()
    {
        Time.timeScale = 1f;
    }

    public void GameOver(){
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;

        gameCanvas.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;

    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;

    }

    public void ActivateBonus()
    {
        bonusActive = true;
        Invoke(nameof(DeactivateBonus), 10f); // Bonus active for 10 seconds
    }

    private void DeactivateBonus()
    {
        bonusActive = false;
    }

    public void AntiPickedUp()
    {
        consecutiveAntiCount++;
        if (consecutiveAntiCount >= 5)
        {
            ActivateBonus();
            player.ResetGravity();
            consecutiveAntiCount = 0;
        }
    }

 

}
