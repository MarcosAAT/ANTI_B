using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player; 
    private int score; 

    public void DecreaseScore(){
        score--; 
    }

    public void IncreseScore(){
        score++; 
    }

    public void Pause(){
        Time.timeScale= 0f; 
        //player.enabled= false; 
    }
    public void GameOver(){
        Pause(); 
    }
}
