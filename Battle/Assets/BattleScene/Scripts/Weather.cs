using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weather : MonoBehaviour
{
    GamePlayController gamePlayController;
    public GameObject rainIcon;
    public GameObject snowIcon;

    public GameObject rainPannel;
    public GameObject snowPannel;





    // Start is called before the first frame update
    void Start()
    {
        gamePlayController = GameObject.Find("Scripts").GetComponent<GamePlayController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gamePlayController.isRain)
        {
            rainIcon.SetActive(true);
        }
        else
        {
            rainIcon.SetActive(false);
        }

        if (gamePlayController.isSnow)
        {
            snowIcon.SetActive(true);
        }
        else
        {
            snowIcon.SetActive(false);
        }
    }

    public void RainExplainOn()
    {
        rainPannel.SetActive(true);
    }

    public void RainExplainOff()
    {
        rainPannel.SetActive(false);
    }

    public void SnowExplainOn()
    {
        snowPannel.SetActive(true);
    }

    public void SnowExplainOff()
    {
        snowPannel.SetActive(false);
    }
}
