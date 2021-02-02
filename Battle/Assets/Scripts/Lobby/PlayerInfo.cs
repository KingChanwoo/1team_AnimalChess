using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public string playerName = null;
    public int playerLevel = 1;
    public int maxEXP = 300;
    public int currentEXP = 0;

    public int currentDNA = 0;


    private void Awake()
    {
        playerName = PlayerPrefs.GetString("playerName");
        currentDNA = PlayerPrefs.GetInt("currenDNA");

        playerLevel = PlayerPrefs.GetInt("playerLv");
        currentEXP = PlayerPrefs.GetInt("currenEXP");

        currentEXP += PlayerPrefs.GetInt("rewardEXP");
        currentDNA += PlayerPrefs.GetInt("rewardDNA");
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("playerLv", playerLevel);
        PlayerPrefs.SetInt("currentEXP", currentEXP);
        PlayerPrefs.SetInt("currentDNA", currentDNA);

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
        }
    }


}