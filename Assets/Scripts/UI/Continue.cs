using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Continue : MonoBehaviour
{

    public void LoadNextScene(string LevelName)
    {
        SceneManager.LoadScene(LevelName);
    }
}
