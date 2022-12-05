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

    public static bool inCoverMode;

    public GameObject mainCam, secondCam, battleSeq, battleSeqOBJ, coverSeq, coverSeqOBJ, Timer;


    private void Update()
    {

        if (inBattleMode)
        {
            secondCam.SetActive(true);
            mainCam.SetActive(false);
            battleSeq.SetActive(true);
            Timer.SetActive(true);
            if (inCoverMode)
            {
                battleSeq.SetActive(false);
                battleSeqOBJ.SetActive(false);
                coverSeq.SetActive(true);
                coverSeqOBJ.SetActive(true);
            }
            else
            {
                battleSeq.SetActive(true);
                battleSeqOBJ.SetActive(true);
                coverSeq.SetActive(false);
                coverSeqOBJ.SetActive(false);
            }
        }
        else
        {
            mainCam.SetActive(true);
            secondCam.SetActive(false);
            battleSeq.SetActive(false);
            coverSeq.SetActive(false);
            Timer.SetActive(false);
        }
    }
}
