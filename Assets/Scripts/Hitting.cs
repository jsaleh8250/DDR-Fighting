using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitting : MonoBehaviour
{
    private Note canBePressed;
    void Start()
    {
        canBePressed = GetComponent<Note>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (canBePressed == true)
        {
            var enemy = collision.collider.GetComponent<Enemy>();
            if (enemy)
            {
                enemy.TakeDamage(1);
                Debug.Log("EnemyDamage");
            }
        }
    }
}
