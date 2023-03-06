using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteNotes : MonoBehaviour
{
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Note")
        {
            Destroy(collision.gameObject);

            ScoreHandler.missedNote = true;
            

        }
    }
}
