using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownButtonHandler : MonoBehaviour
{
    public GameObject Player;
    private PlayerMovementScript script;

    public void Start()
    {
        script = Player.GetComponent<PlayerMovementScript>();
    }
    public void MoveDown()
    {
        script.MoveDown();
    }

    public void MoveStop()
    {
        script.MoveStop();
    }
}
