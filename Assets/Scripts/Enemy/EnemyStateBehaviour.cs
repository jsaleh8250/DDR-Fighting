using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateBehaviour : MonoBehaviour
{
    //Variables
    public bool isFacingPlayer,inRange, isAttacking, isWalking, isInjured;

    public Animator enemyAnim;
    SpriteRenderer enemySprite;

    float sightRange = 5;
    int playerInput;

    public float speed;

    private string currentState;

    public float Hitpoints;
    public float MaxHitpoints = 5f;



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

    public void Start()
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
            case EnemyState.dead:
                Dead();
                break;
            default:
                break;
        }
    }

    public virtual void Idle()
    {
        ChangingAnim("Idle");
        EnemyCurrentPos();
        FaceThePlayer();
        inRange = true;
        isWalking = false;
        isAttacking = false;
        isInjured = false;
    }

    public virtual void SeenPlayer()
    {
        ChangingAnim("Walking");
        inRange = true;
        isWalking = false;
        isAttacking = false;
        isInjured = false;

    }
    public virtual void Chasing()
    {
        ChangingAnim("Walking");
        transform.position = Vector2.MoveTowards(transform.position, playerRef.transform.position, speed * Time.deltaTime);

        FaceThePlayer();
        isAttacking = false;
        inRange = true;
        isWalking = true;
        isInjured = false;

    }

    public virtual void Attacking()
    {
        ChangingAnim("Attack");
        EnemyCurrentPos();
        isAttacking = true;
        inRange = true;
        isWalking = false;
        isInjured = false;
    }

    public virtual void Retreating()
    {
        ChangingAnim("Walking");
        transform.position = Vector2.MoveTowards(transform.position, playerRef.transform.position, -speed * Time.deltaTime);
        RunAwayFromPlayer();
        isAttacking = false;
        inRange = false;
        isWalking = true;
        isInjured = false;
    }

    public virtual void Dead()
    {
        ChangingAnim("Death");
        ResetBools();
        StartCoroutine(DeathTimer(1));
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
    public void ChangingAnim(string newState)
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
        isInjured = false;
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

    IEnumerator DeathTimer(float time)
    {
        ChangingAnim("Death");
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
        
    }

}
