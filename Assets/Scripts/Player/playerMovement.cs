using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed = 10f;
    [SerializeField] private float VerticalSpeed = 0f;
    private Rigidbody2D rb;
    private SpriteRenderer sp;
    private Animator animator;

    [SerializeField] float movementSmooth = 0.5f;
    private Vector3 velocity = Vector3.zero;
    private bool canMove = true;
    public HealthBar healthBar;
    private bool facingRight;

    public float knockbackTime;
    public GameObject hitFeedback;
    public static bool isFighting;

    public AudioSource audioSource;
    public AudioClip[] audioClipArray;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void OnDisable()
    {
        Note.AttackButton -= Attack;
    }

    void OnEnable()
    {
        Note.AttackButton += Attack;
    }



    //Makes the player movement feel smooth and will flip the sprite to face in the correct direction
    public void Move(float horizMove, float vertMove)
    {
        if (canMove)
        {
            Vector3 targetVelocity = new Vector2(horizMove * horizontalSpeed, vertMove * VerticalSpeed);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, movementSmooth);

            animator.SetFloat("SpeedH", Mathf.Abs(horizMove)); 
            animator.SetFloat("SpeedV", Mathf.Abs(vertMove));

            if(horizMove < 0 && !facingRight)
            {
                flip();
                //sp.flipX = true;
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if(horizMove > 0 && facingRight)
            {
                flip();
                //sp.flipX = false;
                transform.localScale = new Vector3(1, 1, 1);
            }
        }

    }

    public void Attack(string buttonToPress)
    {
        int randNum = Random.Range(1, 3);
        animator.SetTrigger("atk" + randNum);

        isFighting = true;

        Debug.Log("ATTACK IS PRESSED: ");

        audioSource.clip = audioClipArray[0];
        audioSource.Play();

        StartCoroutine(attackCooldown(.35f));


    }


    private void flip()
    {
        facingRight = !facingRight;
    }

    IEnumerator attackCooldown(float delay)
    {
        hitFeedback.SetActive(true);
        yield return new WaitForSeconds(delay);
        isFighting = false;
        hitFeedback.SetActive(false);
    }

    /*
    //If collides with Enemy player will take damage
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            healthBar.Damage(0.02f);
            Debug.Log("damage");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            healthBar.Damage(.02f);
            StartCoroutine(waitForAttack());
            //play enemy attack anim
        }
    }
    */

}
