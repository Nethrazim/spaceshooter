using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFireHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;

    public void Fire()
    {
        Player.GetComponent<PlayerScript>().Fire();
    }
}
