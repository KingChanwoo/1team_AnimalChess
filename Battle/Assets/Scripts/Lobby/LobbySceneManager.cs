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
        nameSet = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        level.text = "" + playerInfo.playerLevel;
        dnaValue.text = "" + playerInfo.currentDNA;
        playerName.text = PlayerPrefs.GetString("playerName");

        if (nameSet == 0) nameSetting.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NameSet()
    {
        nameSet = 1;
        PlayerPrefs.SetInt("nameSet", nameSet);
        nameSetting.SetActive(false);

        PlayerPrefs.SetString("playerName", playerName.text);
    }


    //----------------------------------------------------------------
    //  화면 이동 함수
    public void PlayGame()
    {
        SceneManager.LoadScene("StageScene");
    }

    public void Quest()
    {
        SceneManager.LoadScene("QuestScene");
    }

    public void Store()
    {
        SceneManager.LoadScene("StoreScene");
    }

    public void Unit()
    {
        SceneManager.LoadScene("UnitScene");
    }

    public void PlayerInfo()
    {
        SceneManager.LoadScene("PlayerInfoScene");
    }

    public void Home()
    {
        SceneManager.LoadScene("LobbyScene");
    }

    public void Stage1()
    {
        SceneManager.LoadScene("Stage1");
    }

    public void Stage2()
    {
        SceneManager.LoadScene("Stage2");
    }
}