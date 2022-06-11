using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightButtonHandler : MonoBehaviour
{
    public GameObject Player;
    private PlayerMovementScript script;

    public void Start()
    {
        script = Player.GetComponent<PlayerMovementScript>();
    }

    public void MoveRight()
    {
        script.MoveRight();
    }

    public void MoveStop()
    {
        script.MoveStop();
    }
}
