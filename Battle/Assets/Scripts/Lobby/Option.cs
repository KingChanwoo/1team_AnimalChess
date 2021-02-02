using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Option : MonoBehaviour
{
    public Sound sound;

    public GameObject optionPannel;

    public Slider bgmVol;
    public Slider seVol;
    public Text bgmValue;
    public Text seValue;

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


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        VolumeSetting();
    }

    public void OptionPannel()
    {
        optionPannel.SetActive(true);
    }

    public void CloseOption()
    {
        optionPannel.SetActive(false);
    }

}