using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isPressed = false;

    public static int DDR_PAD_NUM;

    public static int CONTROLLER_NUM;

    public void Update()
    {
        isPressed = false;

        if (isPressed == true)
        {
            Debug.Log(" PUBLIC Game Manager: " + isPressed);
        }
    }

    private void FixedUpdate()
    {
        if (isPressed == true)
        {
            Debug.Log(" FIXED UPDATE Game Manager: " + isPressed);
        }
    }
}
