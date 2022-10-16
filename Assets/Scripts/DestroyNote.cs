using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyNote : MonoBehaviour
{
    public HealthBar healthBar;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Note")
        {
            Destroy(collision.gameObject);

            StarBar.CurrentHealth =  StarBar.CurrentHealth - 10;
            ScoreHandler.currentMultiplier = 1;
            ScoreHandler.multiplierTracker = 0;
            healthBar.Damage(.02f);

        }
    }
}
