using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

//This is where all the score it kept of hitting the note perfectly or missing. Keeps track of how many enmies where killed.
public class ScoreHandler : MonoBehaviour
{
    //public TextMeshProUGUI ScoreText;
    //public TextMeshProUGUI MultiText;
    //public GameObject next;

    public static ScoreHandler instance;

    public static int currentScore;
    int scorePerNote = 100;
    int ScorePerGoodNote = 55;
    int ScorePerPerfectNote = 150;

    public static int missedHits;
    public static int normalHits;
    public static int goodHits;
    public static int perfectHits;

    public static int combo;
   
    public static bool missedNote = false;

    public void Start()
    {
        instance = this;
       //ScoreText.text = "Score: 0";
        //next.SetActive(false);
    }

    public void Awake()
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
        }
        
        /*if(currentScore > 10000)
        {
            next.SetActive(true);
        } */
        
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
        
              
        //MultiText.SetText("Multiplier: x" + combo);
        //ScoreText.SetText("Score: " + currentScore);
     }

    public void NormalHit()
    {
        currentScore += scorePerNote;
        NoteHit();
        
        Debug.Log(normalHits++);
    }

    public void GoodHit()
    {
        currentScore += ScorePerGoodNote;
        NoteHit();

        Debug.Log(goodHits++);
    }

    public void PerfectHit()
    {
        currentScore += ScorePerPerfectNote;
        NoteHit();
        
        Debug.Log(perfectHits++);
    }

    public void NoteMissed()
    {
       missedNote = false;
       missedHits++;
    }

}