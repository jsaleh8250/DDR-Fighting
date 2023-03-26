using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneSequence : MonoBehaviour
{
    public GameObject player;
    public GameObject Cam; 

   
    void Awake()
    {
        PausePlayer();
    }

    // Update is called once per frame
    void Update()
    {
         PausePlayer();
    }
    
    
    
    void PausePlayer()
    {
        player.GetComponent<playerMovement>().Move(0, 0);
        player.GetComponent<playerMovement>().horizontalSpeed = 0f;
        player.GetComponent<playerMovement>().VerticalSpeed = 0f;
        player.GetComponent<PlayerInput>().horizontalMove = 0f;
        player.GetComponent<PlayerInput>().verticalMove = 0f;
       // player.GetComponent<Transform>().position = new Vector2(player.transform.position.x, healthCam.transform.position.y - .35f);
        //currentEnemy.transform.GetChild(0).gameObject.SetActive(true);
    }
    public void UnPausePlayer()
    {
        player.GetComponent<playerMovement>().horizontalSpeed = 5f;
        player.GetComponent<playerMovement>().VerticalSpeed = 5f;
    }
}
