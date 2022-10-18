using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Transform player;

    private void Awake()
    {
        this.player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        this.gameObject.transform.position = new Vector3(player.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
    }
}