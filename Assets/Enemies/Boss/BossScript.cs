using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossScript : MonoBehaviour
{
    public GameObject hitExplosion;
    public GameObject bossDeathExplosion;
    public Text StatusText;
    private bool isAlive = true;

    public Transform[] routePoints;
    
    public Transform bossPosition;

    public Transform launchPoint1;

    public GameObject BossBullet;

    private float moveSpeed = 2.0f;
    private int index = 0;
    private System.Random randomGenerator = new System.Random();

    public int life = 100;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 2.0f, 3.0f);
    }

    public void Fire()
    {
        if(isAlive)
            Instantiate(BossBullet, launchPoint1.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            if (isAlive == true)
            {
                if (index < routePoints.Length)
                {
                    if (bossPosition.position.x == routePoints[index].position.x && bossPosition.position.y == routePoints[index].position.y)
                    {
                        moveSpeed = randomGenerator.Next(4, 8);
                        index++;
                    }
                    else
                    {
                        bossPosition.position = Vector2.MoveTowards(bossPosition.position, routePoints[index].position, moveSpeed * Time.deltaTime);
                    }
                }
                else
                {
                    index = 0;
                }
            }
            else
            {
            }
        } catch (Exception ex)
        {
        }
        
        
    }

    void OpenEndLevelPanel()
    {
        GameOverPanelScript.instance.setStatusVisibility(true);
        GameOverPanelScript.instance.setGameOverVisibility(false);
        GameOverPanelScript.instance.ShowGameOverPanel(true);
        GameOverPanelScript.instance.setContinueButtonVisibility(true);
        Time.timeScale = 0f;
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(isAlive == true && collision.gameObject.tag == "bullet")
        {
            life--;

            if (life < 1)
            {
                isAlive = false;
                Instantiate(bossDeathExplosion, transform.position, Quaternion.identity);
                this.gameObject.transform.localScale = new Vector3(0, 0, 0);
                Invoke("OpenEndLevelPanel", 2f);
            }
            else
            {
                Instantiate(hitExplosion, transform.position, Quaternion.identity);
            }
        }
    }
}
