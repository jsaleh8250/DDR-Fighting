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

    // Update is called once per frame
    void Update()
    {
        FirstButtonPrompt();
    }

    void FirstButtonPrompt()
    {

        battleSequence.GetComponent<BattleMode>().currentEnemy.transform.GetChild(0).gameObject.SetActive(false);

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

    void BackToBattleMode()
    {
        GameManager.inCoverMode = false;
    }

}
