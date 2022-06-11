using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerFireScript : MonoBehaviour
{
    public int specialBullets = 40;
    public GameObject basicBullet;
    public GameObject specialBullet;

    public Transform launchPoint1;
    public Transform launchPoint2;
    public Transform launchPointCenter;
    public Transform[] SpecialWeaponLvl2;

    public Text SpecialBulletsText;


    private int sceneIndex = 0;
    void Start()
    {
        launchPoint1 = GameObject.Find("LaunchBullet1").transform;
        launchPoint2 = GameObject.Find("LaunchBullet2").transform;
        launchPointCenter = GameObject.Find("LaunchBulletCenter").transform;

        SpecialBulletsText.text = specialBullets.ToString();

        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Fire()
    {
        Instantiate(basicBullet, launchPointCenter.position, Quaternion.identity);
    }

    public void FireSpecial()
    {

        if (specialBullets > 0)
        {
            switch (sceneIndex)
            {
                case 0:
                {
                    GameObject b1 = Instantiate(specialBullet, launchPointCenter.position, Quaternion.identity) as GameObject;
                    b1.GetComponent<BulletStarScript>().angle = 1;
                    GameObject b0 = Instantiate(specialBullet, launchPointCenter.position, Quaternion.identity) as GameObject;
                    b0.GetComponent<BulletStarScript>().angle = 0;
                    GameObject bm1 = Instantiate(specialBullet, launchPointCenter.position, Quaternion.identity) as GameObject;
                    bm1.GetComponent<BulletStarScript>().angle = -1;
                }
                break;
                case 1:
                {
                    foreach (Transform t in SpecialWeaponLvl2)
                    {
                        Instantiate(specialBullet, t.position, Quaternion.identity);
                    }
                }
                break;
            }
            specialBullets--;
            SpecialBulletsText.text = specialBullets.ToString();
        }
    }
}
