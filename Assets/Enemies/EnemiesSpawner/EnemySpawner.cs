using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Boss;
    public bool hasBoss = false;
    
    private Transform spawnPoint1;
    private Transform spawnPoint2;
    private Transform spawnPoint3;
    private Transform spawnPoint4;
    private Transform spawnPoint5;
    public Transform[] ladderSpawnPoints;
    public Transform[] ladderSpawnPointsReverse;
    public Transform[] group1SpawnPoints;
    public Transform[] group2SpawnPoints;
    public Transform[] oblicalPath1;

    private int spawnRandomValue;
    private System.Random randomGenerator = new System.Random();
    private int maxGeneratedOnSamePosition = 3;
    private int[] maxGenerated = new int[5];
    private int total = 1000;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint1 = GameObject.Find("SpawnPoint1").transform;
        spawnPoint2 = GameObject.Find("SpawnPoint2").transform;
        spawnPoint3 = GameObject.Find("SpawnPoint3").transform;
        spawnPoint4 = GameObject.Find("SpawnPoint4").transform;
        spawnPoint5 = GameObject.Find("SpawnPoint5").transform;

        InvokeRepeating("SpawnEnemy", 1.2f, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private int generateRandomInt(int b, int t)
    {
        return randomGenerator.Next(b, t);
    }

    private void SpawnEnemy()
    {

        if (total > 0)
        {
            switch (generateRandomInt(1,9))
            {
                case 1:
                    foreach (Transform t in group1SpawnPoints)
                    {
                        Instantiate(Enemy1, t.position, Quaternion.identity);
                    }
                    total--;
                    break;
                case 2:
                    foreach (Transform t in group2SpawnPoints)
                    {
                        Instantiate(Enemy1, t.position, Quaternion.identity);
                    }
                    total--;
                    break;
                case 3:
                    foreach (Transform t in ladderSpawnPoints)
                    {
                        Instantiate(Enemy1, t.position, Quaternion.identity);
                    }
                    break;
                case 4:
                    foreach (Transform t in group2SpawnPoints)
                    {
                        Instantiate(Enemy1, t.position, Quaternion.identity);
                    }
                    total--;
                    break;
                case 5:
                    foreach (Transform t in oblicalPath1)
                    {
                        Instantiate(Enemy2, t.position, Quaternion.identity);
                    }
                    total--;
                    break;
                case 6:
                    if (generateRandomInt(1, 10) % 4 == 0 && !hasBoss )
                    {
                        Instantiate(Boss, spawnPoint1.position, Quaternion.identity);
                        total--;
                        hasBoss = true;
                    }
                    break;
                case 7:
                    foreach (Transform t in ladderSpawnPoints)
                    {
                        Instantiate(Enemy1, t.position, Quaternion.identity);
                    }
                    break;
                case 8:
                    foreach (Transform t in ladderSpawnPointsReverse)
                    {
                        Instantiate(Enemy1, t.position, Quaternion.identity);
                    }
                    break;

            }
        }
        
    }
}
