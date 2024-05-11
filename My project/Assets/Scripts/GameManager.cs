using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
   // public Player player; 
    public TextMeshProUGUI scoreText;
    private int score; 

    public void DecreaseScore(){
        score--; 
        scoreText.text =  score.ToString();
    }

    public void IncreseScore(){
        score++; 
        scoreText.text =  score.ToString();
    }

    public void Pause(){
        Time.timeScale= 0f; 
        //player.enabled= false; 
    }
    public void GameOver(){
        Pause(); 
    }
}
