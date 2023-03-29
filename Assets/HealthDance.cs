using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDance : MonoBehaviour
{
<<<<<<< HEAD
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
=======
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
>>>>>>> bac859f74511735a196a4b35dc3947726fa6d414
    }
}
