using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropsScript : MonoBehaviour
{
    public GameObject DropBox;
    public float moveSpeed = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void DropTheBox()
    {
        GameObject db = Instantiate(DropBox);
        db.transform.position = gameObject.transform.position;
    }
}
