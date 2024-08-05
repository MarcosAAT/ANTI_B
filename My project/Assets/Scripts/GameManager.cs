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
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI bestScoreTextPauseMenu;



    public int highScore;
    public int score;
    public GameObject gameOverCanvas;
    public GameObject pauseMenuCanvas;
    public GameObject gameCanvas;
    public int consecutiveAntiCount = 0;
    public bool bonusActive = false;



    private void Start()
    {
        gameOverCanvas.SetActive(false);

        highScore = PlayerPrefs.GetInt("Highscore");
        bestScoreTextPauseMenu.text = PlayerPrefs.GetInt("Highscore").ToString();
        bestScoreText.text = PlayerPrefs.GetInt("Highscore").ToString();
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
            score += 200; // Add 200 points during bonus
        }
        else
        {
            score += 100; // Add 100 points normally
        }

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
        //dont know if we are going to keep this or not every 500 points gravity increses i.e it becomes harder to jump
        // Update gravity every 500 points
        // if (score % 500 == 0 && score != 0)
        // {
        //     player.UpdateGravity(score);
        // }
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
        player.transform.localScale = Vector3.one * 2;
        Invoke(nameof(DeactivateBonus), 10f); // Bonus active for 10 seconds
    }

    private void DeactivateBonus()
    {
        bonusActive = false;
        player.transform.localScale = Vector3.one;
    }

    //Eevery time players pick 3 anti in a row a bonus will activate 
    public void AntiPickedUp()
    {
        consecutiveAntiCount++;
        if (consecutiveAntiCount >= 5)
        {
            ActivateBonus();
            //player.ResetGravity();
            consecutiveAntiCount = 0;
        }
    }

    public void ReduceGravity()
    {
        player.ReduceGravity(); 
    }

    public void IncreaseGravity()
    {
        player.IncreaseGravity(); // Assuming you have a method in the Player script to handle gravity increase
    }

}
