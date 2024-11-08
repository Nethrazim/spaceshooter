using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStarScript : MonoBehaviour
{
    public float _moveSpeed = 62f;
    public Rigidbody2D rigidbody2D;
    public int angle = 1;
    // Start is called before the first frame update
    void Start()
    {
        //rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject)
        {
            switch (angle)
            {
                case 2:
                    rigidbody2D.velocity = new Vector2(_moveSpeed, _moveSpeed/4);
                    break;
                case 1:
                    rigidbody2D.velocity = new Vector2(_moveSpeed, _moveSpeed / 18);
                    break;
                case 0:
                    rigidbody2D.velocity = new Vector2(_moveSpeed, rigidbody2D.velocity.y);
                    break;
                case -1:
                    rigidbody2D.velocity = new Vector2(_moveSpeed, -(_moveSpeed / 18));
                    break;
                case -2:
                    rigidbody2D.velocity = new Vector2(_moveSpeed, -(_moveSpeed / 4));
                    break;
            }    
           
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
