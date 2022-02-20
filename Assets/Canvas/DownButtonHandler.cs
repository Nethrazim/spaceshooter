using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownButtonHandler : MonoBehaviour
{
    public GameObject Player;

    public void MoveDown()
    {
        Player.GetComponent<PlayerScript>().MoveDown();
    }

    public void MoveStop()
    {
        Player.GetComponent<PlayerScript>().MoveStop();
    }
}
