using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitting : MonoBehaviour
{
   

    void Update()
    {
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.collider.GetComponent<Enemy>();
        if (enemy)
        {
            enemy.TakeDamage(1);
            Debug.Log("EnemyDamage");
        }
    }
}
