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
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score = ScoreHandler.currentScore;
        //Multi = ScoreHandler.combo;
        ScoreText.text = "Score: " + score;
        //MultiText.text = "Multiplier: x" + Multi;
    }
}
