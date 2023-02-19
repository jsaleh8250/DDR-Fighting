using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Results : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI MultiText;
    private static int score;
    //private static int Multi;
   

    //Will get score from other scenes and transfer the desire scene
    void Update()
    {
        //score = ScoreHandler.currentScore;
        //Multi = ScoreHandler.combo;
        score = BattleMode.count;
        ScoreText.text = "Score: " + score;
        //MultiText.text = "Multiplier: x" + Multi;
    }
}
