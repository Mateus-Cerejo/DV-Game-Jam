using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void ClosePausePanel()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void BackToLevels()
    {
        SceneManager.LoadScene("Levels");
    }
}
