using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float TimeLeft;
    public bool TimerOn = false;
    public HealthBar healthBar;
    public TextMeshProUGUI Timertext;
    public GameObject player;
    void Start()
    {
        TimerOn = true;
    }

    void Update()
    {
        if (TimerOn)
        {
            if(TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTime(TimeLeft);
            }
            else
            {
                TimeLeft = 0;
                TimerOn = false;
                healthBar.Damage(0.3f);
                GameManager.inBattleMode = false;
                player.GetComponent<playerMovement>().horizontalSpeed = 5f;
                player.GetComponent<playerMovement>().VerticalSpeed = 5f;
            }
        }
    }

    void updateTime(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        Timertext.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
