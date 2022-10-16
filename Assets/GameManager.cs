using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isPressed = false;

    private void FixedUpdate()
    {
        isPressed = false;
    }
}
