using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftButtonHandler : MonoBehaviour
{
    public GameObject Player;
    private PlayerScript playerScript;

    public void Start()
    {
        playerScript = Player.GetComponent<PlayerScript>();
    }

    public void MoveLeft()
    {
        playerScript.MoveLeft();
    }

    public void MoveStop()
    {
        playerScript.MoveStop();
    }
}
