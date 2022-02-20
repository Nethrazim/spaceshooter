using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float _moveSpeed = 22f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(_moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            if (transform.position.x > 12.5f)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
