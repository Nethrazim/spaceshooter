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
        GameObject bullet2 = Instantiate(bulletStar2, launchPointCenter.position, Quaternion.identity) as GameObject;
        bullet2.GetComponent<BulletScript2>().angle = 2;
        GameObject bullet1 = Instantiate(bulletStar2, launchPointCenter.position, Quaternion.identity) as GameObject;
        bullet1.GetComponent<BulletScript2>().angle = 1;
        GameObject bullet0 = Instantiate(bulletStar2, launchPointCenter.position, Quaternion.identity) as GameObject;
        bullet0.GetComponent<BulletScript2>().angle = 0;
        GameObject bulletm1 = Instantiate(bulletStar2, launchPointCenter.position, Quaternion.identity) as GameObject;
        bulletm1.GetComponent<BulletScript2>().angle = -1;
        GameObject bulletm2 = Instantiate(bulletStar2, launchPointCenter.position, Quaternion.identity) as GameObject;
        bulletm2.GetComponent<BulletScript2>().angle = -2;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "basic_enemy")
        {
            this.life --;
            LifeText.text = this.life.ToString();
        }

        if (life == 0)
        {
            Instantiate(playerExplosion, gameObject.transform.position, Quaternion.identity);
            GameObject.Destroy(gameObject);
            Time.timeScale = 0f;
            GameOverPanelScript.instance.ShowGameOverPanel(true);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
