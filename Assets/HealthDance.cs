using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDance : MonoBehaviour
{

    public float songTime;
    public GameObject HealthCam;
    void Start()
    {
        HealthCam = GameObject.FindGameObjectWithTag("HealthCam");
        StartCoroutine(LoadNextLevel(songTime));
    }

    IEnumerator LoadNextLevel(float songTIme)
    {
        yield return new WaitForSeconds(songTime);
        GameManager.inHealthMode = false;
        HealthCam.SetActive(false);

   
        
    }

   
}
