using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsMenu : MonoBehaviour
{
    private void Start()
    {
       GameObject[] buttons = GameObject.FindGameObjectsWithTag("Level button");

       for( int i = 0; i < buttons.Length; i++)
        {
            if (int.Parse(buttons[i].name.Split(" ")[1]) > PlayerInfo.GetProgress())
            {
                buttons[i].GetComponent<Button>().interactable = false;
            }
        }
    }

    public void ChooseLevel(int buttonNumb)
    {
        SceneManager.LoadScene("Level " + buttonNumb);
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
