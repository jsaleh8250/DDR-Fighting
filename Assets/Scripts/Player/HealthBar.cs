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
    public static float totalHealth = 1f;
    //public GameObject Coverseq, Coverseqtrans;

    //Health bar for the player 
    void Start()
    {
        totalHealth = maxHealth;
        bar = GetComponent<RectTransform>();
        SetSize(totalHealth);
        
    }

    //If player takes damage the health will decrease from the amount damaged but will not go negative
    public void Damage(float damage)
    {
        if ((totalHealth -= damage)>= 0f)
        {
            totalHealth -= damage;
        }
        else
        {
            totalHealth = 0f;
            SceneManager.LoadScene(levelName);
            //Coverseq.SetActive(false);
            //Coverseqtrans.SetActive(false);

        }
        SetSize(totalHealth);
    }

    public void SetSize(float size)
    {
        bar.localScale = new Vector3(size, 1f);
    }
}
