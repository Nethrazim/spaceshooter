using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFireHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    private PlayerScript playerScript;

    public void Start()
    {
        playerScript = Player.GetComponent<PlayerScript>();
    }

    public void Fire()
    {
        playerScript.Fire();
    }

    public void FireSpecial()
    {
        playerScript.FireSpecial();
    }
}
