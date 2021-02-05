using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoPrinter : MonoBehaviour
{
    public Text playerLevel;
    public Image currentEXP;



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("currentEXP"));
    }

    // Update is called once per frame
    void Update()
    {
        playerLevel.text = PlayerPrefs.GetInt("playerLv").ToString();
        currentEXP.fillAmount = (float)PlayerPrefs.GetInt("currentEXP") / 300.0f;
    }
}
