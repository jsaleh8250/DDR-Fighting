using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAI : MonoBehaviour
{
    public Transform player;
    public Transform other;
    public float speed;
    private float distance;
    public float stoppingDist;
    //public float enemystoppingDist;

    //Anim
    Animator enemyAnim;
    private string currentState;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyAnim = GetComponent<Animator>();
        //other = GameObject.FindGameObjectWithTag("BattleSeq").transform;
        //other = GameObject.Find("Simple AI(1)").transform;
    }

    void Update()
    {
        EnemyMovement();
       // other = GameObject.Find("Simple AI").transform;
    }

    void EnemyMovement()
    {
        //Jenna Saleh
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
       
        //if (Vector2.Distance(transform.position, other.position) > enemystoppingDist)
       // { 
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

       // }
       //else {
            ChangingAnim("Idle");
       // }
    }


    void ChangingAnim(string newState)
    {
        if (currentState == newState) return;
        enemyAnim.Play(newState);
        currentState = newState;
    }
   
}
