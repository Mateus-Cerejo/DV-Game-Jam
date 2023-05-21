using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject nextLevelBtn;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
    }

    public void RestartLevel()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<CircleCollider2D>().enabled = true;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player.GetComponent<PlayerHealth>().RestartLevel();
        player.GetComponent<PlayerScore>().RestartLevel();
    }

    public void NextLevel()
    {
        string sceneName = SceneManager.GetActiveScene().name.Split(" ")[1];
        SceneManager.LoadScene("Level " + (int.Parse(sceneName) + 1));
    }
        
    public void DisplayNextLevelBtn()
    {
        nextLevelBtn.SetActive(true);
    }
}
