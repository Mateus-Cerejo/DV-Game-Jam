using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private int maxStats;
    [SerializeField] private TextMeshProUGUI strText;
    [SerializeField] private TextMeshProUGUI lifeText;
    [SerializeField] private TextMeshProUGUI sizeText;
    [SerializeField] private TextMeshProUGUI availableStatsText;
    [SerializeField] private float baseForce = 200;
    
    private int availableStats;
    private int strStat;
    private int lifesStat;
    private int sizeStat;
    private float playerBaseSize;
    private List<GameObject> statsButtons;

    // Start is called before the first frame update
    void Start()
    {
        statsButtons = new List<GameObject>();
        foreach (GameObject temp in GameObject.FindGameObjectsWithTag("statBtn"))
        {
            statsButtons.Add(temp);
        }
        playerBaseSize = player.transform.localScale.x;
        availableStats = maxStats;
        availableStatsText.text = "Available Stats: " + availableStats;
    }

    public void LockStats()
    {
        foreach (GameObject temp in statsButtons)
        {
            temp.SetActive(false);
        }
    }

    private void UpdateStats()
    {
        player.GetComponent<PlayerMovement>().SetForce(baseForce + baseForce * strStat);
        player.GetComponent<PlayerMovement>().SetSize(playerBaseSize - sizeStat * .12f);
        player.GetComponent<PlayerHealth>().SetInitialHealth(lifesStat + 1);
    }

    public void UnlockStats()
    {
        foreach (GameObject temp in statsButtons)
        {
            temp.SetActive(true);
        }
    }

    private void UpdateStatsUI()
    {
        strText.text = "Strenght:" + NumInBarsFormat(strStat);
        lifeText.text = "Lifes:" + NumInBarsFormat(lifesStat);
        sizeText.text = "Size:" + NumInBarsFormat(sizeStat);
        availableStatsText.text = "Available Stats: " + availableStats;
    }

    private string NumInBarsFormat(int num)
    {
        string outPut = "";
        for (int i = 0; i < num; i++)
        {
            outPut += " |";
        }
        return outPut;
    }

    public void IncStat(string statName)
    {
        if(availableStats > 0)
        {
            switch (statName)
            {
                case "strenght":
                    strStat++;
                    availableStats--;
                    break;
                case "lifes":
                    lifesStat++;
                    availableStats--;
                    break;
                case "size":
                    sizeStat++;
                    availableStats--;
                    break;
            }
            UpdateStatsUI();
            UpdateStats();
        }
    }

    public void DecStat(string statName)
    {
        switch (statName)
        {
            case "strenght":
                if (strStat > 0)
                {
                    strStat--;
                    availableStats++;
                }
                break;
            case "lifes":
                if (lifesStat > 0)
                {
                    lifesStat--;
                    availableStats++;
                }
                break;
            case "size":
                if (sizeStat > 0)
                {
                    sizeStat--;
                    availableStats++;
                }
                break;
        }
        UpdateStatsUI();
        UpdateStats();
    }

    public void RestartLevel()
    {
        strStat = 0;
        lifesStat = 0;
        sizeStat = 0;
        availableStats = maxStats;
        UpdateStats();
        UpdateStatsUI();
    }

}
