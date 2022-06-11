using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Script : MonoBehaviour
{
    public GameObject explosion;
    public float moveSpeed = 6.0f;
    private Rigidbody2D selfRB;
    private int angle = 0;
    private float amplitude;
    public int life = 2;
    private System.Random random = new System.Random();

    public int seedDropBoxValue = 2;
    // Start is called before the first frame update
    void Start()
    {
        System.Random randomGenerator = new System.Random();

        selfRB = GetComponent<Rigidbody2D>();
        amplitude = randomGenerator.Next(3, 7);
    }

    void Update()
    {
        float x = transform.position.x;
        transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0, 0);
        if (transform.position.x < -25)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet") 
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            life--;
            if (life < 0) life = 0;
            
        }

        if (collision.gameObject.tag == "Player")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            life = 0;
        }

        if (life == 0)
        {
            this.gameObject.transform.localScale = Vector3.zero;
            if(random.Next(0,10) % seedDropBoxValue == 0)
                gameObject.GetComponent<DropsScript>().DropTheBox();
            Destroy(gameObject, 1f);
        }
    }
}
