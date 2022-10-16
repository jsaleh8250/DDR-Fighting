using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Hitpoints;
    public float MaxHitpoints = 5f;
    public EnemyHealthBar Healthbar;

    public bool damageRange;


    public Transform player;
    public float speed;
    private float distance;
    public float stoppingDis;

    void Start()
    {
        Hitpoints = MaxHitpoints;
        Healthbar.SetHealth(Hitpoints, MaxHitpoints);
    }

    private void Update()
    {       
        
           distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;
            direction.Normalize();
        if (Vector2.Distance(transform.position, player.position) > stoppingDis)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.position.x, transform.position.y), speed * Time.deltaTime);
        }
        if (damageRange && GameManager.isPressed)
            {
                TakeDamage(5);
                Debug.Log("Enemy Damaged");
                Debug.Log(GameManager.isPressed);
            }
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

    public void OnTriggerStay2D(UnityEngine.Collider2D collision)
    {
        if (collision.tag == "HitBox")
        {
            damageRange = true;

        }
    }

}
