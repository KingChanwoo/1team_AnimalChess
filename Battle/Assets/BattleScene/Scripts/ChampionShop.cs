using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Creates and stores champions available, XP and LVL purchase
/// </summary>
public class ChampionShop : MonoBehaviour
{
    public UIController uIController;
    public GamePlayController gamePlayController;
    public GameData gameData;

    ///Array to store available champions to purchase
    private Champion[] availableChampionArray;


    /// Start is called before the first frame update
    void Start()
    {
        RefreshShop(true);
    }

    /// Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Gives a level up the player
    /// </summary>
    public void BuyLvl()
    {
        gamePlayController.Buylvl();
    }

    /// <summary>
    /// Refreshes shop with new random champions
    /// </summary>
    public void RefreshShop(bool isFree)
    {
        //return if we dont have enough gold
        if (gamePlayController.currentGold < 2 && isFree == false)
            return;


        //init array
        availableChampionArray = new Champion[5];

        //fill up shop
        for (int i = 0; i < availableChampionArray.Length; i++)
        {
            //get a random champion
            Champion champion = GetRandomChampionInfo();

            //store champion in array
            availableChampionArray[i] = champion;

            //load champion to ui
            uIController.LoadShopItem(champion, i);

            //show shop items
            uIController.ShowShopItems();
        }

        //decrase gold
        if(isFree == false)
            gamePlayController.currentGold -= 2;

        //update ui
        uIController.UpdateUI();
    }

    /// <summary>
    /// Called when ui champion frame clicked
    /// </summary>
    /// <param name="index"></param>
    public void OnChampionFrameClicked(int index)
    {    
        bool isSucces = gamePlayController.BuyChampionFromShop(availableChampionArray[index]);

        if(isSucces)
            uIController.HideChampionFrame(index);
    }

    /// <summary>
    /// Returns a random champion
    /// </summary>
    public Champion GetRandomChampionInfo()
    {

        List<int> shoplist1 = new List<int>();
        List<int> shoplist2 = new List<int>();
        List<int> shoplist3 = new List<int>();
        List<int> shoplist4 = new List<int>();
        List<int> shoplist5 = new List<int>();
        int j = 0;
        int dice = 0;
        for (int i = 0; i < gameData.championsArray.Length; i++)
        {
            Champion champion = gameData.championsArray[i];

            if (champion.cost == 1)
            {
                shoplist1.Add(i);
            }
            else if (champion.cost == 2)
            {
                shoplist2.Add(i);
            }
            else if (champion.cost == 3)
            {
                shoplist3.Add(i);
            }
            else if (champion.cost == 4)
            {
                shoplist4.Add(i);
            }
            else if(champion.cost == 5)
            {
                shoplist5.Add(i);
            }
        }

        if (gamePlayController.currentChampionLimit == 1)
        {
            j = Random.Range(0, shoplist1.Count);
            return gameData.championsArray[shoplist1[j]];
        }
        else if (gamePlayController.currentChampionLimit == 2)
        {
            dice = Random.Range(0, 100);
            if (dice <= 30)
            {
                j = Random.Range(0, shoplist2.Count);
                return gameData.championsArray[shoplist2[j]];
            }
            else
            {
                j = Random.Range(0, shoplist1.Count);
                return gameData.championsArray[shoplist1[j]];
            }
        }
        else if (gamePlayController.currentChampionLimit == 3)
        {
            dice = Random.Range(0, 100);
            if (dice <= 20)
            {
                j = Random.Range(0, shoplist3.Count);
                return gameData.championsArray[shoplist3[j]];
            }
            else if (dice <= 50)
            {
                j = Random.Range(0, shoplist2.Count);
                return gameData.championsArray[shoplist2[j]];
            }
            else
            {
                j = Random.Range(0, shoplist1.Count);
                return gameData.championsArray[shoplist1[j]];
            }
        }
        else if (gamePlayController.currentChampionLimit == 4)
        {
            dice = Random.Range(0, 100);
            if (dice <= 1)
            {
                j = Random.Range(0, shoplist4.Count);
                return gameData.championsArray[shoplist4[j]];
            }
            else if (dice <= 31)
            {
                j = Random.Range(0, shoplist3.Count);
                return gameData.championsArray[shoplist3[j]];
            }
            else if (dice <= 61)
            {
                j = Random.Range(0, shoplist2.Count);
                return gameData.championsArray[shoplist2[j]];
            }
            else
            {
                j = Random.Range(0, shoplist1.Count);
                return gameData.championsArray[shoplist1[j]];
            }
        }
        else if (gamePlayController.currentChampionLimit == 5)
        {
            dice = Random.Range(0, 100);
            if (dice <= 10)
            {
                j = Random.Range(0, shoplist4.Count);
                return gameData.championsArray[shoplist4[j]];
            }
            else if (dice <= 50)
            {
                j = Random.Range(0, shoplist3.Count);
                return gameData.championsArray[shoplist3[j]];
            }
            else if (dice <= 80)
            {
                j = Random.Range(0, shoplist2.Count);
                return gameData.championsArray[shoplist2[j]];
            }
            else
            {
                j = Random.Range(0, shoplist1.Count);
                return gameData.championsArray[shoplist1[j]];
            }
        }
        else if (gamePlayController.currentChampionLimit == 6)
        {
            dice = Random.Range(0, 100);
            if (dice <= 1)
            {
                j = Random.Range(0, shoplist5.Count);
                return gameData.championsArray[shoplist5[j]];
            }
            else if (dice <= 19)
            {
                j = Random.Range(0, shoplist4.Count);
                return gameData.championsArray[shoplist4[j]];
            }
            else if (dice <= 60)
            {
                j = Random.Range(0, shoplist3.Count);
                return gameData.championsArray[shoplist3[j]];
            }
            else if (dice <= 80)
            {
                j = Random.Range(0, shoplist2.Count);
                return gameData.championsArray[shoplist2[j]];
            }
            else
            {
                j = Random.Range(0, shoplist1.Count);
                return gameData.championsArray[shoplist1[j]];
            }
        }
        else if (gamePlayController.currentChampionLimit == 7)
        {
            dice = Random.Range(0, 100);
            if (dice <= 5)
            {
                j = Random.Range(0, shoplist5.Count);
                return gameData.championsArray[shoplist5[j]];
            }
            else if (dice <= 25)
            {
                j = Random.Range(0, shoplist4.Count);
                return gameData.championsArray[shoplist4[j]];
            }
            else if (dice <= 65)
            {
                j = Random.Range(0, shoplist3.Count);
                return gameData.championsArray[shoplist3[j]];
            }
            else if (dice <= 85)
            {
                j = Random.Range(0, shoplist2.Count);
                return gameData.championsArray[shoplist2[j]];
            }
            else
            {
                j = Random.Range(0, shoplist1.Count);
                return gameData.championsArray[shoplist1[j]];
            }
        }
        else if (gamePlayController.currentChampionLimit == 8)
        {
            dice = Random.Range(0, 100);
            if (dice <= 10)
            {
                j = Random.Range(0, shoplist5.Count);
                return gameData.championsArray[shoplist5[j]];
            }
            else if (dice <= 40)
            {
                j = Random.Range(0, shoplist4.Count);
                return gameData.championsArray[shoplist4[j]];
            }
            else if (dice <= 70)
            {
                j = Random.Range(0, shoplist3.Count);
                return gameData.championsArray[shoplist3[j]];
            }
            else if (dice <= 90)
            {
                j = Random.Range(0, shoplist2.Count);
                return gameData.championsArray[shoplist2[j]];
            }
            else
            {
                j = Random.Range(0, shoplist1.Count);
                return gameData.championsArray[shoplist1[j]];
            }
        }
        else if (gamePlayController.currentChampionLimit == 9)
        {
            dice = Random.Range(0, 100);
            if (dice <= 15)
            {
                j = Random.Range(0, shoplist5.Count);
                return gameData.championsArray[shoplist5[j]];
            }
            else if (dice <= 45)
            {
                j = Random.Range(0, shoplist4.Count);
                return gameData.championsArray[shoplist4[j]];
            }
            else if (dice <= 75)
            {
                j = Random.Range(0, shoplist3.Count);
                return gameData.championsArray[shoplist3[j]];
            }
            else if (dice <= 90)
            {
                j = Random.Range(0, shoplist2.Count);
                return gameData.championsArray[shoplist2[j]];
            }
            else
            {
                j = Random.Range(0, shoplist1.Count);
                return gameData.championsArray[shoplist1[j]];
            }
        }
        else if (gamePlayController.currentChampionLimit == 10)
        {
            dice = Random.Range(0, 100);
            if (dice <= 20)
            {
                j = Random.Range(0, shoplist5.Count);
                return gameData.championsArray[shoplist5[j]];
            }
            else if (dice <= 60)
            {
                j = Random.Range(0, shoplist4.Count);
                return gameData.championsArray[shoplist4[j]];
            }
            else if (dice <= 80)
            {
                j = Random.Range(0, shoplist3.Count);
                return gameData.championsArray[shoplist3[j]];
            }
            else if (dice <= 90)
            {
                j = Random.Range(0, shoplist2.Count);
                return gameData.championsArray[shoplist2[j]];
            }
            else
            {
                j = Random.Range(0, shoplist1.Count);
                return gameData.championsArray[shoplist1[j]];
            }
        }
        return gameData.championsArray[shoplist1[j]];

        //randomise a number
        // int rand = Random.Range(0, 8);

        //return from array
        // return gameData.championsArray[rand];
    }


}
