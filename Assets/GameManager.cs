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

    public static bool inCutscene;

    public GameObject mainCam, secondCam, battleSeq, battleSeqOBJ, coverSeq, coverSeqOBJ, Timerbar, healthCam, cutsceneCam, arrowsSpawn, arrows, countdown;

    public bool DanceMode;

    public static bool inHealthMode;

    private GameObject bgmusic;

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
                healthCam.SetActive(false);
                cutsceneCam.SetActive(false);
            }
            else if(!inBattleMode && !inCoverMode)
            {
                mainCam.SetActive(true);
                secondCam.SetActive(false);
                battleSeq.SetActive(false);
                coverSeq.SetActive(false);
                Timerbar.SetActive(false);
                healthCam.SetActive(false);
            }
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
            if(inHealthMode)
            {
                bgmusic = GameObject.FindGameObjectWithTag("Music");
            //    bgmusic.SetActive(false);
              healthCam.SetActive(true);
              mainCam.SetActive(false);
              secondCam.SetActive(false);
              battleSeq.SetActive(false);
              coverSeq.SetActive(false);
              Timerbar.SetActive(false);
              arrows.SetActive(true);
              arrowsSpawn.SetActive(true);
              countdown.SetActive(true);
              DanceMode = true;
              cutsceneCam.SetActive(false);
            }
            if (inCutscene)
            {
                mainCam.SetActive(false);
                cutsceneCam.SetActive(true);
                bgmusic = GameObject.FindGameObjectWithTag("Music");
                bgmusic.SetActive(false);
                healthCam.SetActive(false);
                secondCam.SetActive(false);
                battleSeq.SetActive(false);
                coverSeq.SetActive(false);
            }
        }
    }
}
