using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;
    private float MoveDir;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        MoveDir = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(MoveDir * speed, rb.velocity.y);
    }
}
