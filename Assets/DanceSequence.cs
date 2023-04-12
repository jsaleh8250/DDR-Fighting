using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceSequence : MonoBehaviour
{
    public float songTime;
    void Update()
    {
        StartCoroutine(DanceOff(songTime));
    }

    IEnumerator DanceOff(float songTIme)
    {
        yield return new WaitForSeconds(songTime);
        GameManager.inDanceSequence = false;
    }
}
