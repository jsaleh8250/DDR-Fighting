using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateBehaviour : MonoBehaviour
{
    public enum EnemyState
    { 
        initialize,
        idle,
        seePlayer,
        chase,
        attacking,
        retreat
    }

    public EnemyState CURRENT_STATE;

    public GameObject playerRef;

    private void Start()
    {
        CURRENT_STATE = EnemyState.initialize;
    }

    public virtual void Update()
    {
        switch (CURRENT_STATE)
        {
            case EnemyState.initialize:
                playerRef = GameObject.Find("Player");
                CURRENT_STATE = EnemyState.idle;
                break;
            case EnemyState.idle:
                //Idle();
                break;
            case EnemyState.seePlayer:
                //SeenPlayer();
                break;
            case EnemyState.chase:
                //Chasing();
                break;
            case EnemyState.attacking:
                //Attack();
                break;
            case EnemyState.retreat:
                //Retreating();
                break;
            default:
                break;
        }
    }

    public virtual void Idle()
    {
    }

    public virtual void SeenPlayer()
    {
    }
    public virtual void Chasing()
    {
    }

    public virtual void Attacking()
    {
    }

    public virtual void Retreating()
    {
    }

}
