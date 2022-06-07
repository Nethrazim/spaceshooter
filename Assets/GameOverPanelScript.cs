using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPanelScript : MonoBehaviour
{
    public static GameOverPanelScript instance;
    public RectTransform panelObject;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        ShowGameOverPanel(false);
    }

    public void ShowGameOverPanel(bool value)
    {
        if (value)
            panelObject.localScale = new Vector3(1, 1, 1);
        else
            panelObject.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
