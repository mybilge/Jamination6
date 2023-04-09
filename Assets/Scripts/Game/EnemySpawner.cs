using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject wormEnemyPrefab;
    //[SerializeField] float wormEnemySpawnerTime = 10f;

    [SerializeField] GameObject spiderEnemyPrefab;
    [SerializeField] float enemySpawnerTime = 10f;



    [SerializeField] Transform[] spawnPoints;


    float timerWorm = 0f;
    float timerSpider = 0f;
    
    private void Start() {
        timerSpider = enemySpawnerTime /2;
    }

    private void Update() {
        timerWorm += Time.deltaTime;
        timerSpider += Time.deltaTime;

        if(timerWorm >= enemySpawnerTime)
        {   
            timerWorm = 0f;
            Instantiate(wormEnemyPrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
        }

        if (timerSpider >= enemySpawnerTime)
        {
            timerSpider = 0f;
            Instantiate(spiderEnemyPrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
        }


    }
}
