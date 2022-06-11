using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpButtonHandler : MonoBehaviour
{
    public GameObject Player;
    private PlayerMovementScript playerMovementScript;

    public void Start()
    {
        playerMovementScript = Player.GetComponent<PlayerMovementScript>();
    }

    public void MoveUp()
    {
        playerMovementScript.MoveUp();
    }

    public void MoveStop()
    {
        playerMovementScript.MoveStop();
    }
}
