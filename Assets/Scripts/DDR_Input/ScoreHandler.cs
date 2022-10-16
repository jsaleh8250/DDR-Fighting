using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreHandler : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI MultiText;

    int currentScore;
    int scorePerNote = 100;
    int ScorePerGoodNote = 125;
    int ScorePerPerfectNote = 150;

    public static int currentMultiplier = 0;
    public static int multiplierTracker;
    public int[] multiplierThresholds;

    public static bool missedNote = false;

    private void Awake()
    {
        currentMultiplier = 1;
    }

    public void Update()
    {
        //Debug.Log(Note.isPressed);
        if (GameManager.isPressed)
        {
            NormalHit();

            /*
            if (GameObject.FindWithTag("Note").transform.position.y <= 1.7f)
            {
                PerfectHit();
                Debug.Log("Perfect Hit");
            }
            else if (GameObject.FindWithTag("Note").transform.position.y < 1.6f)
            {
                GoodHit();
                Debug.Log("Good Hit");
            }
            else if (GameObject.FindWithTag("Note").transform.position.y < 1.5f)
            {
                NormalHit();
                Debug.Log("Normal Hit");
            }
            */
        }

        if (missedNote)
        {
            NoteMissed();
        }

        //Debug.Log(GameObject.FindWithTag("Note").transform.position.y);
    }

    public void NoteHit()
    {
        if (currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;

            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        MultiText.SetText("Multiplier: x" + currentMultiplier);

        //currentScore += scorePerNote * currentMultiplier;
        ScoreText.SetText("Score: " + currentScore);
    }

    public void NormalHit()
    {
        currentScore += scorePerNote * currentMultiplier;
        NoteHit();
    }

    public void GoodHit()
    {
        currentScore += ScorePerGoodNote * currentMultiplier;
        NoteHit();
    }

    public void PerfectHit()
    {
        currentScore += ScorePerPerfectNote * currentMultiplier;
        NoteHit();
    }

    public void NoteMissed()
    {
        currentMultiplier = 1;
        multiplierTracker = 0;

        MultiText.SetText("Multiplier: x" + currentMultiplier);

        missedNote = false;
    }
}
