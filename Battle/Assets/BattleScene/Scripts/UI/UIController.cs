using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Updates and controls UI elements
/// </summary>
public class UIController : MonoBehaviour
{
 
    public ChampionShop championShop;
    public GamePlayController gamePlayController;
    public AIopponent aiOpponent;
    public int stage;

    public GameObject[] championsFrameArray;
    public GameObject[] bonusPanels;
    public Sound sound;

    public Button ready;


    public Text timerText;
    public Text championCountText;
    public Text goldText;
    public Text hpText;
    public Text expText;
    public Text levelText;
    public Text unitnameText;
    public Text unitHpText;
    public Text unitattackText;

    public GameObject shop;
    public GameObject restartButton;
    public GameObject placementText;
    public GameObject gold;
    public GameObject bonusContainer;
    public GameObject bonusUIPrefab;
    public Image expgage;

    public GameObject optionPannel;
    public GameObject goLobbyPannel;

    public GameObject UnitInfo;

    public Slider bgmVol;
    public Slider seVol;
    public Text bgmValue;
    public Text seValue;


    /// <summary>
    /// Called when a chamipon panel clicked on shop UI
    /// </summary>
    /// 

    private void Update()
    {
        VolumeSetting();

    }
    public void OnChampionClicked()
    {
        //get clicked champion ui name
        string name = EventSystem.current.currentSelectedGameObject.transform.parent.name;

        //calculate index from name
        string defaultName = "champion container ";
        int championFrameIndex = int.Parse(name.Substring(defaultName.Length, 1));

        //message shop from click
        championShop.OnChampionFrameClicked(championFrameIndex);
    }

    void VolumeSetting()
    {
        bgmValue.text = bgmVol.value.ToString();
        seValue.text = seVol.value.ToString();
        for (int i = 0; i < sound.bgm.Count; i++)
        {
            sound.bgm[i].volume = bgmVol.value / 100;
        }
        for (int i = 0; i < sound.skillSE.Count; i++)
        {
            sound.skillSE[i].volume = seVol.value / 100;
        }

    }

    /// <summary>
    /// Called when refresh button clicked on shop UI
    /// </summary>
    public void Refresh_Click()
    {
        championShop.RefreshShop(false);
        AudioSource.PlayClipAtPoint(sound.skillSE[0].clip, this.gameObject.transform.position);
    }

    /// <summary>
    /// Called when buyXP button clicked on shop UI
    /// </summary>
    public void BuyXP_Click()
    {
        championShop.BuyLvl();
    }

    /// <summary>
    /// Called when restart button clicked on UI
    /// </summary>
    public void GoResultScene()
    {
        // 세이브해야할 곳 ( 라운드, HP )
        SceneManager.LoadScene("StageRewardScene");
    }

    /// <summary>
    /// hides chamipon ui frame
    /// </summary>
    public void HideChampionFrame(int index)
    {
        championsFrameArray[index].transform.Find("champion").gameObject.SetActive(false);
    }

    /// <summary>
    /// make shop items visible
    /// </summary>
    public void ShowShopItems()
    {
        //unhide all champion frames
        for (int i = 0; i < championsFrameArray.Length; i++)
        {
            championsFrameArray[i].transform.Find("champion").gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// displays champion info to given index on UI
    /// </summary>
    /// <param name="champion"></param>
    /// <param name="index"></param>
    public void LoadShopItem(Champion champion, int index)
    {
        //get unit frames
        Transform championUI = championsFrameArray[index].transform.Find("champion");
        Transform top = championUI.Find("top");
        Transform bottom = championUI.Find("bottom");
        Transform type1 = top.Find("type 1");
        Transform type2 = top.Find("type 2");
        Transform name = bottom.Find("Name");
        Transform cost = bottom.Find("Cost");
        Transform icon1 = top.Find("icon 1");
        Transform icon2 = top.Find("icon 2");
        Transform image = top.Find("Image");

        //assign texts from champion info to unit frames
        name.GetComponent<Text>().text = champion.uiname;
        cost.GetComponent<Text>().text = champion.cost.ToString();
        type1.GetComponent<Text>().text = champion.type1.displayName;
        type2.GetComponent<Text>().text = champion.type2.displayName;
        icon1.GetComponent<Image>().sprite = champion.type1.icon;
        icon2.GetComponent<Image>().sprite = champion.type2.icon;

        if (champion.cost == 1) image.GetComponent<Outline>().effectColor = Color.gray;
        else if (champion.cost == 2) image.GetComponent<Outline>().effectColor = Color.green;
        else if (champion.cost == 3) image.GetComponent<Outline>().effectColor = Color.blue;
        else if (champion.cost == 4) image.GetComponent<Outline>().effectColor = new Color(255,0,200);
        else if (champion.cost == 5) image.GetComponent<Outline>().effectColor = Color.yellow;
    }

    public void ViewUnitInfo(string name, string hp, string damage)
    {
        UnitInfo.SetActive(true);

        unitnameText.text = name;
        unitHpText.text = hp;
        unitattackText.text = damage;
    }

    public void CloseUnitInfo()
    {
        UnitInfo.SetActive(false);
    }

    /// <summary>
    /// Updates ui when needed
    /// </summary>
    public void UpdateUI()
    {





        goldText.text = gamePlayController.currentGold.ToString();
        placementText.GetComponent<Text>().text = "Round " + aiOpponent.round.ToString();
        championCountText.text = gamePlayController.currentChampionCount.ToString() + " / " + gamePlayController.currentChampionLimit.ToString();
        if (gamePlayController.currentChampionCount != gamePlayController.currentChampionLimit)
        {
            championCountText.color = Color.red;
        }
        else
        {
            championCountText.color = Color.white;
        }

        hpText.text = "HP " + gamePlayController.currentHP.ToString();

        levelText.text = "Lv : " + gamePlayController.currentChampionLimit.ToString();
        expText.text = gamePlayController.currentExp.ToString() + " / " + gamePlayController.needExp.ToString();

        expgage.fillAmount = gamePlayController.currentExp / gamePlayController.needExp;


        //hide bonusus UI
        foreach (GameObject go in bonusPanels)
        {
            go.SetActive(false);
        }


        //if not null
        if (gamePlayController.championTypeCount != null)
        {
            int i = 0;
            //iterate bonuses
            foreach (KeyValuePair<ChampionType, int> m in gamePlayController.championTypeCount)
            {
                //Now you can access the key and value both separately from this attachStat as:
                GameObject bonusUI = bonusPanels[i];
                bonusUI.transform.SetParent(bonusContainer.transform);
                bonusUI.transform.Find("icon").GetComponent<Image>().sprite = m.Key.icon;
                bonusUI.transform.Find("name").GetComponent<Text>().text = m.Key.displayName;
                bonusUI.transform.Find("Text").GetComponent<Text>().text = m.Key.championBonus.explain;
                bonusUI.transform.Find("Text").gameObject.SetActive(false);
                if (m.Key.championBonus.championCount2 == 0)
                {
                    bonusUI.transform.Find("count").GetComponent<Text>().text = m.Value.ToString() + " / " + m.Key.championBonus.championCount1.ToString();
                    bonusUI.transform.Find("count").GetComponent<Text>().color = Color.white;
                    if (m.Value >= m.Key.championBonus.championCount1)
                        bonusUI.transform.Find("count").GetComponent<Text>().color = Color.yellow;
                }
                else if (m.Key.championBonus.championCount3 == 0)
                {
                    if (m.Value <= m.Key.championBonus.championCount1)
                    {
                        bonusUI.transform.Find("count").GetComponent<Text>().text = m.Value.ToString() + " / " + m.Key.championBonus.championCount1.ToString();
                        bonusUI.transform.Find("count").GetComponent<Text>().color = Color.white;
                        if (m.Value == m.Key.championBonus.championCount1)
                            bonusUI.transform.Find("count").GetComponent<Text>().color = Color.yellow;
                    }
                    else
                    {
                        bonusUI.transform.Find("count").GetComponent<Text>().text = m.Value.ToString() + " / " + m.Key.championBonus.championCount2.ToString();
                        bonusUI.transform.Find("count").GetComponent<Text>().color = Color.white;
                        if (m.Value == m.Key.championBonus.championCount2)
                            bonusUI.transform.Find("count").GetComponent<Text>().color = Color.yellow;
                    }
                }
                else
                {
                    if (m.Value <= m.Key.championBonus.championCount1)
                    {
                        bonusUI.transform.Find("count").GetComponent<Text>().text = m.Value.ToString() + " / " + m.Key.championBonus.championCount1.ToString();
                        bonusUI.transform.Find("count").GetComponent<Text>().color = Color.white;
                        if (m.Value == m.Key.championBonus.championCount1)
                            bonusUI.transform.Find("count").GetComponent<Text>().color = Color.yellow;
                    }
                    else if (m.Value <= m.Key.championBonus.championCount2)
                    {
                        bonusUI.transform.Find("count").GetComponent<Text>().text = m.Value.ToString() + " / " + m.Key.championBonus.championCount2.ToString();
                        bonusUI.transform.Find("count").GetComponent<Text>().color = Color.white;
                        if (m.Value == m.Key.championBonus.championCount2)
                            bonusUI.transform.Find("count").GetComponent<Text>().color = Color.yellow;
                    }
                    else if (m.Value <= m.Key.championBonus.championCount3)
                    {
                        bonusUI.transform.Find("count").GetComponent<Text>().text = m.Value.ToString() + " / " + m.Key.championBonus.championCount3.ToString();
                        bonusUI.transform.Find("count").GetComponent<Text>().color = Color.white;
                        if (m.Value == m.Key.championBonus.championCount3)
                            bonusUI.transform.Find("count").GetComponent<Text>().color = Color.yellow;
                    }
                }
                bonusUI.SetActive(true);

                i++;
            }
        }
    }

    /// <summary>
    /// updates timer
    /// </summary>
    public void UpdateTimerText()
    {
        timerText.text = gamePlayController.timerDisplay.ToString();
    }

    /// <summary>
    /// sets timer visibility
    /// </summary>
    /// <param name="b"></param>
    public void SetTimerTextActive(bool b)
    {
        timerText.gameObject.SetActive(b);

        //  placementText.SetActive(b);
    }

    /// <summary>
    /// displays loss screen when game ended
    /// </summary>
    public void ResultScreen()
    {
        SetTimerTextActive(false);
        shop.SetActive(false);
        gold.SetActive(false);

        PlayerPrefs.SetInt("stageNum", stage);
        PlayerPrefs.SetInt("round", aiOpponent.round - 1);
        restartButton.SetActive(true);
    }

    /// <summary>
    /// displays game screen when game started
    /// </summary>
    public void ShowGameScreen()
    {
        SetTimerTextActive(true);
        shop.SetActive(true);
        gold.SetActive(true);


        restartButton.SetActive(false);
    }

    public GameObject close;
    public GameObject open;
    public bool isLock = false;
    public void ShopLock()
    {
        AudioSource.PlayClipAtPoint(sound.skillSE[5].clip, this.gameObject.transform.position);
        if (open.activeSelf == true)
        {
            close.SetActive(true);
            open.SetActive(false);
            isLock = true;
        }
        else
        {
            close.SetActive(false);
            open.SetActive(true);
            isLock = false;
        }
    }

    public void OptionPannel()
    {
        AudioSource.PlayClipAtPoint(sound.skillSE[0].clip, this.gameObject.transform.position);
        optionPannel.SetActive(true);
    }

    public void CloseOption()
    {
        AudioSource.PlayClipAtPoint(sound.skillSE[0].clip, this.gameObject.transform.position);
        optionPannel.SetActive(false);
    }

    public void GoLobbyPannel()
    {
        AudioSource.PlayClipAtPoint(sound.skillSE[0].clip, this.gameObject.transform.position);
        goLobbyPannel.SetActive(true);
    }

    public void Yes()
    {
        PlayerPrefs.SetInt("round", aiOpponent.round - 1);
        SceneManager.LoadScene("StageRewardScene");
    }

    public void No()
    {
        goLobbyPannel.SetActive(false);
    }
    






}