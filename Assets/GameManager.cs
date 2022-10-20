using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isPressed = false;

    public static int DDR_PAD_NUM;

    public static int CONTROLLER_NUM;

    private void FixedUpdate()
    {
        isPressed = false;
    }

    private void Update()
    {
        if (isPressed)
        {
            Debug.Log("It's TRUE");
        }
    }
}
