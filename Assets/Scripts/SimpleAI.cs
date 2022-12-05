using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAI : MonoBehaviour
{
    public Transform player;
    public float speed;
    private float distance;
    public float stoppingDist;

    //Anim
    Animator enemyAnim;
    private string currentState;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyAnim = GetComponent<Animator>();
    }

    void Update()
    {
        EnemyMovement();
    }

    void EnemyMovement()
    {
        //Jenna Saleh
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

        //If at a distance from player it will stop moving towards player
        if (Vector2.Distance(transform.position, player.position) > stoppingDist)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.position.x, transform.position.y), speed * Time.deltaTime);
            ChangingAnim("Walking");

        }
        else
        {
            ChangingAnim("Idle");
        }

    }

    void ChangingAnim(string newState)
    {
        if (currentState == newState) return;
        enemyAnim.Play(newState);
        currentState = newState;
    }

}
