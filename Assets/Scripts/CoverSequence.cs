using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverSequence : MonoBehaviour
{
    //Script Control
    public GameObject player;
    public GameObject secondCam;

    //Sequence
    public GameObject[] NotePrefab;
    public Transform[] NoteTransform;
    public GameObject[] NoteTransformObject;

    public GameObject battleSequence;
    public GameObject battleSequenceObject;

    public GameObject currentEnemy;
    private string currentState;
    private int currentEnemyType;
    private int firstEnemyGone;
    Animator enemyAnim;
    public GameObject enemyPrefab;
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;

    public GameObject boomFX, krackFX, whamFX;

    void Awake()
    {
        player.GetComponent<playerMovement>().Move(0, 0);
        player.GetComponent<playerMovement>().horizontalSpeed = 0f;
        player.GetComponent<playerMovement>().VerticalSpeed = 0f;
        player.GetComponent<Transform>().position = new Vector2(secondCam.transform.position.x - 3f, secondCam.transform.position.y - .35f);
        //player.GetComponent<PlayerInput>().enabled = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        InstantiateSequence();
    }

    public void OnEnable()
    {
        currentEnemyType = player.GetComponent<playerMovement>().currentEnmyType;
        InstantiateEnemy();
    }
    public void OnDisable()
    {
        DeleteEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        FirstButtonPrompt();
    }

    void FirstButtonPrompt()
    {
        GameObject battleEnemies = GameObject.FindGameObjectWithTag("BattleSeqEnemies");

        battleEnemies.transform.GetChild(0).gameObject.SetActive(false);

        boomFX.SetActive(false);
        krackFX.SetActive(false);
        whamFX.SetActive(false);

        GameObject FirstButton = NoteTransformObject[0];

        FirstButton.transform.GetChild(0).GetComponent<CoverSequencePress>().enabled = true;

        if (FirstButton.transform.GetChild(0).GetComponent<CoverSequencePress>().buttonPressed)
        {
            SecondButtonPrompt();
        }
    }

    void SecondButtonPrompt()
    {
        GameObject SecondButton = NoteTransformObject[1];

        SecondButton.transform.GetChild(0).GetComponent<CoverSequencePress>().enabled = true;

        if (SecondButton.transform.GetChild(0).GetComponent<CoverSequencePress>().buttonPressed)
        {
            ThirdButtonPrompt();
        }
    }

    void ThirdButtonPrompt()
    {
        GameObject ThirdButton = NoteTransformObject[2];

        ThirdButton.transform.GetChild(0).GetComponent<CoverSequencePress>().enabled = true;

        if (ThirdButton.transform.GetChild(0).GetComponent<CoverSequencePress>().buttonPressed)
        {
            FourthButtonPrompt();
        }
    }

    void FourthButtonPrompt()
    {
        GameObject ThirdButton = NoteTransformObject[3];

        ThirdButton.transform.GetChild(0).GetComponent<CoverSequencePress>().enabled = true;

        if (ThirdButton.transform.GetChild(0).GetComponent<CoverSequencePress>().buttonPressed)
        {
            RestartSequence();
            //BackToBattleMode();
        }
    }


    void InstantiateSequence()
    {
        //Spawns the Notes on the Screen

        foreach (Transform t in NoteTransform)
        {
            GameObject note = Instantiate(NotePrefab[Random.Range(0, NotePrefab.Length)], t.transform.position, Quaternion.identity);

            //note.transform.parent = t.parent.transform;
            note.transform.SetParent(t);
        }
    }

    void RestartSequence()
    {

        for (int i = 0; i < NoteTransform.Length; i++)
        {
            GameObject.Destroy(NoteTransform[i].transform.GetChild(0).gameObject);
        }

        InstantiateSequence();
        battleSequence.GetComponent<BattleMode>().CoverSequenceStart();
        GameManager.inCoverMode = false;
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


    void BackToBattleMode()
    {
        GameManager.inCoverMode = false;
    }

}
