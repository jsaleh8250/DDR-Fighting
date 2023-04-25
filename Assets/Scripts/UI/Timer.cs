using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

//Timer script for the amount of time for player to complete battle sequence 
public class Timer : MonoBehaviour
{
    public float TimeLeft;
    public bool TimerOn = false;
    public HealthBar healthBar;
    public TextMeshProUGUI Timertext;
    public GameObject player;
    Image TimerBar;
    public float maxTime = 8f;
    
    void Start()
    {
        
        TimerOn = true;
        TimerBar = GetComponent<Image>();
        TimeLeft = maxTime;
    }
    //When the timer is enabled in battle sequence it will start and when not enabled the timer will stop and reset 
    void Update()
    {
        if (TimerOn)
        {
            TimerTicking();
        }
        else
        {
            ResetTimer();
        }
        if (this.enabled)
        {
            this.enabled = true;
        }
        else
        {
            this.enabled = false;
        }
        
    }
    void OnDisable()
    {
        TimerOn = false;
    }

    void OnEnable()
    {

    }


    void TimerTicking()
    {
        if (GameManager.inBattleMode == true)
        {
            if (TimeLeft >= 0)
            {
                TimerOn = true;
                TimeLeft -= Time.deltaTime;
                TimerBar.fillAmount = TimeLeft / maxTime;
                //updateTime(TimeLeft);
            }
            else
            {
                if (BattleMode.firstTry)
                {
                    GameManager.inDanceSequence = true;
                }
                else 
                {
                    TimeLeft = 0;
                    TimerOn = false;
                    healthBar.Damage(0.3f);
                    GameManager.inCoverMode = true;
                    ResetTimer();
                }
            }

        }
        else
        {
            TimeLeft = 0;
            TimerOn = false;
        }
    }

  public void ResetTimer()
    {
        TimerOn = true;
        TimerBar = GetComponent<Image>();
        TimeLeft = maxTime;
    }

    void updateTime(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        Timertext.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
     
   
}
