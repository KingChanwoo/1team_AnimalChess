using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage1 : MonoBehaviour
{
    public GamePlayController gamePlayController;
    public AIopponent aiOpponent;
    public UIController uiController;
    public Text resultText;



    public void Round(int r)
    {
        if (r == 1)
        {
            // AddEnemy(int 유닛ID,int x좌표,int z좌표,float 강함 비율(%))
            // 아래 형식 복사해서 값만 바꿔서 사용
            // 원하는 유닛 수 만큼 복사해서 사용
            // 본래 능력치의 몇 %로 구현할 것인지 입력하여 사용(100% = 100)
            // 123~ 141
            aiOpponent.AddEnemy(125, 1, 2,100); //125
            aiOpponent.AddEnemy(125, 5, 2,100); //125
        }
        else if (r == 2)
        {
            aiOpponent.AddEnemy(125, 1, 2,100);
            aiOpponent.AddEnemy(125, 5, 2,100);
            aiOpponent.AddEnemy(125, 3, 1,100);
        }
        else if (r == 3)
        {
            aiOpponent.AddEnemy(125, 1, 2, 100);
            aiOpponent.AddEnemy(125, 5, 2, 100);
            aiOpponent.AddEnemy(125, 3, 1, 100);
        }
        else if (r == 4)
        {
            aiOpponent.AddEnemy(125, 1, 2, 100);
            aiOpponent.AddEnemy(125, 5, 2, 100);
            aiOpponent.AddEnemy(125, 3, 1, 100);
            aiOpponent.AddEnemy(127, 2, 0, 100);
            aiOpponent.AddEnemy(127, 4, 0, 100);
        }
        else if (r == 5)
        {

        }
        else if (r == 6)
        {

        }
        else if (r == 7)
        {

        }
        else if (r == 8)
        {

        }
        else if (r == 9)
        {

        }
        else if (r == 10)
        {

        }
        else if (r == 11)
        {

        }
        else if (r == 12)
        {

        }
        else if (r == 13)
        {

        }
        else if (r == 14)
        {

        }
        else if (r == 15)
        {

        }
        else if (r == 16)
        {

        }
        else if (r == 17)
        {

        }
        else if (r == 18)
        {

        }
        else if (r == 19)
        {

        }
        else if (r == 20)
        {

        }
        else if (r == 21)
        {

        }
        else if (r == 22)
        {

        }
        else if (r == 23)
        {

        }
        else if (r == 24)
        {

        }
        else if (r == 25)
        {

        }
        else if (r == 27)
        {

        }
        else if (r == 28)
        {

        }
        else if (r == 29)
        {

        }
        else if (r == 30)
        {

        }
        else if (r == 31)
        {
            resultText.text = "승리";
            PlayerPrefs.SetInt("s1PlayerHP", gamePlayController.currentHP);
            uiController.ResultScreen();
        }
    }
    
    
    //public void round1(int n,)





    // Start is called before the first frame update
    void Start()
    {
        aiOpponent = GameObject.Find("Scripts").GetComponent<AIopponent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
