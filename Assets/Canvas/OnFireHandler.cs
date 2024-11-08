using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFireHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    private PlayerFireScript script;

    public void Start()
    {
        script = Player.GetComponent<PlayerFireScript>();
    }

    public void Fire()
    {
        script.Fire();
    }

    public void FireSpecial()
    {
        script.FireSpecial();
    }
}
