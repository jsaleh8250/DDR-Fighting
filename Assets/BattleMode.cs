using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMode : MonoBehaviour
{
    //Script Control
    public GameObject player;
    public GameObject secondCam;

    //Sequence
    public GameObject[] NotePrefab;
    public Transform[] NoteTransform;
    public GameObject[] NoteTransformObject;

    //GameObjects
    public GameObject CoverSequence;
    public GameObject CoverSequenceObject;
    public GameObject enemyPrefab;
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;
    Animator enemyAnim;
    public GameObject currentEnemy;
    private string currentState;
    private int currentEnemyType;
    private int firstEnemyGone;

    void Awake()
    {
        InstantiateEnemy();
        firstEnemyGone++;

        PausePlayer();
    }

    public void OnEnable()
    {
        currentEnemyType = player.GetComponent<playerMovement>().currentEnmyType;
        firstEnemyGone++;
        if (firstEnemyGone > 2)
        {
            InstantiateEnemy();
        }
    }
    public void OnDisable()
    {
        DeleteEnemy();
    }

    // Start is called before the first frame update
    void Start()
    {
        InstantiateSequence();
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

        FirstButton.transform.GetChild(0).GetComponent<BattleSequencePress>().enabled = true;

        if (FirstButton.transform.GetChild(0).GetComponent<BattleSequencePress>().buttonPressed)
        {
            SecondButtonPrompt();
        }
    }

    void SecondButtonPrompt()
    {
        GameObject SecondButton = NoteTransformObject[1];

        SecondButton.transform.GetChild(0).GetComponent<BattleSequencePress>().enabled = true;

        if (SecondButton.transform.GetChild(0).GetComponent<BattleSequencePress>().buttonPressed)
        {
            ThirdButtonPrompt();
        }
    }

    void ThirdButtonPrompt()
    {
        GameObject ThirdButton = NoteTransformObject[2];

        ThirdButton.transform.GetChild(0).GetComponent<BattleSequencePress>().enabled = true;

        if (ThirdButton.transform.GetChild(0).GetComponent<BattleSequencePress>().buttonPressed)
        {
            FourthButtonPrompt();
        }
    }

    void FourthButtonPrompt()
    {
        GameObject ThirdButton = NoteTransformObject[3];

        ThirdButton.transform.GetChild(0).GetComponent<BattleSequencePress>().enabled = true;

        if (ThirdButton.transform.GetChild(0).GetComponent<BattleSequencePress>().buttonPressed)
        {
            FinishSequence();
        }
    }

    void ClearNotes()
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
            GameObject note = Instantiate(NotePrefab[Random.Range(0, NotePrefab.Length)], t.transform.position, Quaternion.identity);

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

        InstantiateSequence();
    }

    void FinishSequence()
    {
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
        currentEnemy.transform.GetChild(0).gameObject.SetActive(true);
        player.GetComponent<playerMovement>().Move(0, 0);
        player.GetComponent<playerMovement>().horizontalSpeed = 0f;
        player.GetComponent<playerMovement>().VerticalSpeed = 0f;
        player.GetComponent<PlayerInput>().horizontalMove = 0f;
        player.GetComponent<PlayerInput>().verticalMove = 0f;
        player.GetComponent<Transform>().position = new Vector2(secondCam.transform.position.x - 3f, secondCam.transform.position.y - .35f);
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

    IEnumerator KillEnemy()
    {
        ChangingAnim("Death");
        PlayDeathAnimation();
        yield return new WaitForSeconds(.5f);
        GameManager.inBattleMode = false;
        UnPausePlayer();
        ClearNotes();
        InstantiateSequence();

    }

    IEnumerator PlayDeathAnimationOperation()
    {
        ChangingAnim("Death");
        yield return new WaitForSeconds(.5f);
        DeleteEnemy();
    }
}
