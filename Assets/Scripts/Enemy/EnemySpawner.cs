using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    private int enemyCount;
    private int waveNumber = 1;

    public float timeBetweenEnemySpawn;
    public float timeBetweenWaves;

    bool spawningWave;

    private void Update()
    {
        enemyCount = FindObjectsOfType<SimpleAI>().Length;

        if (enemyCount == 0 && !spawningWave)
        {
            waveNumber++;
            StartCoroutine(SpawnEnemy(waveNumber));
        }
    }

    IEnumerator SpawnEnemy(int enemiesToSpawn)
    {
        spawningWave = true;
        yield return new WaitForSeconds(timeBetweenWaves);

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            int randEnemy = Random.Range(0, enemyPrefab.Length);
            Instantiate(enemyPrefab[randEnemy], new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            yield return new WaitForSeconds(timeBetweenEnemySpawn);
        }

        spawningWave = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
