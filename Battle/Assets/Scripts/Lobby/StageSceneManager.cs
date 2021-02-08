using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSceneManager : MonoBehaviour
{
    public GameObject stageInfoPannel;
    public Text stage;
    public Text round;

    public GameObject s1Image;
    public GameObject s2Image;

    public GameObject lockImage;

    public GameObject earth;

    Vector3 stage1Rotation = new Vector3(18,-107.5f,11.39f);
    Vector3 stage2Rotation = new Vector3(-90, 205.8f, 11.39f);

    bool rightClick = false;
    bool isRotate = false;

    int whatStage=1;

    // Start is called before the first frame update
    void Start()
    {
        Stage1Pirnt();
    }

    float x1 = 18f;
    float y1 = -107.5f;
    // Update is called once per frame
    void Update()
    {
        if (rightClick)
        {
            if (isRotate)
            {
                Quaternion stage1Quaternion = Quaternion.Euler(stage1Rotation);
                Quaternion stage2Quaternion = Quaternion.Euler(stage2Rotation);
                stageInfoPannel.SetActive(false);
                if (whatStage == 1)
                {
                    x1 -= 108.0f / 200.0f;
                    y1 += 313.3f / 200.0f;
                    earth.transform.rotation = Quaternion.Euler(x1, y1,11.39f);
                    if (x1 <= -90)
                    {
                        isRotate = false;
                        Stage2Pirnt();

                        stageInfoPannel.SetActive(true);
                        rightClick = false;
                    }
                }
                else if(whatStage == 2)
                {
                    x1 += 108.0f / 200.0f;
                    y1 -= 313.3f / 200.0f;
                    earth.transform.rotation = Quaternion.Euler(x1, y1, 11.39f);
                    if (x1 >= 18)
                    {
                        isRotate = false;
                        Stage1Pirnt();

                        stageInfoPannel.SetActive(true);
                        rightClick = false;
                    }
                }
            }
        }
    }

    public void RightBtn()
    {
        rightClick = true;
        isRotate = true;
    }

    void Stage1Pirnt()
    {
        whatStage = 1;
        stage.text = "Stage1";
        round.text = "구성 라운드 : 30 라운드";
        s2Image.SetActive(false);
        s1Image.SetActive(true);

        lockImage.SetActive(false);
    }

    void Stage2Pirnt()
    {
        whatStage = 2;
        stage.text = "Stage2";
        round.text = "구성 라운드 : 30 라운드";
        s1Image.SetActive(false);
        s2Image.SetActive(true);

        lockImage.SetActive(true);
    }

    public void EnterStage()
    {
        if (whatStage == 1) SceneManager.LoadScene("Stage1");
        else if (whatStage == 2) SceneManager.LoadScene("Stage2");
    }





}
