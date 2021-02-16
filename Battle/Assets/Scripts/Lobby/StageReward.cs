using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageReward : MonoBehaviour
{
    public GameObject rewardPannel;

    public Text resultText;
    public Text dna;
    public Text exp;

    public int dnaValue;
    public int expValue;
    public int dnaRune = 0;
    public int expRune = 0;

    int usedRune;

    int playStage;
    int clearRound;
    int lastHP;
    int lastGold;

    private void Awake()
    {
        playStage = PlayerPrefs.GetInt("stageNum");
        clearRound = PlayerPrefs.GetInt("round");
        usedRune = PlayerPrefs.GetInt("usedRune");
        lastGold = PlayerPrefs.GetInt("lastGold");
    }

    // Start is called before the first frame update
    void Start()
    {
        ResultCalculate();
        if(clearRound == 30)
        {
            if (playStage == 1)
                lastHP = PlayerPrefs.GetInt("s1PlayerHP");
            else if (playStage == 2)
                lastHP = PlayerPrefs.GetInt("s2PlayerHP");
            PlayerPrefs.DeleteKey("stageNum");
        }
        PlayerPrefs.SetInt("rewardEXP", expValue + expRune);
        PlayerPrefs.SetInt("rewardDNA", dnaValue + dnaRune);
    }

    public void PassScene()
    {
        PlayerPrefs.DeleteKey("round");
        SceneManager.LoadScene("LobbyScene");
    }

    void ResultCalculate()
    {
        if (clearRound == 30)
        {
            resultText.text = "승리!";
            resultText.color = Color.yellow;

            expValue = 100 + (clearRound * 5);
            dnaValue = 35;

            if (usedRune == 2)
                expRune = (int)(expValue * 0.2f);
            else if (usedRune == 3)
                dnaRune = (int)(dnaValue * 0.2f);
            else if (usedRune == 6)
                expRune = (int)(lastGold * 2);
            else if (usedRune == 7)
                dnaRune = (int)(lastGold * 0.5f);


            exp.text = "" + expValue + " ( " + expRune + " )";
            dna.text = "" + dnaValue + " ( " + dnaRune + " )";
        }
        else
        {
            resultText.text = "패배!";
            resultText.color = Color.red;

            expValue = clearRound * 5;
            if (clearRound >= 25)
                dnaValue = 25;
            else if (clearRound >= 20)
                dnaValue = 20;
            else if (clearRound >= 15)
                dnaValue = 15;
            else if (clearRound >= 10)
                dnaValue = 10;
            else if (clearRound >= 5)
                dnaValue = 5;
            else
                dnaValue = 0;

            exp.text = "" + expValue;
            dna.text = "" + dnaValue;
        }
    }
}