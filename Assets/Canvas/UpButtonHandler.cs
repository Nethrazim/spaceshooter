using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpButtonHandler : MonoBehaviour
{
    public GameObject Player;
    private PlayerScript playerScript;

    public void Start()
    {
        playerScript = Player.GetComponent<PlayerScript>();
    }

    public void MoveUp()
    {
        playerScript.MoveUp();
    }

    public void MoveStop()
    {
        playerScript.MoveStop();
    }
}
