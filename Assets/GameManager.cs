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

    public static bool inHealthMode;

    public static bool inDanceSequence;

    public GameObject mainCam, secondCam, battleSeq, battleSeqOBJ, coverSeq, coverSeqOBJ, healthCam, cutsceneCam, arrowsSpawn, arrows, countdown, Timerbar, danceCam;

    public bool DanceMode;

    private GameObject bgmusic;

    private AudioSource inGameMusic;

    private void Start()
    {
        inGameMusic = GetComponent<AudioSource>();
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
                healthCam.SetActive(false);
                cutsceneCam.SetActive(false);
                Debug.Log("Battle Mode On");
            }
            else if(!inBattleMode && !inCoverMode)
            {
                mainCam.SetActive(true);
                secondCam.SetActive(false);
                battleSeq.SetActive(false);
                coverSeq.SetActive(false);
                Timerbar.SetActive(false);
                healthCam.SetActive(false);
                Debug.Log("Normal Mode On");
            }
            if (inCoverMode)
            {
                battleSeq.SetActive(false);
                battleSeqOBJ.SetActive(false);
                coverSeq.SetActive(true);
                coverSeqOBJ.SetActive(true);
                secondCam.SetActive(true);
                Debug.Log("Cover Mode On");
            }
            else
            {
                inGameMusic.UnPause();
                battleSeq.SetActive(true);
                battleSeqOBJ.SetActive(true);
                coverSeq.SetActive(false);
                coverSeqOBJ.SetActive(false);
            }
            if(inHealthMode)
            {
                inGameMusic.Pause();
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

                Debug.Log("Health Mode On");
            }
            if (inCutscene)
            {
                inGameMusic.Pause();
                mainCam.SetActive(false);
                cutsceneCam.SetActive(true);
                healthCam.SetActive(false);
                secondCam.SetActive(false);
                battleSeq.SetActive(false);
                coverSeq.SetActive(false);
                Debug.Log("Cutscene Mode On");
            }
            if (inDanceSequence)
            {

                danceCam.transform.GetComponent<DanceSequence>().enabled = true;
                secondCam.SetActive(false);
                mainCam.SetActive(false);
                battleSeq.SetActive(false);
                battleSeqOBJ.SetActive(false);
                coverSeq.SetActive(false);
                Timerbar.SetActive(false);
                healthCam.SetActive(false);
                cutsceneCam.SetActive(false);
                danceCam.SetActive(true);
                Debug.Log("Dance Sequence Mode On");
            }
        }
    }
}
