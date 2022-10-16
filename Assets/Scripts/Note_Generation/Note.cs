using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Note : MonoBehaviour
{
    public bool canBePressed;
    public bool hit;
    public KeyCode keyToPress;


    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                StarBar.CurrentHealth = StarBar.CurrentHealth + 10;
                GameManager.isPressed = true;
                Debug.Log("Key Pressed");
                Destroy(gameObject);
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Active")
        {
            canBePressed = true;
            hit = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Active")
        {
            canBePressed = false;
            hit = false;
        }
    }
}
