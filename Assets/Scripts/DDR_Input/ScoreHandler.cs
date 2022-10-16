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
    int[] multiplierThresholds;

    private void Awake()
    {
        currentMultiplier = 1;
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
}
