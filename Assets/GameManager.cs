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

    public GameObject mainCam, secondCam, battleSeq, battleSeqOBJ, coverSeq, coverSeqOBJ, Timerbar;

    public bool DanceMode;

    private void Awake(){
         mainCam.SetActive(true);
                battleSeq.SetActive(false);
                battleSeqOBJ.SetActive(false);
                coverSeq.SetActive(false);
                coverSeqOBJ.SetActive(false);
    }

    private void Update()
    {
        if (!DanceMode)
        {
            if (inBattleMode && !inCoverMode)
            {
                secondCam.SetActive(true);
                mainCam.SetActive(false);
                battleSeq.SetActive(true);
                Timerbar.SetActive(true);
                
            }
            else if(!inBattleMode && !inCoverMode)
            {
                mainCam.SetActive(true);
                secondCam.SetActive(false);
                battleSeq.SetActive(false);
                coverSeq.SetActive(false);
                Timerbar.SetActive(false);
            }
            if (inCoverMode)
            {
                battleSeq.SetActive(false);
                battleSeqOBJ.SetActive(false);
                coverSeq.SetActive(true);
                coverSeqOBJ.SetActive(true);
            }
            else if(inBattleMode)
            {
                battleSeq.SetActive(true);
                battleSeqOBJ.SetActive(true);
                coverSeq.SetActive(false);
                coverSeqOBJ.SetActive(false);
            }
        }
    }
}
