using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMode : MonoBehaviour
{
    //Script Control
    public GameObject player;
    public GameObject secondCam;

    public static int buttons = 3;

    //Sequence
    public GameObject[] NotePrefab;
    public Transform[] NoteTransform;
    public GameObject[] NoteTransformObject;

    //GameObjects
    public GameObject CoverSequence;
    public GameObject CoverSequenceObject;
    
    //Enemy
    public GameObject enemyPrefab;
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;
    Animator enemyAnim;
    public GameObject currentEnemy;
    private string currentState;
    private int currentEnemyType;
    private int firstEnemyGone;
    public static int count;

    // Amount of times
    public int charges = 0;
    public static int hits = 3;
    public static int health = 3;

    public static int timesCalled;

    //Timer
    public Timer timerScript;

    //EFFECTS
    public GameObject boomFX, krackFX, whamFX, danceFX;

    public bool secondLevel;

    public static bool firstTry;

    public GameObject battleMode;

    void Awake()
    {
        InstantiateEnemy();
        firstEnemyGone++;

        PausePlayer();
        battleMode.SetActive(true);
    }

    public void OnEnable()
    {
        if (charges == 0)
        {
            firstTry = true;
        }
        else
        {
            danceFX.SetActive(true);
            firstTry = false;
        }
            
        InstantiateSequence();
        currentEnemyType = player.GetComponent<playerMovement>().currentEnmyType;
        firstEnemyGone++;
        if (firstEnemyGone > 2)
        {
            InstantiateEnemy();
        }

        Debug.Log(firstTry);

        timesCalled++;
        Debug.Log("Times Turned On: " + timesCalled);
    }
    public void OnDisable()
    {
        DeleteEnemy();
        GameManager.inBattleMode = false;
        battleMode.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        FirstButtonPrompt();
    }

    void FirstButtonPrompt()
    {
        PausePlayer();

        GameObject FirstButton = NoteTransformObject[0];

        if (FirstButton.transform.GetChild(0).GetComponent<BattleSequencePress>())
        {
            FirstButton.transform.GetChild(0).GetComponent<BattleSequencePress>().enabled = true;
            if (FirstButton.transform.GetChild(0).GetComponent<BattleSequencePress>().buttonPressed)
            {
                boomFX.SetActive(true);
                SecondButtonPrompt();
            }
        }
        else if (FirstButton.transform.GetChild(0).GetComponent<CoverSequencePress>())
        {
            FirstButton.transform.GetChild(0).GetComponent<CoverSequencePress>().enabled = true;

            if (FirstButton.transform.GetChild(0).GetComponent<CoverSequencePress>().buttonPressed)
            {
                boomFX.SetActive(true);
                SecondButtonPrompt();
            }
        }
    }

    void SecondButtonPrompt()
    {
        GameObject SecondButton = NoteTransformObject[1];

        if (SecondButton.transform.GetChild(0).GetComponent<BattleSequencePress>())
        {
            SecondButton.transform.GetChild(0).GetComponent<BattleSequencePress>().enabled = true;
            if (SecondButton.transform.GetChild(0).GetComponent<BattleSequencePress>().buttonPressed)
            {
                boomFX.SetActive(true);
                ThirdButtonPrompt();
            }
        }
        else if (SecondButton.transform.GetChild(0).GetComponent<CoverSequencePress>())
        {
            SecondButton.transform.GetChild(0).GetComponent<CoverSequencePress>().enabled = true;

            if (SecondButton.transform.GetChild(0).GetComponent<CoverSequencePress>().buttonPressed)
            {
                boomFX.SetActive(true);
                ThirdButtonPrompt();
            }
        }
    }

    void ThirdButtonPrompt()
    {
        GameObject ThirdButton = NoteTransformObject[2];

        if (ThirdButton.transform.GetChild(0).GetComponent<BattleSequencePress>())
        {
            ThirdButton.transform.GetChild(0).GetComponent<BattleSequencePress>().enabled = true;
            if (ThirdButton.transform.GetChild(0).GetComponent<BattleSequencePress>().buttonPressed)
            {
                boomFX.SetActive(true);
                FourthButtonPrompt();
            }
        }
        else if (ThirdButton.transform.GetChild(0).GetComponent<CoverSequencePress>())
        {
            ThirdButton.transform.GetChild(0).GetComponent<CoverSequencePress>().enabled = true;

            if (ThirdButton.transform.GetChild(0).GetComponent<CoverSequencePress>().buttonPressed)
            {
                boomFX.SetActive(true);
                FourthButtonPrompt();
            }
        }
    }

    void FourthButtonPrompt()
    {
        GameObject ThirdButton = NoteTransformObject[3];

        if (ThirdButton.transform.GetChild(0).GetComponent<BattleSequencePress>())
        {
            ThirdButton.transform.GetChild(0).GetComponent<BattleSequencePress>().enabled = true;
            if (ThirdButton.transform.GetChild(0).GetComponent<BattleSequencePress>().buttonPressed)
            {
                if (secondLevel)
                {
                    FifthButtonPrompt();
                }
                else
                {
                    if (charges == hits)
                    {
                        FinishSequence();
                    }
                    else
                    {
                        ChargeAdded();
                        GameManager.inCoverMode = true;
                        Debug.Log("Completed Sequence");
                    }
                }
            }
        }
        else if (ThirdButton.transform.GetChild(0).GetComponent<CoverSequencePress>())
        {
            ThirdButton.transform.GetChild(0).GetComponent<CoverSequencePress>().enabled = true;

            if (ThirdButton.transform.GetChild(0).GetComponent<CoverSequencePress>().buttonPressed)
            {
                if (secondLevel)
                {
                    FifthButtonPrompt();
                }
                else
                {
                    if (charges == hits)
                    {
                        FinishSequence();
                    }
                    else
                    {
                        ChargeAdded();
                        GameManager.inCoverMode = true;
                    }
                }
            }
        }

    }

    void FifthButtonPrompt()
    {
        boomFX.SetActive(false);
        krackFX.SetActive(false);
        whamFX.SetActive(false);
        GameObject FifthButton = NoteTransformObject[4];

        if (FifthButton.transform.GetChild(0).GetComponent<BattleSequencePress>())
        {
            FifthButton.transform.GetChild(0).GetComponent<BattleSequencePress>().enabled = true;
            if (FifthButton.transform.GetChild(0).GetComponent<BattleSequencePress>().buttonPressed)
            {
                boomFX.SetActive(true);
                SixthButtonPrompt();
            }
        }
        else if (FifthButton.transform.GetChild(0).GetComponent<CoverSequencePress>())
        {
            FifthButton.transform.GetChild(0).GetComponent<CoverSequencePress>().enabled = true;

            if (FifthButton.transform.GetChild(0).GetComponent<CoverSequencePress>().buttonPressed)
            {
                boomFX.SetActive(true);
                SixthButtonPrompt();
            }
        }
    }


    void SixthButtonPrompt()
    {
        GameObject SixthButton = NoteTransformObject[5];

        if (SixthButton.transform.GetChild(0).GetComponent<BattleSequencePress>())
        {
            SixthButton.transform.GetChild(0).GetComponent<BattleSequencePress>().enabled = true;
            if (SixthButton.transform.GetChild(0).GetComponent<BattleSequencePress>().buttonPressed)
            {
                boomFX.SetActive(true);
                SeventhButtonPrompt();
            }
        }
        else if (SixthButton.transform.GetChild(0).GetComponent<CoverSequencePress>())
        {
            SixthButton.transform.GetChild(0).GetComponent<CoverSequencePress>().enabled = true;

            if (SixthButton.transform.GetChild(0).GetComponent<CoverSequencePress>().buttonPressed)
            {
                boomFX.SetActive(true);
                SeventhButtonPrompt();
            }
        }
    }

    void SeventhButtonPrompt()
    {
        GameObject SeventhButton = NoteTransformObject[6];

        if (SeventhButton.transform.GetChild(0).GetComponent<BattleSequencePress>())
        {
            SeventhButton.transform.GetChild(0).GetComponent<BattleSequencePress>().enabled = true;
            if (SeventhButton.transform.GetChild(0).GetComponent<BattleSequencePress>().buttonPressed)
            {
                boomFX.SetActive(true);
                EighthButtonPrompt();
            }
        }
        else if (SeventhButton.transform.GetChild(0).GetComponent<CoverSequencePress>())
        {
            SeventhButton.transform.GetChild(0).GetComponent<CoverSequencePress>().enabled = true;

            if (SeventhButton.transform.GetChild(0).GetComponent<CoverSequencePress>().buttonPressed)
            {
                boomFX.SetActive(true);
                EighthButtonPrompt();
            }
        }
    }

    void EighthButtonPrompt()
    {
        GameObject SeventhButton = NoteTransformObject[7];

        if (SeventhButton.transform.GetChild(0).GetComponent<BattleSequencePress>())
        {
            SeventhButton.transform.GetChild(0).GetComponent<BattleSequencePress>().enabled = true;

            if (SeventhButton.transform.GetChild(0).GetComponent<BattleSequencePress>().buttonPressed)
            {
                if (charges == hits)
                {
                    FinishSequence();
                }
                else
                {
                    ChargeAdded();
                    GameManager.inCoverMode = true;
                }
            }
        }

        else if (SeventhButton.transform.GetChild(0).GetComponent<CoverSequencePress>())
        {
            SeventhButton.transform.GetChild(0).GetComponent<CoverSequencePress>().enabled = true;
            if (SeventhButton.transform.GetChild(0).GetComponent<CoverSequencePress>().buttonPressed)
            {
                if (charges == hits)
                {
                    FinishSequence();
                }
                else
                {
                    ChargeAdded();
                    GameManager.inCoverMode = true;
                }
            }
        }
    }

    public void ClearNotes()
    {
        for (int i = 0; i < NoteTransform.Length; i++)
        {
            GameObject.Destroy(NoteTransform[i].transform.GetChild(0).gameObject);
        }
    }



    public void InstantiateSequence()
    {
        foreach (Transform t in NoteTransform)
        {
            GameObject note = Instantiate(NotePrefab[Random.Range(0, buttons)], t.transform.position, Quaternion.identity);

            note.transform.SetParent(t);
        }
    }

    public void InstantiateEnemy()
    {
        if (currentEnemyType == 1)
        {
            GameObject enemy = Instantiate(enemyPrefab, new Vector2(secondCam.transform.position.x + 3f, secondCam.transform.position.y - .35f), Quaternion.identity);

            enemy.transform.parent = secondCam.transform;

            enemyAnim = enemy.GetComponent<Animator>();
            currentEnemy = enemy;
        }
        else if (currentEnemyType == 2)
        {
            GameObject enemy = Instantiate(enemyPrefab3, new Vector2(secondCam.transform.position.x + 3f, secondCam.transform.position.y - .35f), Quaternion.identity);

            enemy.transform.parent = secondCam.transform;

            enemyAnim = enemy.GetComponent<Animator>();
            currentEnemy = enemy;
        }
        else if (currentEnemyType == 3)
        {
            GameObject enemy = Instantiate(enemyPrefab2, new Vector2(secondCam.transform.position.x + 3f, secondCam.transform.position.y - .35f), Quaternion.identity);

            enemy.transform.parent = secondCam.transform;

            enemyAnim = enemy.GetComponent<Animator>();
            currentEnemy = enemy;
        }
        else
        {
            GameObject enemy = Instantiate(enemyPrefab, new Vector2(secondCam.transform.position.x + 3f, secondCam.transform.position.y - .35f), Quaternion.identity);

            enemy.transform.parent = secondCam.transform;

            enemyAnim = enemy.GetComponent<Animator>();
            currentEnemy = enemy;
        }

    }

    public void DeleteEnemy()
    {
        Destroy(currentEnemy);
       
    }

    public void CoverSequenceStart()
    {
        for (int i = 0; i < NoteTransform.Length; i++)
        {
            GameObject.Destroy(NoteTransform[i].transform.GetChild(0).gameObject);
        }
    }

    void FinishSequence()
    {
        boomFX.SetActive(false);
        krackFX.SetActive(false);
        whamFX.SetActive(false);
        currentEnemy.transform.GetChild(0).gameObject.SetActive(false);
        StartCoroutine(KillEnemy());
    }

    void ChangingAnim(string newState)
    {
        if (currentState == newState) return;
        currentEnemy.GetComponent<Animator>().Play(newState);
        currentState = newState;
    }

    void PausePlayer()
    {
        player.GetComponent<playerMovement>().Move(0, 0);
        player.GetComponent<playerMovement>().horizontalSpeed = 0f;
        player.GetComponent<playerMovement>().VerticalSpeed = 0f;
        player.GetComponent<PlayerInput>().horizontalMove = 0f;
        player.GetComponent<PlayerInput>().verticalMove = 0f;
        player.GetComponent<Transform>().position = new Vector2(player.transform.position.x, secondCam.transform.position.y - .35f);
        currentEnemy.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void UnPausePlayer()
    {
        player.GetComponent<playerMovement>().horizontalSpeed = 5f;
        player.GetComponent<playerMovement>().VerticalSpeed = 5f;
    }

    public void PlayDeathAnimation()
    {
        StartCoroutine(PlayDeathAnimationOperation());
    }

    private void ChargeAdded()
    {
        timerScript.ResetTimer();
        charges++;

    }

    IEnumerator KillEnemy()
    {
        ChangingAnim("Death");
        PlayDeathAnimation();
        yield return new WaitForSeconds(.5f);
        GameManager.inBattleMode = false;
        UnPausePlayer();
        ClearNotes();
        count++;
        charges = 0;

    }

    IEnumerator PlayDeathAnimationOperation()
    {
        ChangingAnim("Death");
        yield return new WaitForSeconds(.5f);
        DeleteEnemy();
    }
}
