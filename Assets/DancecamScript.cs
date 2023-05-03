using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DancecamScript : MonoBehaviour
{Transform player;

    public void Update()
    {
        this.player = GameObject.FindWithTag("Player").transform;
        this.gameObject.transform.position = new Vector3(player.transform.position.x + 3f, this.gameObject.transform.position.y, this.gameObject.transform.position.z);

    }
}
