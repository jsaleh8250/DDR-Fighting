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

    void Awake()
    {
        battleSequence.SetActive(false);
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
        /*
        foreach (GameObject o in NoteTransformObject)
        {
            o.transform.GetChild(0).GetComponent<BattleSequencePress>().enabled = true;
            if (o.transform.GetChild(0).GetComponent<BattleSequencePress>().buttonPressed)
            {
                Debug.Log("Button are being pressed");
            }
        }
        */
    }

    void FirstButtonPrompt()
    {
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
            FinishSequence();
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

    void FinishSequence()
    {
        GameManager.inBattleMode = false;
        player.GetComponent<playerMovement>().horizontalSpeed = 5f;
        player.GetComponent<playerMovement>().VerticalSpeed = 5f;
    }
}
