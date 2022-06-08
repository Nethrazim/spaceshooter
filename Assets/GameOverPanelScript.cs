using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanelScript : MonoBehaviour
{
    public static GameOverPanelScript instance;
    public RectTransform panelObject;

    public Text GameOverText;
    public Text StatusText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        ShowGameOverPanel(false);
        setGameOverVisibility(false);
        setStatusVisibility(false);
    }

    
    public void setGameOverVisibility(bool value)
    {
        if (!value)
        {
            GameOverText.gameObject.transform.localScale = new Vector3(0, 0, 0);
        }
        else
        {
            GameOverText.gameObject.transform.localScale = new Vector3(2, 2, 2);
        }
    }

    public void setStatusVisibility(bool value)
    {
        if (!value)
        {
            StatusText.gameObject.transform.localScale = new Vector3(0, 0, 0);
        }
        else
        {
            StatusText.gameObject.transform.localScale = new Vector3(2,2,2);
        }
            
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
