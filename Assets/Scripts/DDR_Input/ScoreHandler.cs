using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI MultiText;
    public GameObject next;

    public static ScoreHandler instance;

    public static int currentScore;
    int scorePerNote = 100;
    int ScorePerGoodNote = 55;
    int ScorePerPerfectNote = 150;
    int Enemydead = 200;

    public static int combo;
   
    public static bool missedNote = false;

    private void Awake()
    {
        instance = this;
        ScoreText.text = "Score: 0";
        next.SetActive(false);
    }

    public void Update()
    {
        //Debug.Log(Note.isPressed);
        if (GameManager.isPressed)
        {
            NormalHit();
            GoodHit();
            PerfectHit();
                       
        }

        if (missedNote)
        {
            NoteMissed();
            combo = 0;
            Debug.Log("Notemissed");
        }
        
        if(currentScore > 0)
        {
            next.SetActive(true);
        }
        
    }

    public void NoteHit()
    {
        if (combo == 0)
        {
            combo = 1;
        }
        else
        {
            combo += 1;
        }
        
              
        MultiText.SetText("Multiplier: x" + combo);
        ScoreText.SetText("Score: " + currentScore);
     }

    public void NormalHit()
    {
        currentScore += scorePerNote * combo;
        NoteHit();
    }

    public void GoodHit()
    {
        currentScore += ScorePerGoodNote * combo;
        NoteHit();
    }

    public void PerfectHit()
    {
        currentScore += ScorePerPerfectNote * combo;
        NoteHit();
    }
     public void EnemyKilled()
    {
        currentScore += Enemydead;
        Debug.Log("Points");
    }

    public void NoteMissed()
    {
       missedNote = false;
    }

}
