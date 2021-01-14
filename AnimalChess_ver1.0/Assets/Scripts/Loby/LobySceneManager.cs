﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class LobySceneManager : MonoBehaviour
{
    public GameObject optionPanel;
    EventSystem eventSystem;

    // Start is called before the first frame update
    void Start()
    {
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //----------------------------------------------------------------
    //화면 이동 함수
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

    public void Option()
    {
        optionPanel.SetActive(true);
    }
    public void OptionClose()
    {
        optionPanel.SetActive(false);
    }
}
