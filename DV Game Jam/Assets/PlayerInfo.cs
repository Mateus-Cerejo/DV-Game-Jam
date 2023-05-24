using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo Instance;

    private static int playerProgress = 1;

    public static void UpdateProgress(int toLevel)
    {
        playerProgress = (toLevel < playerProgress)? playerProgress : toLevel;
    }

    public static int GetProgress()
    {
        return playerProgress;
    }

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
