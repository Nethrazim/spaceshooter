using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownButtonHandler : MonoBehaviour
{
    public GameObject Player;
    private PlayerScript playerScript;

    public void Start()
    {
        playerScript = Player.GetComponent<PlayerScript>();
    }
    public void MoveDown()
    {
        playerScript.MoveDown();
    }

    public void MoveStop()
    {
        playerScript.MoveStop();
    }
}
