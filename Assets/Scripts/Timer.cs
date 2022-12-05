using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float TimeLeft;
    public bool TimerOn = false;
    public HealthBar healthBar;
    public TextMeshProUGUI Timertext;
    public GameObject player;
    Image TimerBar;
    public float maxTime = 10f;
    
    void Start()
    {
        TimerOn = true;
        TimerBar = GetComponent<Image>();
        TimeLeft = maxTime;
    }

    void Update()
    {
        if (TimerOn)
        {
            if (GameManager.inBattleMode == true)
            {
                if (TimeLeft > 0)
                {
                    TimerOn = true;
                    TimeLeft -= Time.deltaTime;
                    TimerBar.fillAmount = TimeLeft / maxTime;
                    //updateTime(TimeLeft);
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
            else
            {
               // TimeLeft = 0;
                TimerOn = false;
            }
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
