using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1 : MonoBehaviour
{
    public AIopponent aiOpponent;


    public void Round(int r)
    {
        if (r == 1)
        {
            // AddEnemy(int 유닛ID,int x좌표,int z좌표,float 강함 비율(%))
            // 아래 형식 복사해서 값만 바꿔서 사용
            // 원하는 유닛 수 만큼 복사해서 사용
            // 본래 능력치의 몇 %로 구현할 것인지 입력하여 사용(100% = 100)
            aiOpponent.AddEnemy(43, 1, 2,100);
            aiOpponent.AddEnemy(43, 5, 2,100);
        }
        else if (r == 2)
        {
            aiOpponent.AddEnemy(43, 1, 2,100);
            aiOpponent.AddEnemy(43, 5, 2,100);
            aiOpponent.AddEnemy(42, 3, 1,100);
        }
        else if (r == 3)
        {
            aiOpponent.AddEnemy(42, 1, 2, 100);
            aiOpponent.AddEnemy(42, 5, 2, 100);
            aiOpponent.AddEnemy(42, 3, 1, 100);
        }
        else if (r == 4)
        {
            aiOpponent.AddEnemy(42, 1, 2, 100);
            aiOpponent.AddEnemy(42, 5, 2, 100);
            aiOpponent.AddEnemy(42, 3, 1, 100);
            aiOpponent.AddEnemy(43, 2, 0, 100);
            aiOpponent.AddEnemy(43, 4, 0, 100);
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
        else if (r == 26)
        {

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
