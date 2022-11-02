using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Continue : MonoBehaviour
{
    int SceneIndex;
   
    public void LoadNextScene()
    {
        SceneManager.LoadScene(4);
    }
}
