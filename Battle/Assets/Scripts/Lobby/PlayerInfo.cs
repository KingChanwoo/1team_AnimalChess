using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public string playerName = null;
    public int playerLevel = 1;
    public int maxEXP = 300;
    public int currentEXP;

    public int currentDNA;


    private void Awake()
    {
        playerName = PlayerPrefs.GetString("playerName");
        currentDNA = PlayerPrefs.GetInt("currenDNA");
        currentEXP = PlayerPrefs.GetInt("currenEXP");

        if (PlayerPrefs.HasKey("playerLv"))
            playerLevel = PlayerPrefs.GetInt("playerLv");

        if (PlayerPrefs.HasKey("rewardEXP"))
        {
            currentEXP += PlayerPrefs.GetInt("rewardEXP");
            currentDNA += PlayerPrefs.GetInt("rewardDNA");
            PlayerPrefs.SetInt("currentEXP", currentEXP);
            PlayerPrefs.SetInt("currentDNA", currentDNA);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("rewardEXP"))
        {
            PlayerPrefs.DeleteKey("rewardEXP");
            PlayerPrefs.DeleteKey("rewardDNA");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentEXP >= maxEXP)
        {
            currentEXP = currentEXP - maxEXP;
            playerLevel++;
            PlayerPrefs.SetInt("playerLv", playerLevel);
            PlayerPrefs.SetInt("currentEXP", currentEXP);
        }

        
    }


}