using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightButtonHandler : MonoBehaviour
{
    public GameObject Player;
    private PlayerScript playerScript;

    public void Start()
    {
        playerScript = Player.GetComponent<PlayerScript>();
    }

    public void MoveRight()
    {
        playerScript.MoveRight();
    }

    public void MoveStop()
    {
        playerScript.MoveStop();
    }
}
