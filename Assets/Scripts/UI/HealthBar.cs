using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    private RectTransform bar;
    private int nextScene;
    public float maxHealth = 1f;
    public string levelName;

    //Health bar for the player 
    void Start()
    {
        Health.totalHealth = maxHealth;
        bar = GetComponent<RectTransform>();
        SetSize(Health.totalHealth);

    }

    //If player takes damage the health will decrease from the amount damaged but will not go negative
    public void Damage(float damage)
    {
        if ((Health.totalHealth -= damage)>= 0f)
        {
            Health.totalHealth -= damage;
        }
        else
        {
            Health.totalHealth = 0f;
            SceneManager.LoadScene(levelName);

        }
        SetSize(Health.totalHealth);
    }

    public void SetSize(float size)
    {
        bar.localScale = new Vector3(size, 1f);
    }
}
