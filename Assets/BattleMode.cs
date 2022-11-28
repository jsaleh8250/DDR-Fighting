using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMode : MonoBehaviour
{
    public GameObject player;
    public GameObject secondCam;

    public GameObject[] NotePrefab;
    public Transform[] NoteTransform;

    public int randNote;
    public int randTransform;

    void Awake()
    {
        player.GetComponent<playerMovement>().Move(0,0);
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
        
    }

    void InstantiateSequence()
    {
        foreach (Transform t in NoteTransform)
        {
            GameObject note = Instantiate(NotePrefab[Random.Range(0, NotePrefab.Length)], t.transform.position, Quaternion.identity);
        }
    }
}
