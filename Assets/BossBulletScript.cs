using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletScript : MonoBehaviour
{
    private float moveSpeed = 16f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -=  new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        if (transform.position.x < -25)
        {
            Destroy(gameObject);
        }
    }
}
