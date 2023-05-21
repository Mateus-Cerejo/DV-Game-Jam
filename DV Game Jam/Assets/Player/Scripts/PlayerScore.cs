using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI strokesText;
    [SerializeField] private int maxStrokes;

    private int curStrokes;
    private bool won;
    private void Start()
    {
        won = false;
        strokesText.text = "0 / " + maxStrokes;
    }

    public void IncStrokes()
    {
        strokesText.text = ++curStrokes + " / " + maxStrokes;
    }

    public bool ReachedMaxStrokes() { return curStrokes >= maxStrokes; }

    public void Win() { won = true; }

    public bool hasWon() { return won; }

    public void RestartLevel()
    {
        curStrokes = 0;
        strokesText.text = "0 / " + maxStrokes;
        won = false;
    }
}
