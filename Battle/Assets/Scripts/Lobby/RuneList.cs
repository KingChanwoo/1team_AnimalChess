using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RuneList : MonoBehaviour
{
    public GameObject[] runePanels;

    public RuneData runeData;

    public Text selectedRuneName;
    public Text selectedRuneExplain;
    public Image selectedRuneImage;

    int selectedRuneID = 0;


    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject go in runePanels)
        {
            go.GetComponent<Button>().enabled = false;
        }
        RunePrint(PlayerPrefs.GetInt("usedRune"));
        SelectMark();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < runeData.runesArray.Length; i++)
        {
            Rune rune = runeData.runesArray[i];

            runePanels[i].transform.Find("RuneImage").GetComponent<Image>().sprite = rune.runeImage;
            runePanels[i].transform.Find("Text").GetComponent<Text>().text = rune.runeName;
            runePanels[i].transform.Find("LockImage").transform.Find("LimitLevel").GetComponent<Text>().text = "Lv." + rune.limitLevel;

            if (PlayerPrefs.GetInt("playerLv") >= rune.limitLevel)
            {
                runePanels[i].transform.Find("LockImage").gameObject.SetActive(false);
                runePanels[i].GetComponent<Button>().enabled = true;
            }
        }
        
        



    }

    void SelectMark()
    {
        foreach(GameObject etc in runePanels)
        {
            etc.transform.Find("Image").gameObject.SetActive(false);
        }
        runePanels[selectedRuneID].transform.Find("Image").gameObject.SetActive(true);
    }

    public void ApplyRune()
    {
        SelectMark();
        PlayerPrefs.SetInt("UsedRune", selectedRuneID);
    }

    void RunePrint(int i)
    {
        selectedRuneName.text = runeData.runesArray[i].runeName;
        selectedRuneExplain.text = runeData.runesArray[i].runeInfo;
        selectedRuneImage.sprite = runeData.runesArray[i].runeImage;
        selectedRuneID = i;
    }

    public void Rune0Select()
    {
        RunePrint(0);
    }

    public void Rune1Select()
    {
        RunePrint(1);
    }

}
