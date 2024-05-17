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
    private int score;
    public GameObject gameOverCanvas;

    private void Start()
    {
        gameOverCanvas.SetActive(false);
    }
    public void DecreaseScore(){
        score--; 
        scoreText.text =  score.ToString();
        finalScoreText.text = score.ToString();
    }

    public void IncreseScore(){
        score++; 
        scoreText.text =  score.ToString();
        finalScoreText.text = score.ToString();

    }

    public void Pause(){
        Time.timeScale= 0f;
        //player.enabled= false; 

    }
    public void GameOver(){
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;

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
