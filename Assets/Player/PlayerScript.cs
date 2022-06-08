using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public int life = 5;
    public float moveSpeed = 1f;

    public Text LifeText;

    public GameObject bullet1;
    public GameObject bulletStar2;

    private Rigidbody2D selfRB;

    private Transform launchPoint1;
    private Transform launchPoint2;
    private Transform launchPointCenter;

    public Transform TopLimit;
    public Transform BottomLimit;
    public Transform RightLimit;
    public Transform LeftLimit;


    public GameObject playerExplosion;
    // Start is called before the first frame update
    void Start()
    {
        selfRB = GetComponent<Rigidbody2D>();
        launchPoint1 = GameObject.Find("LaunchBullet1").transform;
        launchPoint2 = GameObject.Find("LaunchBullet2").transform;
        launchPointCenter = GameObject.Find("LaunchBulletCenter").transform;

        LifeText.text = life.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if (selfRB.position.y > TopLimit.position.y - TopLimit.localScale.y)
        {
            selfRB.velocity = new Vector2(0, -moveSpeed / 4);
        }

        if (selfRB.position.y < BottomLimit.position.y + BottomLimit.localScale.y)
        {
            selfRB.velocity = new Vector2(0, moveSpeed / 4);
        }

        if (selfRB.position.x > RightLimit.position.x + RightLimit.localScale.x)
        {
            selfRB.velocity = new Vector2(- moveSpeed / 4, 0);
        }

        if (selfRB.position.x < LeftLimit.position.x - LeftLimit.localScale.x)
        {
            selfRB.velocity = new Vector2(moveSpeed / 4, 0);
        }
    }

    public void MoveLeft()
    {
        selfRB.velocity = new Vector2(-moveSpeed, selfRB.velocity.y);
    }

    public void MoveRight()
    {
        selfRB.velocity = new Vector2(moveSpeed, selfRB.velocity.y);
    }

    public void MoveUp()
    {
        selfRB.velocity = new Vector2(selfRB.velocity.x, moveSpeed);
    }

    public void MoveDown()
    {
         selfRB.velocity = new Vector2(selfRB.velocity.x, -moveSpeed);
    }

    public void MoveStop()
    {
        selfRB.velocity = new Vector2(0, 0);
    }


    public void Fire()
    {
        Instantiate(bullet1, launchPoint1.position, Quaternion.identity);
        Instantiate(bullet1, launchPoint2.position, Quaternion.identity);
    }

    public void FireSpecial()
    {
        //GameObject bullet2 = Instantiate(bulletStar2, launchPointCenter.position, Quaternion.identity) as GameObject;
        //bullet2.GetComponent<BulletScript2>().angle = 2;
        GameObject bullet1 = Instantiate(bulletStar2, launchPointCenter.position, Quaternion.identity) as GameObject;
        bullet1.GetComponent<BulletScript2>().angle = 1;
        GameObject bullet0 = Instantiate(bulletStar2, launchPointCenter.position, Quaternion.identity) as GameObject;
        bullet0.GetComponent<BulletScript2>().angle = 0;
        GameObject bulletm1 = Instantiate(bulletStar2, launchPointCenter.position, Quaternion.identity) as GameObject;
        bulletm1.GetComponent<BulletScript2>().angle = -1;
        //GameObject bulletm2 = Instantiate(bulletStar2, launchPointCenter.position, Quaternion.identity) as GameObject;
        //bulletm2.GetComponent<BulletScript2>().angle = -2;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "basic_enemy")
        {
            this.life --;
            if (life < 0) life = 0;

            Instantiate(playerExplosion, gameObject.transform.position, Quaternion.identity);
        }

        if(collision.gameObject.tag == "bullet")
        {
            this.life-=2;
            if (life < 0) life = 0;

            Instantiate(playerExplosion, gameObject.transform.position, Quaternion.identity);
        }

        

        LifeText.text = this.life.ToString();

        if (collision.gameObject.tag == "bounds")
        {
            Debug.Log("Move into BOUND");
            this.MoveStop();
        }

        if (life <= 0)
        {
            Instantiate(playerExplosion, gameObject.transform.position, Quaternion.identity);
            Time.timeScale = 0f;
            GameOverPanelScript.instance.ShowGameOverPanel(true);
            GameOverPanelScript.instance.setStatusVisibility(false);
            GameOverPanelScript.instance.setGameOverVisibility(true);
            Time.timeScale = 0f;
            GameObject.Destroy(gameObject);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
