using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectArrows : MonoBehaviour
{
    private SpriteRenderer SR;
    public Sprite defaultImage;
    public Sprite pressedImage;
    public KeyCode keyToPress;
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
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
