using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class Clock : MonoBehaviour

{
    public float timeRunning = 0; 
    public bool Running = true; 
    public TMP_Text timeText; 
    // Start is called before the first frame update
    void Start()
    {
        Running = true; 
        timeText.enableAutoSizing = true;
        timeText.fontSizeMin = 10;  
        timeText.fontSizeMax = 200; 
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Running){
            if(timeRunning >= 0){
                timeRunning += Time.deltaTime; 
                Display(timeRunning);
            }
        }
    }
    void Display(float timeDisplay){
        timeDisplay += 1; 
        float minutes = Mathf.FloorToInt (timeDisplay/60);
        float seconds = Mathf.FloorToInt (timeDisplay%60);
        timeText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
