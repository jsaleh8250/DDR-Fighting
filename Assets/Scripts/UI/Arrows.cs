using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : MonoBehaviour
{
    public float beatTemp;
    public bool Started;
    void Start()
    {
        beatTemp = beatTemp / 60f;
    }

    //The notes will move up at the beat
    void Update()
    {
        if (!Started)
        {
            if (Input.anyKeyDown)
            {
                Started = true;
            }
        }
        else
        {
            transform.position += new Vector3(0f, beatTemp * Time.deltaTime, 0f);
        }
        
    }
}
