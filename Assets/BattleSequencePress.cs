using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BattleSequencePress : MonoBehaviour
{
    //Dancepad Controller
    public string buttonToPress;
    public KeyCode keyToPress;

    string controllerString;

    //Light Sprite
    public Sprite newSprite;
    SpriteRenderer sp;

    public bool buttonPressed;
    public bool otherButtonPressed;

    private GameObject player;

    public void Awake()
    {
        controllerString = "Joystick" + GameManager.DDR_PAD_NUM + buttonToPress;

        keyToPress = (KeyCode)System.Enum.Parse(typeof(KeyCode), controllerString);

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        sp = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            ChangeSprite();
        }
    }

    void ChangeSprite()
    {
        sp.sprite = newSprite;
        buttonPressed = true;
    }

}

