using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    private RectTransform bar;
    private int nextScene;
    public static float maxHealth = 1f;
    public string levelName;
    public static float totalHealth = 1f;

    //Health bar for the player 
    void Start()
    {
        totalHealth = maxHealth;
        bar = GetComponent<RectTransform>();
        SetSize(totalHealth);

    }

    public void ADD(float add)
    {
        totalHealth += add;
        maxHealth = totalHealth;
        SetSize(totalHealth);

    }


    //If player takes damage the health will decrease from the amount damaged but will not go negative
    public void Damage(float damage)
    {
        if ((totalHealth -= damage) >= 0f)
        {
            totalHealth -= damage;
        }
        else
        {
            totalHealth = 0f;
            GameManager.inBattleMode = false;
            GameManager.inCoverMode = false;

            SceneManager.LoadScene(levelName);

        }
        SetSize(totalHealth);
    }

    public void SetSize(float size)
    {
        bar.localScale = new Vector3(size, 1f);
    }
}
