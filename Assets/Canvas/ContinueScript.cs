using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueScript : MonoBehaviour
{
    public int maxLevels = 1;
    public void Continue()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex < maxLevels)
        {
            currentSceneIndex++;
        }
        GameOverPanelScript.instance.ShowGameOverPanel(false);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
