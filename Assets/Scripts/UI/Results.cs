using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Results : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI MultiText;
    public TextMeshProUGUI KilledText;
    private static int score;
    private static int Multi;
    private static int killed;
   

    //Will get score from other scenes and transfer the desire scene
    void Update()
    {
        score = ScoreHandler.currentScore;
        Multi = ScoreHandler.combo;
        killed = BattleMode.count;
        ScoreText.text = "Score: " + score;
        KilledText.text = "Enemies Killed: " + killed;
        MultiText.text = "Notes Hit: " + Multi;
    }
}
