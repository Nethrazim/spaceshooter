using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpButtonHandler : MonoBehaviour
{
    public GameObject Player;
    
    public void MoveUp()
    {
        Player.GetComponent<PlayerScript>().MoveUp();
    }

    public void MoveStop()
    {
        Player.GetComponent<PlayerScript>().MoveStop();
    }
}
