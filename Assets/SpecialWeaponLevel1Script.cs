using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialWeaponLevel1Script : MonoBehaviour
{
    public float moveSpeed = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(this.gameObject.transform.position.x);
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0, 0);;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
