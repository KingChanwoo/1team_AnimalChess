using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LobbySceneManager : MonoBehaviour
{
    public Text playerName;

    public PlayerInfo playerInfo;
    EventSystem eventSystem;

    public Text level;
    public Text dnaValue;

    public GameObject nameSetting;



    int nameSet = 0;

    private void Awake()
    {
        nameSet = PlayerPrefs.GetInt("nameSet");

    }
    // Start is called before the first frame update
    void Start()
    {
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        
        if(SceneManager.GetActiveScene().name == "LobbyScene")
        {
            if (nameSet == 0) nameSetting.SetActive(true);
        }
        playerName.text = PlayerPrefs.GetString("playerName");
    }

    // Update is called once per frame
    void Update()
    {
        level.text = "" + playerInfo.playerLevel;
        dnaValue.text = "" + playerInfo.currentDNA;
    }

    public void NameSet()
    {
        nameSet = 1;
        PlayerPrefs.SetInt("nameSet", nameSet);
        PlayerPrefs.SetString("playerName", playerName.text);
        nameSetting.SetActive(false);

    }


    //----------------------------------------------------------------
    //  화면 이동 함수
    public void PlayGame()
    {
        PlayerPrefs.SetInt("currentEXP", playerInfo.currentEXP);
        PlayerPrefs.SetInt("currentDNA", playerInfo.currentDNA);
        SceneManager.LoadScene("StageScene");
    }

    public void Quest()
    {
        PlayerPrefs.SetInt("currentEXP", playerInfo.currentEXP);
        PlayerPrefs.SetInt("currentDNA", playerInfo.currentDNA);
        SceneManager.LoadScene("QuestScene");
    }

    public void Store()
    {
        PlayerPrefs.SetInt("currentEXP", playerInfo.currentEXP);
        PlayerPrefs.SetInt("currentDNA", playerInfo.currentDNA);
        SceneManager.LoadScene("StoreScene");
    }

    public void Unit()
    {
        PlayerPrefs.SetInt("currentEXP", playerInfo.currentEXP);
        PlayerPrefs.SetInt("currentDNA", playerInfo.currentDNA);
        SceneManager.LoadScene("UnitScene");
    }

    public void PlayerInfo()
    {
        PlayerPrefs.SetInt("currentEXP", playerInfo.currentEXP);
        PlayerPrefs.SetInt("currentDNA", playerInfo.currentDNA);
        SceneManager.LoadScene("PlayerInfoScene");
    }

    public void Home()
    {
        PlayerPrefs.SetInt("currentEXP", playerInfo.currentEXP);
        PlayerPrefs.SetInt("currentDNA", playerInfo.currentDNA);
        SceneManager.LoadScene("LobbyScene");
    }

    public void Stage1()
    {
        PlayerPrefs.SetInt("currentEXP", playerInfo.currentEXP);
        PlayerPrefs.SetInt("currentDNA", playerInfo.currentDNA);
        SceneManager.LoadScene("Stage1");
    }

    public void Stage2()
    {
        PlayerPrefs.SetInt("currentEXP", playerInfo.currentEXP);
        PlayerPrefs.SetInt("currentDNA", playerInfo.currentDNA);
        SceneManager.LoadScene("Stage2");
    }
}