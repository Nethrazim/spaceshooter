using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public int life = 5;
    public Text LifeText;
    private Rigidbody2D selfRB;
    public GameObject playerExplosion;
    private PlayerMovementScript movementScript;
    private PlayerFireScript fireScript;


    // Start is called before the first frame update
    void Start()
    {
        selfRB = GetComponent<Rigidbody2D>();
        movementScript = GetComponent<PlayerMovementScript>();
        fireScript = GetComponent<PlayerFireScript>();
        LifeText.text = life.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "basic_enemy")
        {
            this.life --;
            if (life < 0) life = 0;
            LifeText.text = this.life.ToString();
            Instantiate(playerExplosion, gameObject.transform.position, Quaternion.identity);
        }

        if(collision.gameObject.tag == "bullet")
        {
            this.life--;
            if (life < 0) life = 0;
            LifeText.text = this.life.ToString();
            Instantiate(playerExplosion, gameObject.transform.position, Quaternion.identity);
            
        }

        if (collision.gameObject.tag == "level1_star_weapon")
        {
            fireScript.specialBullets += 12;
            fireScript.SpecialBulletsText.text = fireScript.specialBullets.ToString();
        }


        if (collision.gameObject.tag == "bounds")
        {
            Debug.Log("Move into BOUND");
            movementScript.MoveStop();
        }

        if (life <= 0)
        {
            Instantiate(playerExplosion, gameObject.transform.position, Quaternion.identity);
            GameOverPanelScript.instance.ShowGameOverPanel(true);
            GameOverPanelScript.instance.setStatusVisibility(false);
            GameOverPanelScript.instance.setGameOverVisibility(true);
            GameOverPanelScript.instance.setContinueButtonVisibility(false);
            Time.timeScale = 0f;
            GameObject.Destroy(gameObject);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
