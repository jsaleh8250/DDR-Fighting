using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DanceSequence : MonoBehaviour
{
    public float songTime;

    public GameObject enemyPrefab;
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;
    public GameObject currentEnemy;

    private int currentEnemyType;

    public GameObject player;
    public GameObject danceCam;

    public void OnEnable()
    {
        this.enabled = true;
        this.transform.GetChild(0).transform.GetChild(0).GetComponent<SongManager>().enabled = true;
        StartCoroutine(DanceOff(songTime));
        currentEnemyType = player.GetComponent<playerMovement>().currentEnmyType;
        InstantiateEnemy();
        PausePlayer();
    }

    public void OnDisable()
    {
        DeleteEnemy();
        danceCam.SetActive(false);
    }


    void Start()
    {
        StartCoroutine(DanceOff(songTime));
        player = GameObject.FindWithTag("Player");
    }


    void PausePlayer()
    {
        player.GetComponent<playerMovement>().Move(0, 0);
        player.GetComponent<playerMovement>().horizontalSpeed = 0f;
        player.GetComponent<playerMovement>().VerticalSpeed = 0f;
        player.GetComponent<PlayerInput>().horizontalMove = 0f;
        player.GetComponent<PlayerInput>().verticalMove = 0f;
        player.GetComponent<Transform>().position = new Vector2(player.transform.position.x + 3f, this.transform.position.y - .35f);
        currentEnemy.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void InstantiateEnemy()
    {
        if (currentEnemyType == 1)
        {
            GameObject enemy = Instantiate(enemyPrefab, new Vector2(transform.position.x + 3f, transform.position.y - .35f), Quaternion.identity);

            enemy.transform.parent = this.transform;
            currentEnemy = enemy;
        }
        else if (currentEnemyType == 2)
        {
            GameObject enemy = Instantiate(enemyPrefab3, new Vector2(transform.position.x + 3f, transform.position.y - .35f), Quaternion.identity);

            enemy.transform.parent = this.transform;
            currentEnemy = enemy;
        }
        else if (currentEnemyType == 3)
        {
            GameObject enemy = Instantiate(enemyPrefab2, new Vector2(transform.position.x + 3f, transform.position.y - .35f), Quaternion.identity);

            enemy.transform.parent = this.transform;
            currentEnemy = enemy;
        }
        else
        {
            GameObject enemy = Instantiate(enemyPrefab, new Vector2(transform.position.x + 3f, transform.position.y - .35f), Quaternion.identity);

            enemy.transform.parent = this.transform;
            currentEnemy = enemy;
        }

    }

    public void UnPausePlayer()
    {
        player.GetComponent<playerMovement>().horizontalSpeed = 5f;
        player.GetComponent<playerMovement>().VerticalSpeed = 5f;
    }

    public void DeleteEnemy()
    {
        Destroy(currentEnemy);

    }

    IEnumerator DanceOff(float songTIme)
    {
        yield return new WaitForSeconds(songTime);

        GameManager.inDanceSequence = false;
        this.enabled = false;
        this.transform.GetChild(0).transform.GetChild(0).GetComponent<SongManager>().enabled = false;
        UnPausePlayer();
    }
}
