using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Enemy testing script to test different actions of the enemy 
public class EnemyTesting : EnemyStateBehaviour
{
    CircleCollider2D circleCollider;
    GameObject closeEnemy;

    public bool damageRange;
    public bool facingRight = false;
    public HealthBar healthBar;

    Rigidbody2D rb;

    private float strength = 120, delay = .15f;

    public AudioSource audioSource;
    public AudioClip[] audioClipArray;

    /*
    void OnDisable()
    {
        Note.Attacking -= Injured;
    }

    void OnEnable()
    {
        Note.Attacking += Injured;
    }
    */

    public void Start()
    {
        Hitpoints = MaxHitpoints;

        circleCollider = GetComponent<CircleCollider2D>();

        enemyAnim = GetComponent<Animator>();

        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        base.Update();

        CheckForEnemies();

        if (playerRef.transform.position.x < gameObject.transform.position.x && facingRight)
            Flip();
        if (playerRef.transform.position.x > gameObject.transform.position.x && !facingRight)
            Flip();


        if (Hitpoints <= 0)
        {
            StartCoroutine(deathAudio());
            CURRENT_STATE = EnemyState.dead;
        }

        if(playerMovement.isFighting)
        {
            if(damageRange)
            {
                Injured(5f);
            }
        }
    }

    AudioClip RandClip()
    {
        return audioClipArray[Random.Range(0, audioClipArray.Length)];
    }


    void Flip()
    {
        facingRight = !facingRight;
        Vector2 tmpScale = gameObject.transform.localScale;
        tmpScale.x *= -1;
        gameObject.transform.localScale = tmpScale;
    }

    public virtual void Injured(float damage)
    {
        ChangingAnim("Injured");

        isAttacking = false;
        inRange = true;
        isWalking = false;
        isInjured = true;

        Hitpoints -= damage;

        rb.AddForce(transform.right * 1f, ForceMode2D.Impulse);

        //Healthbar.SetHealth(Hitpoints, MaxHitpoints);
    }

    void OnTriggerEnter2D(Collider2D col)

    {
        if (col.gameObject == playerRef)
        {
            CURRENT_STATE = EnemyState.chase;
            circleCollider.enabled = false;
        } 
    }

    public void OnTriggerStay2D(UnityEngine.Collider2D collision)
    {
        if (collision.tag == "HitBox")
        {
            damageRange = true;

        }
    }
    

    void OnTriggerExit2D(Collider2D collision)
    {
        damageRange = false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject == playerRef)
        {
            CURRENT_STATE = EnemyState.attacking;
            //healthBar.Damage(0.02f);
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

    IEnumerator deathAudio()
    {
        audioSource.PlayOneShot(RandClip());
        yield return new WaitForSeconds(.15f);
    }

}
