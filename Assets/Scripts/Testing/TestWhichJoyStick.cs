using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWhichJoyStick : MonoBehaviour
{
    string[] joysticks;
    int joysticksCount = 0;

    public GameObject DDRPadSelectScreen;
    public GameObject JoyStickSelect;
    public GameObject JoyStickUI;

    // Update is called once per frame
    void Update()
    {
        joysticks = Input.GetJoystickNames();
        if (joysticks.Length != joysticksCount)
        {
            joysticksCount = joysticks.Length;
            Debug.LogError($"Joysticks updated, Count {joysticksCount}");
        }
        foreach (KeyCode key in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(key))
            {
                Debug.LogError($"Key {key.ToString()} Pressed");

                string keyPressed = key.ToString();
                string name = "";
                string number;

                string[] splitArray = keyPressed.Split(char.Parse("k"));
                name = splitArray[1];
                string[] splitNum = name.Split(char.Parse("B"));
                number = splitNum[0];

                int.TryParse(number, out GameManager.DDR_PAD_NUM);

                Debug.Log(GameManager.DDR_PAD_NUM);


                Destroy(DDRPadSelectScreen);
                JoyStickSelect.SetActive(true);
                JoyStickUI.SetActive(true);
                Destroy(gameObject);

            }
        }
    }
}
