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
            aiOpponent.AddEnemy(123, 6, 3,100); //125
        }
        else if (r == 2)
        {
            aiOpponent.AddEnemy(123, 6, 3,100);
            aiOpponent.AddEnemy(123, 5, 3,100);
        }
        else if (r == 3)
        {
            aiOpponent.AddEnemy(124, 6, 3, 100);
            aiOpponent.AddEnemy(123, 4, 3, 100);
            aiOpponent.AddEnemy(123, 2, 3, 100);
        }
        else if (r == 4)
        {
            aiOpponent.AddEnemy(124, 6, 3, 100);
            aiOpponent.AddEnemy(123, 4, 3, 100);
            aiOpponent.AddEnemy(123, 2, 3, 100);
            aiOpponent.AddEnemy(123, 0, 3, 100);
        }
        else if (r == 5)
        {
            aiOpponent.AddEnemy(125, 6, 3, 100);
            aiOpponent.AddEnemy(124, 4, 3, 100);
            aiOpponent.AddEnemy(123, 2, 3, 100);
            aiOpponent.AddEnemy(123, 0, 3, 100);
        }
        else if (r == 6)
        {
            aiOpponent.AddEnemy(124, 6, 3, 100);
            aiOpponent.AddEnemy(124, 3, 3, 100);
            aiOpponent.AddEnemy(124, 2, 3, 100);
            aiOpponent.AddEnemy(123, 0, 3, 100);
            aiOpponent.AddEnemy(123, 0, 3, 100);
        }
        else if (r == 7)
        {
            aiOpponent.AddEnemy(126, 6, 3, 100);
            aiOpponent.AddEnemy(124, 3, 3, 100);
            aiOpponent.AddEnemy(124, 2, 3, 100);
            aiOpponent.AddEnemy(124, 0, 3, 100);
            aiOpponent.AddEnemy(123, 0, 3, 100);
            aiOpponent.AddEnemy(123, 0, 3, 100);
        }
        else if (r == 8)
        {
            aiOpponent.AddEnemy(127, 6, 3, 100);
            aiOpponent.AddEnemy(126, 4, 3, 100);
            aiOpponent.AddEnemy(126, 2, 3, 100);
            aiOpponent.AddEnemy(124, 0, 3, 100);
            aiOpponent.AddEnemy(124, 5, 2, 100);
            aiOpponent.AddEnemy(124, 3, 2, 100);
        }
        else if (r == 9)
        {
            aiOpponent.AddEnemy(128, 6, 3, 100);
            aiOpponent.AddEnemy(127, 4, 3, 100);
            aiOpponent.AddEnemy(126, 2, 3, 100);
            aiOpponent.AddEnemy(126, 0, 3, 100);
            aiOpponent.AddEnemy(126, 5, 2, 100);
            aiOpponent.AddEnemy(124, 3, 2, 100);
        }
        else if (r == 10)
        {
            aiOpponent.AddEnemy(129, 6, 3, 100);
            aiOpponent.AddEnemy(128, 4, 3, 100);
            aiOpponent.AddEnemy(128, 2, 3, 100);
            aiOpponent.AddEnemy(127, 0, 3, 100);
            aiOpponent.AddEnemy(127, 5, 2, 100);
            aiOpponent.AddEnemy(126, 3, 2, 100);
        }
        else if (r == 11)
        {
            aiOpponent.AddEnemy(130, 6, 3, 100);
            aiOpponent.AddEnemy(130, 4, 3, 100);
            aiOpponent.AddEnemy(130, 2, 3, 100);
            aiOpponent.AddEnemy(130, 0, 3, 100);
            aiOpponent.AddEnemy(130, 5, 2, 100);
            aiOpponent.AddEnemy(130, 3, 2, 100);

        }
        else if (r == 12)
        {
            aiOpponent.AddEnemy(130, 6, 3, 100);
            aiOpponent.AddEnemy(130, 4, 3, 100);
            aiOpponent.AddEnemy(130, 2, 3, 100);
            aiOpponent.AddEnemy(130, 0, 3, 100);
            aiOpponent.AddEnemy(130, 5, 2, 100);
            aiOpponent.AddEnemy(131, 3, 2, 100);
            aiOpponent.AddEnemy(131, 1, 2, 100);
        }
        else if (r == 13)
        {
            aiOpponent.AddEnemy(130, 6, 3, 100);
            aiOpponent.AddEnemy(130, 4, 3, 100);
            aiOpponent.AddEnemy(130, 2, 3, 100);
            aiOpponent.AddEnemy(130, 0, 3, 100);
            aiOpponent.AddEnemy(130, 5, 2, 100);
            aiOpponent.AddEnemy(131, 3, 2, 100);
            aiOpponent.AddEnemy(131, 1, 2, 100);
            aiOpponent.AddEnemy(132, 0, 2, 100);
        }
        else if (r == 14)
        {
            aiOpponent.AddEnemy(130, 6, 3, 100);
            aiOpponent.AddEnemy(130, 4, 3, 100);
            aiOpponent.AddEnemy(130, 2, 3, 100);
            aiOpponent.AddEnemy(130, 0, 3, 100);
            aiOpponent.AddEnemy(131, 5, 2, 100);
            aiOpponent.AddEnemy(131, 3, 2, 100);
            aiOpponent.AddEnemy(132, 1, 2, 100);
            aiOpponent.AddEnemy(132, 0, 2, 100);
        }
        else if (r == 15)
        {
            aiOpponent.AddEnemy(133, 4, 3, 100);
            aiOpponent.AddEnemy(121, 2, 3, 100);
            aiOpponent.AddEnemy(132, 0, 3, 100);
            aiOpponent.AddEnemy(132, 5, 2, 100);
            aiOpponent.AddEnemy(130, 3, 2, 100);
            aiOpponent.AddEnemy(130, 1, 2, 100);
            aiOpponent.AddEnemy(130, 0, 2, 100);
        }
        else if (r == 16)
        {
            aiOpponent.AddEnemy(134, 6, 3, 100);
            aiOpponent.AddEnemy(134, 4, 3, 100);
            aiOpponent.AddEnemy(134, 2, 3, 100);
            aiOpponent.AddEnemy(134, 0, 3, 100);
            aiOpponent.AddEnemy(134, 5, 2, 100);
            aiOpponent.AddEnemy(134, 3, 2, 100);
            aiOpponent.AddEnemy(134, 1, 2, 100);
            aiOpponent.AddEnemy(134, 0, 2, 100);
        }
        else if (r == 17)
        {
            aiOpponent.AddEnemy(134, 6, 3, 100);
            aiOpponent.AddEnemy(134, 4, 3, 100);
            aiOpponent.AddEnemy(134, 2, 3, 100);
            aiOpponent.AddEnemy(134, 0, 3, 100);
            aiOpponent.AddEnemy(134, 5, 2, 100);
            aiOpponent.AddEnemy(134, 3, 2, 100);
            aiOpponent.AddEnemy(135, 1, 2, 100);
            aiOpponent.AddEnemy(135, 0, 2, 100);
        }
        else if (r == 18)
        {
            aiOpponent.AddEnemy(134, 6, 3, 100);
            aiOpponent.AddEnemy(134, 4, 3, 100);
            aiOpponent.AddEnemy(135, 2, 3, 100);
            aiOpponent.AddEnemy(135, 0, 3, 100);
            aiOpponent.AddEnemy(135, 5, 2, 100);
            aiOpponent.AddEnemy(135, 3, 2, 100);
            aiOpponent.AddEnemy(135, 1, 2, 100);
            aiOpponent.AddEnemy(135, 0, 2, 100);
        }
        else if (r == 19)
        {
            aiOpponent.AddEnemy(134, 6, 3, 100);
            aiOpponent.AddEnemy(135, 4, 3, 100);
            aiOpponent.AddEnemy(135, 2, 3, 100);
            aiOpponent.AddEnemy(135, 0, 3, 100);
            aiOpponent.AddEnemy(135, 5, 2, 100);
            aiOpponent.AddEnemy(135, 3, 2, 100);
            aiOpponent.AddEnemy(135, 1, 2, 100);
            aiOpponent.AddEnemy(135, 0, 2, 100);
        }
        else if (r == 20)
        {
            aiOpponent.AddEnemy(136, 6, 3, 100);
            aiOpponent.AddEnemy(135, 4, 3, 100);
            aiOpponent.AddEnemy(135, 2, 3, 100);
            aiOpponent.AddEnemy(135, 0, 3, 100);
            aiOpponent.AddEnemy(135, 5, 2, 100);
            aiOpponent.AddEnemy(134, 3, 2, 100);
            aiOpponent.AddEnemy(134, 1, 2, 100);
            aiOpponent.AddEnemy(134, 0, 2, 100);
        }
        else if (r == 21)
        {
            aiOpponent.AddEnemy(137, 6, 3, 100);
            aiOpponent.AddEnemy(137, 4, 3, 100);
            aiOpponent.AddEnemy(137, 2, 3, 100);
            aiOpponent.AddEnemy(137, 0, 3, 100);
            aiOpponent.AddEnemy(137, 5, 2, 100);
            aiOpponent.AddEnemy(137, 3, 2, 100);
            aiOpponent.AddEnemy(138, 1, 2, 100);
            aiOpponent.AddEnemy(138, 0, 2, 100);
        }
        else if (r == 22)
        {
            aiOpponent.AddEnemy(137, 6, 3, 100);
            aiOpponent.AddEnemy(137, 4, 3, 100);
            aiOpponent.AddEnemy(137, 2, 3, 100);
            aiOpponent.AddEnemy(137, 0, 3, 100);
            aiOpponent.AddEnemy(138, 5, 2, 100);
            aiOpponent.AddEnemy(138, 3, 2, 100);
            aiOpponent.AddEnemy(138, 1, 2, 100);
            aiOpponent.AddEnemy(138, 0, 2, 100);
        }
        else if (r == 23)
        {
            aiOpponent.AddEnemy(137, 6, 3, 100);
            aiOpponent.AddEnemy(137, 4, 3, 100);
            aiOpponent.AddEnemy(138, 2, 3, 100);
            aiOpponent.AddEnemy(138, 0, 3, 100);
            aiOpponent.AddEnemy(138, 5, 2, 100);
            aiOpponent.AddEnemy(138, 3, 2, 100);
            aiOpponent.AddEnemy(138, 1, 2, 100);
            aiOpponent.AddEnemy(138, 0, 2, 100);
        }
        else if (r == 24)
        {
            aiOpponent.AddEnemy(137, 6, 3, 100);
            aiOpponent.AddEnemy(138, 4, 3, 100);
            aiOpponent.AddEnemy(138, 2, 3, 100);
            aiOpponent.AddEnemy(138, 0, 3, 100);
            aiOpponent.AddEnemy(138, 5, 2, 100);
            aiOpponent.AddEnemy(138, 3, 2, 100);
            aiOpponent.AddEnemy(138, 1, 2, 100);
            aiOpponent.AddEnemy(138, 0, 2, 100);
        }
        else if (r == 25)
        {
            aiOpponent.AddEnemy(138, 6, 3, 100);
            aiOpponent.AddEnemy(138, 4, 3, 100);
            aiOpponent.AddEnemy(138, 2, 3, 100);
            aiOpponent.AddEnemy(138, 0, 3, 100);
            aiOpponent.AddEnemy(138, 5, 2, 100);
            aiOpponent.AddEnemy(137, 3, 2, 100);
            aiOpponent.AddEnemy(137, 1, 2, 100);
            aiOpponent.AddEnemy(127, 0, 2, 100);
        }
        else if (r == 26)
        {
            aiOpponent.AddEnemy(140, 6, 3, 100);
            aiOpponent.AddEnemy(140, 4, 3, 100);
            aiOpponent.AddEnemy(140, 2, 3, 100);
            aiOpponent.AddEnemy(140, 0, 3, 100);
            aiOpponent.AddEnemy(140, 5, 2, 100);
            aiOpponent.AddEnemy(140, 3, 2, 100);
            aiOpponent.AddEnemy(141, 1, 2, 100);
            aiOpponent.AddEnemy(141, 0, 2, 100);
        }
        else if (r == 27)
        {
            aiOpponent.AddEnemy(140, 6, 3, 100);
            aiOpponent.AddEnemy(140, 4, 3, 100);
            aiOpponent.AddEnemy(140, 2, 3, 100);
            aiOpponent.AddEnemy(140, 0, 3, 100);
            aiOpponent.AddEnemy(141, 5, 2, 100);
            aiOpponent.AddEnemy(141, 3, 2, 100);
            aiOpponent.AddEnemy(141, 1, 2, 100);
            aiOpponent.AddEnemy(141, 0, 2, 100);
        }
        else if (r == 28)
        {
            aiOpponent.AddEnemy(140, 6, 3, 100);
            aiOpponent.AddEnemy(140, 4, 3, 100);
            aiOpponent.AddEnemy(141, 2, 3, 100);
            aiOpponent.AddEnemy(141, 0, 3, 100);
            aiOpponent.AddEnemy(141, 5, 2, 100);
            aiOpponent.AddEnemy(141, 3, 2, 100);
            aiOpponent.AddEnemy(141, 1, 2, 100);
            aiOpponent.AddEnemy(141, 0, 2, 100);
        }
        else if (r == 29)
        {
            aiOpponent.AddEnemy(140, 6, 3, 100);
            aiOpponent.AddEnemy(141, 4, 3, 100);
            aiOpponent.AddEnemy(141, 2, 3, 100);
            aiOpponent.AddEnemy(141, 0, 3, 100);
            aiOpponent.AddEnemy(141, 5, 2, 100);
            aiOpponent.AddEnemy(141, 3, 2, 100);
            aiOpponent.AddEnemy(141, 1, 2, 100);
            aiOpponent.AddEnemy(141, 0, 2, 100);
        }
        else if (r == 30)
        {
            aiOpponent.AddEnemy(142, 6, 3, 100);
            aiOpponent.AddEnemy(139, 4, 3, 100);
            aiOpponent.AddEnemy(139, 2, 3, 100);
            aiOpponent.AddEnemy(141, 0, 3, 100);
            aiOpponent.AddEnemy(141, 5, 2, 100);
            aiOpponent.AddEnemy(141, 3, 2, 100);
            aiOpponent.AddEnemy(141, 1, 2, 100);
            aiOpponent.AddEnemy(141, 0, 2, 100);
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
