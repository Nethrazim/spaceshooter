using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 1f;
    public GameObject bullet1;
    private Rigidbody2D selfRB;
    private Transform launchPoint1;
    private Transform launchPoint2;
    // Start is called before the first frame update
    void Start()
    {
        selfRB = GetComponent<Rigidbody2D>();
        launchPoint1 = GameObject.Find("LaunchBullet1").transform;
        launchPoint2 = GameObject.Find("LaunchBullet2").transform;
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
        Debug.Log("asd");
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("COLLISION WITH PLAYER");
    }
}
