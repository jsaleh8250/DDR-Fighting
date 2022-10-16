using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed = 10f;
    [SerializeField] private float VerticalSpeed = 0f;
    private Rigidbody2D rb;
    private SpriteRenderer sp;
   
    [SerializeField] float movementSmooth = 0.5f;
    private Vector3 velocity = Vector3.zero;
    private bool canMove = true;
    public HealthBar healthBar;
    private bool facingRight;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }
    public void Move(float horizMove, float vertMove)
    {
        if (canMove)
        {
            Vector3 targetVelocity = new Vector2(horizMove * horizontalSpeed, vertMove * VerticalSpeed);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, movementSmooth);

            if(horizMove < 0 && !facingRight)
            {
                flip();
                sp.flipX = true;
            }
            else if(horizMove > 0 && facingRight)
            {
                flip();
                sp.flipX = false;
            }
        }
    }

    private void flip()
    {
        facingRight = !facingRight;
    } 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            healthBar.Damage(0.02f);
            Debug.Log("damage");
        }
    }
}
