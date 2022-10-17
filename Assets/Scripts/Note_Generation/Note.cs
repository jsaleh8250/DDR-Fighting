using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Note : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;

    //If pressed will give points to the starbar and gives access to enable attack
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            Debug.Log("note: " + keyToPress);
            if (canBePressed)
            {
                StarBar.CurrentHealth = StarBar.CurrentHealth + 10;
                GameManager.isPressed = true;
                Debug.Log("Key Pressed");
                Destroy(gameObject);
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
