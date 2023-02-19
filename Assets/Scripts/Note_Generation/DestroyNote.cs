using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//If note is missed will destroy note and  take player health
public class DestroyNote : MonoBehaviour
{
    public HealthBar healthBar;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Note")
        {
            Destroy(collision.gameObject);

            ScoreHandler.missedNote = true;
            healthBar.Damage(.02f);

        }
    }
}
