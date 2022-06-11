using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public float moveSpeed = 1f;
    private Rigidbody2D selfRB;
    public Transform TopLimit;
    public Transform BottomLimit;
    public Transform RightLimit;
    public Transform LeftLimit;
    // Start is called before the first frame update
    void Start()
    {
        selfRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (selfRB.position.y > TopLimit.position.y - TopLimit.localScale.y)
        {
            selfRB.velocity = new Vector2(0, -moveSpeed / 4);
        }

        if (selfRB.position.y < BottomLimit.position.y + BottomLimit.localScale.y)
        {
            selfRB.velocity = new Vector2(0, moveSpeed / 4);
        }

        if (selfRB.position.x > RightLimit.position.x + RightLimit.localScale.x)
        {
            selfRB.velocity = new Vector2(-moveSpeed / 4, 0);
        }

        if (selfRB.position.x < LeftLimit.position.x - LeftLimit.localScale.x)
        {
            selfRB.velocity = new Vector2(moveSpeed / 4, 0);
        }
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

}
