using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public GameObject Boss;
    public bool hasBoss = false;
    
    private Transform spawnPoint1;
    private Transform spawnPoint2;
    private Transform spawnPoint3;
    private Transform spawnPoint4;
    private Transform spawnPoint5;
    public Transform[] ladderSpawnPoints;//something wrong
    public Transform[] ladderSpawnPointsReverse;
    public Transform[] group1SpawnPoints;
    public Transform[] group2SpawnPoints;//something wrong
    public Transform[] oblicalPath1;

    private System.Random randomGenerator = new System.Random();
    private int total = 100;
    private bool canGenerateBoss = true;

    private int cursorIdx = 0;
    private int[] enemyWaves = new int[30];
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint1 = GameObject.Find("SpawnPoint1").transform;
        spawnPoint2 = GameObject.Find("SpawnPoint2").transform;
        spawnPoint3 = GameObject.Find("SpawnPoint3").transform;
        spawnPoint4 = GameObject.Find("SpawnPoint4").transform;
        spawnPoint5 = GameObject.Find("SpawnPoint5").transform;

        generateEnemyWaves();
        
        InvokeRepeating("SpawnEnemy", 1.2f, 2.5f);
    }

    private void generateEnemyWaves()
    { 
        int i = 0;
        do
        {
            enemyWaves[i] = generateRandomInt(1,9);
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

    private void SpawnEnemy()
    {

        if (cursorIdx <= enemyWaves.Length - 1)
        {
            switch (enemyWaves[cursorIdx])
            {
                case 1:
                    int p = 0;
                    foreach (Transform t in group1SpawnPoints)
                    {
                        p++;
                        Instantiate(Enemy1, t.position, Quaternion.identity);
                    }
                    total -= p;
                    break;
                case 2:
                    int h = 0;
                    foreach (Transform t in ladderSpawnPoints)
                    {
                        h++;
                        Instantiate(Enemy1, t.position, Quaternion.identity);
                    }
                    total -= h;
                    break;
                case 3:
                    int x = 0;
                    foreach (Transform t in group1SpawnPoints)
                    {
                        x++;
                        Instantiate(Enemy1, t.position, Quaternion.identity);
                    }
                    total -= x;
                    break;
                case 4:
                    int i = 0;
                    foreach (Transform t in ladderSpawnPointsReverse)
                    {
                        i++;
                        Instantiate(Enemy1, t.position, Quaternion.identity);
                    }
                    total -= i;
                    break;
                case 5:
                    int j = 0;
                    foreach (Transform t in ladderSpawnPoints)
                    {
                        j++;
                        Instantiate(Enemy1, t.position, Quaternion.identity);
                    }
                    total -= j;
                    break;
                case 6:
                    int g = 0;
                    foreach (Transform t in group1SpawnPoints)
                    {
                        g++;
                        Instantiate(Enemy1, t.position, Quaternion.identity);
                    }
                    total -= g;
                    break;
                case 7:
                    int k = 0;
                    foreach (Transform t in ladderSpawnPoints)
                    {
                        k++;
                        Instantiate(Enemy1, t.position, Quaternion.identity);
                    }
                    total -= k;
                    break;
                case 8:
                    int m = 0;
                    foreach (Transform t in group2SpawnPoints)
                    {
                        m++;
                        Instantiate(Enemy1, t.position, Quaternion.identity);
                    }
                    total -= m;
                    break;
            }

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
