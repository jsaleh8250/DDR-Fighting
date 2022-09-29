using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDR_Input : MonoBehaviour
{
    private void Start()
    {

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            Debug.Log("Left");
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            Debug.Log("Down");
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            Debug.Log("Top");
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton3))
        {
            Debug.Log("Right");
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton4))
        {
            Debug.Log("Bot Left");
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton5))
        {
            Debug.Log("Bot Right");
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton6))
        {
            Debug.Log("Top Left");
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            Debug.Log("Top Right");
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton8))
        {
            Debug.Log("Select Button");
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton9))
        {
            Debug.Log("Start Button");
            //Select
        }
    }
}
