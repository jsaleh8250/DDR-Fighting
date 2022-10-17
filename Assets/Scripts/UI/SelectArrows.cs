using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectArrows : MonoBehaviour
{
    private SpriteRenderer SR;
    public Sprite defaultImage;
    public Sprite pressedImage;
    public KeyCode keyToPress;

    public string buttonToPress;
    string controllerString;

    void Start()
    {
        SR = GetComponent<SpriteRenderer>();

        controllerString = "Joystick" + GameManager.DDR_PAD_NUM + buttonToPress;

        keyToPress = (KeyCode)System.Enum.Parse(typeof(KeyCode), controllerString);
    }

    //The arrow will change sprites when pressed from orginal sprite to pressed sprite
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            SR.sprite = pressedImage;
        }
        if (Input.GetKeyUp(keyToPress))
        {
            SR.sprite = defaultImage;
        }
    }
}
