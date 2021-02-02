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

    int clearRound;

    private void Awake()
    {
        clearRound = PlayerPrefs.GetInt("round");

    }

    // Start is called before the first frame update
    void Start()
    {
        if (clearRound == 30)
        {
            resultText.text = "승리!";
            resultText.color = Color.yellow;

            expValue = 100 + (clearRound * 5);
            dnaValue = 35;
            exp.text = "" + expValue;
            dna.text = "" + dnaValue;
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

    // Update is called once per frame
    float alpha = 0;
    void Update()
    {

    }

    public void PassScene()
    {
        PlayerPrefs.SetInt("rewardEXP", expValue);
        PlayerPrefs.SetInt("rewardDNA", dnaValue);

        PlayerPrefs.DeleteKey("round");
        SceneManager.LoadScene("LobbyScene");
    }
}