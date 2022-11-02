using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Hitpoints;
    public float MaxHitpoints = 5f;
    public EnemyHealthBar Healthbar;

    public bool damageRange;
    public bool canAttack = false;
    public float enemyCooldown = 5f;

    public Transform player;
    public float speed;
    private float distance;
    public float stoppingDis;

    //Anim
    Animator enemyAnim;
    private string currentState;

    void Start()
    {
        Hitpoints = MaxHitpoints;
        //Healthbar.SetHealth(Hitpoints, MaxHitpoints);
        player = GameObject.FindGameObjectWithTag("Player").transform;

        enemyAnim = GetComponent<Animator>();


    }

    public void Update()
    {

           distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;
            direction.Normalize();

        //Debug.Log("Moving");
        ChangingAnim("Walking");

        //If at a distance from player it will stop moving towards player
        if (Vector2.Distance(transform.position, player.position) > stoppingDis)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.position.x, transform.position.y), speed * Time.deltaTime);

            //Debug.Log("Stopping");
        }
        //If in the damage range and arrow is pressed enemy will take damage
        if (damageRange && GameManager.isPressed)
        {
            ChangingAnim("Injured");
            TakeDamage(5);
                Debug.Log("Enemy Damaged" + Hitpoints);
        }


        if (damageRange && !canAttack)
        {
            StartCoroutine(AttackCooldown(enemyCooldown));
            GameObject.Find("Health Bar Bar").GetComponent<HealthBar>().Damage(.05f);

            Debug.Log("Damaging Player");
            ChangingAnim("Attack");
        }
    }

    void ChangingAnim(string newState)
    {
        if (currentState == newState) return;
        enemyAnim.Play(newState);
        currentState = newState;
    }

    //If all the enemy health is gone it will be deleted
    public void TakeDamage(float damage)
    {
        Hitpoints -= damage;
        Healthbar.SetHealth(Hitpoints, MaxHitpoints);
        
        if (Hitpoints <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        StartCoroutine(DeathTimer(5f));
    }


    /*

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "HitBox")
        {
            damageRange = false;
        }
    }
    */
    public void OnTriggerStay2D(UnityEngine.Collider2D collision)
    {
        if (collision.tag == "HitBox")
        {
            damageRange = true;

        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "HitBox")
        {
            damageRange = true;

        }
    }

    IEnumerator AttackCooldown(float coolDown)
    {
        canAttack = false;
        yield return new WaitForSeconds(coolDown);
        canAttack = true;
    }

    IEnumerator DeathTimer(float time)
    {
        ChangingAnim("Death");
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

}
