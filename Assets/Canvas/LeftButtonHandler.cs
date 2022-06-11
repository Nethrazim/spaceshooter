using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftButtonHandler : MonoBehaviour
{
    public GameObject Player;
    private PlayerMovementScript script;

    public void Start()
    {
        script = Player.GetComponent<PlayerMovementScript>();
    }

    public void MoveLeft()
    {
        script.MoveLeft();
    }

    public void MoveStop()
    {
        script.MoveStop();
    }
}
