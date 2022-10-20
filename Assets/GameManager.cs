using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isPressed = false;

    public static int DDR_PAD_NUM;

    public static int CONTROLLER_NUM;

    private void Update()
    {
        isPressed = false;
    }
}
