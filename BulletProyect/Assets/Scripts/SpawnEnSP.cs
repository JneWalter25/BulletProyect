using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnSP : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Camera mainCamera;
    private int maxEnemies = 10;
    private float spawnDelay = 4f;
    private int conditionDelay = 120;
    private float startTime;
    private int enemyCount = 0;
    public int EnemyCount
    {
        get { return enemyCount; }
        set { enemyCount = value; }
    }

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnDelay);
        startTime = Time.time;
    }

    void SpawnEnemy()
    {
        float timeElapsed = Time.time - startTime;
        if (timeElapsed>conditionDelay)
        {
            spawnDelay -= 0.5f;
            conditionDelay += 300;
        }
        if (enemyCount < maxEnemies)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            enemyCount++;
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        float buffer = 3f;
        Vector3 spawnPosition = new Vector3(Random.Range(mainCamera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).x - buffer, mainCamera.ViewportToWorldPoint(new Vector3(1f, 1f, 0f)).x + buffer),
                                            Random.Range(mainCamera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).y - buffer, mainCamera.ViewportToWorldPoint(new Vector3(1f, 1f, 0f)).y + buffer),
                                            0f);
        while (mainCamera.WorldToViewportPoint(spawnPosition).x > 0 && mainCamera.WorldToViewportPoint(spawnPosition).x < 1 && mainCamera.WorldToViewportPoint(spawnPosition).y > 0 && mainCamera.WorldToViewportPoint(spawnPosition).y < 1)
        {
            spawnPosition = new Vector3(Random.Range(mainCamera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).x - buffer, mainCamera.ViewportToWorldPoint(new Vector3(1f, 1f, 0f)).x + buffer),
                                            Random.Range(mainCamera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).y - buffer, mainCamera.ViewportToWorldPoint(new Vector3(1f, 1f, 0f)).y + buffer),
                                            0f);
        }
        return spawnPosition;
    }

}
