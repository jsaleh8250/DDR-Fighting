using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isPressed;

    public static int DDR_PAD_NUM;

    public static int JOY_PAD_NUM;

    public static int CONTROLLER_NUM;

    public static bool inBattleMode;

    public GameObject mainCam, secondCam, battleSeq, coverSeq;


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

        if (inBattleMode)
        {
            secondCam.SetActive(true);
            mainCam.SetActive(false);
            battleSeq.SetActive(true);
        }
        else
        {
            mainCam.SetActive(true);
            secondCam.SetActive(false);
            battleSeq.SetActive(false);
            coverSeq.SetActive(false);
        }
    }
}
