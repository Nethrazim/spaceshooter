using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float _moveSpeed = 62f;
    public Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject)
        {
            rigidbody2D.velocity = new Vector2(_moveSpeed, rigidbody2D.velocity.y);
            
            if (transform.position.x > 10.5f)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "basic_enemy")
        {
            Destroy(gameObject);
        }
    }
}
