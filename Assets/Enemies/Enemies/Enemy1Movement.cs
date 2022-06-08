using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Movement : MonoBehaviour
{
    public GameObject explosion;
    public float moveSpeed = 2.0f;
    private Rigidbody2D selfRB;
    private int angle = 0;
    private float amplitude;
    
    private enum EnemyMovement { 
        Liniar,
        Sinusoidal
    }

    private EnemyMovement TypeOfMovement;

    // Start is called before the first frame update
    void Start()
    {
        System.Random randomGenerator = new System.Random();

        selfRB = GetComponent<Rigidbody2D>();
        amplitude = randomGenerator.Next(3, 7);
        
        int typeOfMovement = randomGenerator.Next(0, 2);
        TypeOfMovement = (EnemyMovement)typeOfMovement;
    }

    // Update is called once per frame
    void Update()
    {
        float x = transform.position.x;
        //float y = CalculateY();
        //selfRB.velocity = new Vector2(-moveSpeed, y);
        transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0, 0);
        if (transform.position.x < -25)
        {
            Destroy(gameObject);
        }
    }

    private float CalculateY()
    {
        /*if (TypeOfMovement == EnemyMovement.Sinusoidal)
        {
            return Mathf.Sin(Time.time * moveSpeed) * amplitude;
        }*/

        return selfRB.velocity.y;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet" || collision.gameObject.tag == "Player")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
