using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationInput : MonoBehaviour
{
    Animator anim;



    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void OnDisable()
    {
        CoverSequencePress.AttackButton -= AttackingPlayer;
    }

    public void OnEnable()
    {
        CoverSequencePress.AttackButton += AttackingPlayer;
    }


    public void AttackingPlayer(string buttonToPress)
    {
        anim.SetTrigger("Attack");

    }

    public void DeathAnim()
    {
        anim.SetTrigger("Death");
    }


}
