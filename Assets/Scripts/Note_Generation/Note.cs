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


    float dmg = 5;

    public GameObject missEffect, goodEffect, normalEffect, perfectEffect;

    public static event Action<string> AttackButton = delegate { };
    public static event Action<float> Attacking = delegate { };

    private void Awake()
    {
        controllerString = "Joystick" + GameManager.DDR_PAD_NUM + buttonToPress;

        keyToPress = (KeyCode)System.Enum.Parse(typeof(KeyCode), controllerString);
    }

    //If pressed will give points to the starbar and gives access to enable attack
    void Update()
    {

        if (Input.GetKeyDown(keyToPress))
        {
            //Debug.Log("note: " + keyToPress);
            if (canBePressed)
            {
                GameManager.isPressed = true;
                //StarBar.CurrentHealth = StarBar.CurrentHealth + 10;
                Destroy(gameObject);

                AttackButton.Invoke(buttonToPress);
                Attacking.Invoke(dmg);
                Debug.Log("NOTE SCRIPT: " + GameManager.isPressed);
              
                if(transform.position.y <= 1.4f)
                {
                    Debug.Log("Normal Hit");
                    ScoreHandler.instance.NormalHit();
                    Instantiate(normalEffect, transform.position, normalEffect.transform.rotation);
                }else if(transform.position.y <= 2.65f)
                {
                    Debug.Log("Good Hit");
                    ScoreHandler.instance.GoodHit();
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                }
               if (transform.position.y == 1.5f)
                {
                    ScoreHandler.instance.PerfectHit();
                    Debug.Log("Perfect");
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                }

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
            ScoreHandler.instance.NoteMissed();
            //Instantiate(missEffect, transform.position, missEffect.transform.rotation);
        }
    }
}
