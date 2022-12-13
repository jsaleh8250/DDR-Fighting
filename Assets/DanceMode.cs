using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DanceMode : MonoBehaviour
{
    public float songTime;
    public string nextLevel;
    void Start()
    {
        StartCoroutine(LoadNextLevel(songTime));
    }


    IEnumerator LoadNextLevel(float songTIme)
    {
        yield return new WaitForSeconds(songTime);
        SceneManager.LoadScene(nextLevel);
    }
}
