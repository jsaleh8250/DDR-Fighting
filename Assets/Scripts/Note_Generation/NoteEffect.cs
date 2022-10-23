using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteEffect : MonoBehaviour
{
    public float time = 1f;
    
    void Update()
    {
        Destroy(gameObject, time);
    }
}
