using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Hitpoints;
    public float MaxHitpoints = 5f;
    public EnemyHealthBar Healthbar;

    public bool damageRange;

    void Start()
    {
        Hitpoints = MaxHitpoints;
        Healthbar.SetHealth(Hitpoints, MaxHitpoints);
    }

    public void TakeDamage(float damage)
    {
        Hitpoints -= damage;
        Healthbar.SetHealth(Hitpoints, MaxHitpoints);
        if (Hitpoints <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "HitBox")
        {
            damageRange = false;
        }
    }

    private void OnTriggerStay2D(UnityEngine.Collider2D collision)
    {
        if (collision.tag == "HitBox")
        {
            damageRange = true;

            if (Note.isPressed)
            {
                TakeDamage(5);
                Debug.Log("Enemy Damaged");
                Debug.Log(Note.isPressed);
                Note.isPressed = false;
            }
        }
    }

}
