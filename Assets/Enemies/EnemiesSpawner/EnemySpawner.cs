using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public GameObject Boss;
    public bool canSpawn = false;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public Transform spawnPoint4;
    public Transform spawnPoint5;
    public Transform[] ladderSpawnPoints;//something wrong
    public Transform[] ladderSpawnPointsReverse;
    public Transform[] group1SpawnPoints;
    public Transform[] group2SpawnPoints;//something wrong
    public Transform[] oblicalPath1;
    public Transform[] queueSpawnPoints;
    public Transform[] queueSpawnPoints2;
    public Transform[] queueSpawnPoints3;

    private System.Random randomGenerator = new System.Random();
    private bool canGenerateBoss = true;

    public int cursorIdx = 0;
    public int[] enemyWaves = new int[25];

    private int sceneIndex = 0;

    private delegate void Spawn();
    private Spawn SpawnLevelEnemies;
    private delegate void GenerateEnemyWaves();
    private GenerateEnemyWaves GenerateEnemyWavesDel;
    // Start is called before the first frame update
    void Start()
    {
        SetupEnemySpawner();
        GenerateEnemyWavesDel();
        InvokeRepeating("SpawnEnemy", 2.2f, 3.0f);
        Invoke("CanSpawn", 3f);
    }

    private void SetupEnemySpawner()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (sceneIndex == 0)
        {
            SpawnLevelEnemies = SpawnLevel1;
            GenerateEnemyWavesDel = generateEnemyWavesLevel1;
        }
        if (sceneIndex == 1)
        {
            SpawnLevelEnemies = SpawnLevel2;
            GenerateEnemyWavesDel = generateEnemyWavesLevel2;
        }
    }

    private void generateEnemyWavesLevel1()
    { 
        int i = 0;
        do
        {
            enemyWaves[i] = generateRandomInt(1,9);
            i++;
        }
        while (i <= enemyWaves.Length - 1);
    }

    private void generateEnemyWavesLevel2()
    {
        int i = 0;
        do
        {
            enemyWaves[i] = generateRandomInt(1, 4);
            i++;
        }
        while (i <= enemyWaves.Length - 1);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private int generateRandomInt(int bottom, int top)
    {
        return randomGenerator.Next(bottom, top);
    }

    private void CanSpawn()
    {
        canSpawn = true;
    }
    private void SpawnLevel1()
    {
        switch (enemyWaves[cursorIdx])
        {
            case 1:
                foreach (Transform t in group1SpawnPoints)
                {
                    Instantiate(Enemy1, t.position, Quaternion.identity);
                }
                break;
            case 2:
                foreach (Transform t in ladderSpawnPoints)
                {
                    Instantiate(Enemy1, t.position, Quaternion.identity);
                }
                break;
            case 3:
                foreach (Transform t in group2SpawnPoints)
                {
                    Instantiate(Enemy2, t.position, Quaternion.identity);
                }
                break;
            case 4:
                foreach (Transform t in ladderSpawnPointsReverse)
                {
                    Instantiate(Enemy1, t.position, Quaternion.identity);
                }
                break;
            case 5:
                foreach (Transform t in group2SpawnPoints)
                {
                    Instantiate(Enemy2, t.position, Quaternion.identity);
                }
                break;
            case 6:
                foreach (Transform t in group1SpawnPoints)
                {
                    Instantiate(Enemy3, t.position, Quaternion.identity);
                }
                break;
            case 7:
                foreach (Transform t in ladderSpawnPoints)
                {
                    Instantiate(Enemy3, t.position, Quaternion.identity);
                }
                break;
            case 8:
                foreach (Transform t in group2SpawnPoints)
                {
                    Instantiate(Enemy1, t.position, Quaternion.identity);
                }
                break;
        }
    }
    private void SpawnLevel2()
    {
        switch (enemyWaves[cursorIdx])
        {
            case 1:
                switch (randomGenerator.Next(1, 3))
                {
                    case 1:
                        foreach (Transform t in queueSpawnPoints)
                        {
                            Instantiate(Enemy1, t.position, Quaternion.identity);
                        }
                    break;
                    case 2:
                        foreach (Transform t in queueSpawnPoints2)
                        {
                            Instantiate(Enemy1, t.position, Quaternion.identity);
                        }
                    break;
                    case 3:
                    foreach (Transform t in queueSpawnPoints3)
                    {
                        Instantiate(Enemy1, t.position, Quaternion.identity);
                    }
                    break;
                }
                break;
            case 2:
                foreach (Transform t in ladderSpawnPoints)
                {
                    Instantiate(Enemy3, t.position, Quaternion.identity);
                }
                break;
            case 3:
                foreach (Transform t in group2SpawnPoints)
                {
                    Instantiate(Enemy2, t.position, Quaternion.identity);
                }
                break;
        }
    }
    private void SpawnEnemy()
    {
        if (canSpawn)
        {
            if (cursorIdx <= enemyWaves.Length - 1)
            {
                SpawnLevelEnemies();
            }
            else
            {
                if (canGenerateBoss == true)
                {
                    Instantiate(Boss, spawnPoint1.position, Quaternion.identity);
                    canGenerateBoss = false;
                }

            }

            cursorIdx++;
        }
    }
}
