using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateBehaviour : MonoBehaviour
{
    //Variables
    bool isFacingPlayer,inRange, isAttacking, isWalking;

    Animator enemyAnim;
    SpriteRenderer enemySprite;

    float sightRange = 5;
    int playerInput;

    public float speed;

    private string currentState;


    public enum EnemyState
    { 
        initialize,
        idle,
        seePlayer,
        chase,
        attacking,
        retreat,
        dead
    }

    public EnemyState CURRENT_STATE;

    public GameObject playerRef;

    private void Start()
    {
        CURRENT_STATE = EnemyState.initialize;

        enemySprite = GetComponent<SpriteRenderer>();
        enemyAnim = GetComponent<Animator>();
    }

    public virtual void Update()
    {
        switch (CURRENT_STATE)
        {
            case EnemyState.initialize:
                playerRef = GameObject.FindGameObjectWithTag("Player");
                CURRENT_STATE = EnemyState.idle;
                break;
            case EnemyState.idle:
                Idle();
                break;
            case EnemyState.seePlayer:
                SeenPlayer();
                break;
            case EnemyState.chase:
                Chasing();
                break;
            case EnemyState.attacking:
                Attacking();
                break;
            case EnemyState.retreat:
                Retreating();
                break;
            default:
                break;
        }
    }

    public virtual void Idle()
    {
        EnemyCurrentPos();
        FaceThePlayer();
        inRange = true;
        isWalking = false;
        isAttacking = false;
        //ChangingAnim("Idle");
    }

    public virtual void SeenPlayer()
    {
        inRange = true;
        isWalking = false;
        isAttacking = false;
        //ChangingAnim("Walking");

    }
    public virtual void Chasing()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerRef.transform.position, speed * Time.deltaTime);

        FaceThePlayer();
        isAttacking = false;
        inRange = true;
        isWalking = true;
        //ChangingAnim("Running");

    }

    public virtual void Attacking()
    {
        EnemyCurrentPos();
        isAttacking = true;
        inRange = true;
        isWalking = false;
        //ChangingAnim("Fight_1");
    }

    public virtual void Retreating()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerRef.transform.position, -speed * Time.deltaTime);
        RunAwayFromPlayer();
        isAttacking = false;
        inRange = false;
        isWalking = true;
        //ChangingAnim("Walking");
    }

    public virtual void Dead()
    {
        ResetBools();
        //ChangingAnim("Dead");
    }

    //Enemy Actions\\

    void RunAwayFromPlayer()
    {
        float localOffset = transform.localPosition.x - playerRef.transform.localPosition.x;
        if (localOffset > 0 && !isFacingPlayer)
        {
            Flip();
        }
        else if (localOffset < 0 && isFacingPlayer)
        {
            Flip();
        }

    }

    //Enemy Anim\\
    void ChangingAnim(string newState)
    {
        if (currentState == newState) return;
        enemyAnim.Play(newState);
        currentState = newState;
    }

    //Enemy Pos\\
    void EnemyCurrentPos()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y);
    }

    //Resetting Bools\\
    void ResetBools()
    {
        isAttacking = false;
        inRange = false;
        isWalking = false;
    }

    //Enemy Sprite\\
    void Flip()
    {
        isFacingPlayer = !isFacingPlayer;
        Vector3 theScale = this.transform.localScale;
        theScale.x *= -1;
        this.transform.localScale = theScale;
    }
    void PosFront()
    {
        enemySprite.transform.localScale.Equals(1);
    }
    void PosBehind()
    {
        enemySprite.transform.localScale.Equals(-1);
    }

    void ChangeEnemySortingLayer()
    {
        enemySprite.sortingOrder = (int)(transform.position.y * -2);
    }

    void FaceThePlayer()
    {
        float localOffset = transform.localPosition.x - playerRef.transform.localPosition.x;
        if (localOffset < 0 && !isFacingPlayer)
        {
            Flip();
        }
        else if (localOffset > 0 && isFacingPlayer)
        {
            Flip();
        }

    }

}
