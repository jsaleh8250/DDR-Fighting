using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Note : MonoBehaviour
{
    public bool canBePressed;

    public string buttonToPress;
    public KeyCode keyToPress;

    string controllerString;

    public GameObject missEffect, goodEffect, normalEffect, perfectEffect;

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
                StarBar.CurrentHealth = StarBar.CurrentHealth + 10;
                Destroy(gameObject);
                Debug.Log("NOTE SCRIPT: " + GameManager.isPressed);

              
                if(transform.position.y < 1.6f)
                {
                    Debug.Log("Normal Hit");
                    ScoreHandler.instance.NormalHit();
                    Instantiate(normalEffect, transform.position, normalEffect.transform.rotation);
                }else if(transform.position.y < 1.7f)
                {
                    Debug.Log("Good Hit");
                    ScoreHandler.instance.GoodHit();
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                }
                else if(transform.position.y < 1.65f)
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
