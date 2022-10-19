using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player movement to go Horizontal or vertical
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private playerMovement playermove;
    float horizontalMove;
    float verticalMove;

    private void Awake()
    {
        playermove = GetComponent<playerMovement>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");


        /*
        if (GameManager.isPressed)
        {
            //StartCoroutine(timerAnim());
        }
        */
    }
    private void FixedUpdate()
    {
        playermove.Move(horizontalMove, verticalMove);

    }

    IEnumerator timerAnim()
    {
        playermove.Attack();
        yield return new WaitForSeconds(1);
    }
}
