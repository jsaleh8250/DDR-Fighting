using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    private int enemyCount;
    private int waveNumber = 1;

    public float timeBetweenEnemySpawn;
    public float timeBetweenWaves = 30f;

    bool spawningWave;

    private void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

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
            Instantiate(enemyPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            yield return new WaitForSeconds(timeBetweenEnemySpawn);
        }

        spawningWave = false;
    }
}