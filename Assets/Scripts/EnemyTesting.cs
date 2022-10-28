using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTesting : EnemyStateBehaviour
{
    CircleCollider2D circleCollider;
    GameObject closeEnemy;

    public bool damageRange;

    private void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();

    }

    void Update()
    {
        base.Update();

        CheckForEnemies();

        if (damageRange && GameManager.isPressed)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)

    {
        if (col.gameObject == playerRef)
        {
            CURRENT_STATE = EnemyState.chase;
            circleCollider.enabled = false;
            damageRange = true;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject == playerRef)
        {
            CURRENT_STATE = EnemyState.attacking;
        }
        else
        {
            CURRENT_STATE = EnemyState.chase;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        CURRENT_STATE = EnemyState.chase;
    }

    void CheckForEnemies()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, 2, 0);
        if (enemies.Length > 2)
        {
            Debug.Log("There are Enemies!");

        }




    }
}
