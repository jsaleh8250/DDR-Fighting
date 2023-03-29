using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Note : MonoBehaviour
{
    public bool canBePressed;

    public string buttonToPress;
    public KeyCode keyToPress;

    string controllerString;

    public HealthBar healthbar;

    float dmg = 5;

    //public GameObject missEffect, goodEffect, normalEffect, perfectEffect;

    public static event Action<string> AttackButton = delegate { };
    public static event Action<float> Attacking = delegate { };

    public void Awake()
    {
        controllerString = "Joystick" + GameManager.DDR_PAD_NUM + buttonToPress;
        keyToPress = (KeyCode)System.Enum.Parse(typeof(KeyCode), controllerString);
    }

    private void Start()
    {
        healthbar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();
    }

    //If pressed will give points to the score and gives access to enable attack
    void Update()
    {

        if (Input.GetKeyDown(keyToPress))
        {
            
            if (canBePressed)
            {
                GameManager.isPressed = true;
                Destroy(gameObject);
                healthbar.ADD(.05f);

                AttackButton.Invoke(buttonToPress);
                Attacking.Invoke(dmg);
                Debug.Log("NOTE SCRIPT: " + GameManager.isPressed);
             
            }

        }


    }

    //If the note enters the Arrow area it can be pressed
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Active")
        {
            canBePressed = true;
        }
    }

    //If the note isn't in the Arrow area it can not be pressed
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Active")
        {
            canBePressed = false;

        }
    }

}
