using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Script : MonoBehaviour
{
    public GameObject explosion;
    public float moveSpeed = 6.0f;
    public Transform _transform;
    public Transform[] routePoints;
    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Math.Round(_transform.position.x,2) == Math.Round(routePoints[index].position.x,2) && Math.Round(_transform.position.y,2) == Math.Round(routePoints[index].position.y,2))
        {
            index++;
        }
        else
        {
            _transform.position = Vector3.MoveTowards(_transform.position, routePoints[index].position, moveSpeed * Time.deltaTime);
        }

        if (index >= routePoints.Length)
        {
            index = 0;
        }

        if (_transform.position.x < -25)
        {
            Destroy(gameObject);
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            Instantiate(explosion, _transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }
}
