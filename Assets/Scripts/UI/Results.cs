using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Results : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
   // public TextMeshProUGUI MultiText;
    private static int score;
   // private static int Multi;


    public TextMeshProUGUI KilledText;
    public TextMeshProUGUI MehText;
    public TextMeshProUGUI GoodText;
    public TextMeshProUGUI PerfectText;
    private static int killed;
    private static int meh;
    private static int good;
    private static int perfect;
   

    //Will get score from other scenes and transfer the desire scene
    void Update()
    {   
    
       killed = BattleMode.count; 
       KilledText.text = "Enemies Killed: " + killed;
       meh = ScoreHandler.goodHits;
       good = ScoreHandler.normalHits;
       perfect = ScoreHandler.perfectHits;
       MehText.text = "Meh Hits: " + meh;
       GoodText.text ="Good Hits: " + good;
       PerfectText.text = "Perfect Hits: " + perfect;


        score = ScoreHandler.currentScore;
       // Multi = ScoreHandler.combo;
       ScoreText.text = "Score: " + score;
       //MultiText.text = "Notes Hit: " + Multi;
    }
}
