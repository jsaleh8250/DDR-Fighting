using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitting : MonoBehaviour
{
    public bool attack;
    
    void Start()
    {
          attack = false;      
    }
    private void Update()
    {
        
        if (attack == true)
        {
            GetComponent<Collider2D>().isTrigger = true;
        }
        else
        {
            GetComponent<Collider2D>().isTrigger = false;
        }
    }
}
