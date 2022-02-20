using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy1;
    public GameObject Boss;
    public bool hasBoss = false;
    private Transform spawnPoint1;
    private Transform spawnPoint2;
    private Transform spawnPoint3;
    private Transform spawnPoint4;
    private Transform spawnPoint5;
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

        InvokeRepeating("SpawnEnemy", 1.2f, 0.8f);
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
            switch (generateRandomInt(1,7))
            {
                case 1:
                    Instantiate(Enemy1, spawnPoint1.position, Quaternion.identity);
                    Instantiate(Enemy1, spawnPoint3.position, Quaternion.identity);
                    total -= 2;
                    break;
                case 2:
                    Instantiate(Enemy1, spawnPoint2.position, Quaternion.identity);
                    Instantiate(Enemy1, spawnPoint5.position, Quaternion.identity);
                    total -= 2;
                    break;
                case 3:
                    Instantiate(Enemy1, spawnPoint3.position, Quaternion.identity);
                    Instantiate(Enemy1, spawnPoint5.position, Quaternion.identity);
                    total -= 2;
                    break;
                case 4:
                    Instantiate(Enemy1, spawnPoint4.position, Quaternion.identity);
                    Instantiate(Enemy1, spawnPoint2.position, Quaternion.identity);
                    total -= 2;
                    break;
                case 5:
                    Instantiate(Enemy1, spawnPoint5.position, Quaternion.identity);
                    Instantiate(Enemy1, spawnPoint2.position, Quaternion.identity);
                    total -= 2;
                    break;
                case 6:
                    Debug.Log("6");
                    if (generateRandomInt(1, 10) % 4 == 0)
                    {
                        Instantiate(Boss, spawnPoint1.position, Quaternion.identity);
                        total--;
                    }
                    break;

            }
        }
        else if(!hasBoss)
        {
            Instantiate(Boss, spawnPoint5.position, Quaternion.identity);
            Instantiate(Boss, spawnPoint1.position, Quaternion.identity);
            hasBoss = true;
        }
        
    }
}
