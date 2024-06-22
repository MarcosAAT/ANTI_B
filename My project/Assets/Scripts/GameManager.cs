using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
   // public Player player; 
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI pauseScoreText;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI bestScoreTextPauseMenu;


    private int score;
    public int highScore;
    public GameObject gameOverCanvas;
    public GameObject pauseMenuCanvas;
    public GameObject gameCanvas;


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

    public void IncreseScore(){
        score++; 
        scoreText.text =  score.ToString();
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

}
