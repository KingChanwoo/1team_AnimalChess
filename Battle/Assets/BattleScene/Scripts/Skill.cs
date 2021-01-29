using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    GamePlayController gamePlayController;
    GameData gameData;
    
    public void SkillFire(int ID, ChampionController attacker, ChampionController target)
    {
        switch (ID)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            case 10:
                break;
            case 11:
                break;
            case 12:
                break;
            case 13:
                break;
            case 14:
                break;
            case 15:
                break;
            case 16:
                break;
            case 17:
                break;
            case 18:
                if(attacker.lvl == 1)
                {
                    gamePlayController.Summon(gameData.championsArray[146]);
                }
                else if (attacker.lvl == 2)
                {
                    gamePlayController.Summon(gameData.championsArray[147]);
                    gamePlayController.Summon(gameData.championsArray[147]);
                }
                else if (attacker.lvl == 3)
                {
                    gamePlayController.Summon(gameData.championsArray[148]);
                    gamePlayController.Summon(gameData.championsArray[148]);
                    gamePlayController.Summon(gameData.championsArray[148]);
                }

                break;
            case 19:
                break;
            case 20:
                break;
            case 21:
                break;
            case 22:
                if(attacker.lvl == 1)
                {
                    gamePlayController.Summon(gameData.championsArray[143]);
                    gamePlayController.Summon(gameData.championsArray[143]);
                }
                else if (attacker.lvl == 2)
                {
                    gamePlayController.Summon(gameData.championsArray[144]);
                    gamePlayController.Summon(gameData.championsArray[144]);
                    gamePlayController.Summon(gameData.championsArray[144]);
                }
                else if (attacker.lvl == 3)
                {
                    gamePlayController.Summon(gameData.championsArray[145]);
                    gamePlayController.Summon(gameData.championsArray[145]);
                    gamePlayController.Summon(gameData.championsArray[145]);
                    gamePlayController.Summon(gameData.championsArray[145]);
                    gamePlayController.Summon(gameData.championsArray[145]);
                }
                break;
            case 23:
                break;
            case 24:
                if (attacker.lvl == 1)
                {
                    gamePlayController.Summon(gameData.championsArray[149]);
                }
                else if (attacker.lvl == 2)
                {
                    gamePlayController.Summon(gameData.championsArray[150]);
                }
                else if (attacker.lvl == 3)
                {
                    gamePlayController.Summon(gameData.championsArray[151]);
                }
                break;
            case 25:
                break;
            case 26:
                break;
            case 27:
                break;
            case 28:
                break;
            case 29:
                break;
            case 30:
                break;
            case 31:
                break;
            case 32:
                break;
            case 33:
                break;
            case 34:
                break;
            case 35:
                break;
            case 36:
                break;
            case 37:
                break;
            case 38:
                break;
            case 39:
                break;
            case 40:
                break;
            case 41:
                break;
            case 42:
                break;
        }
    }








    // Start is called before the first frame update
    void Start()
    {
        gamePlayController = GameObject.Find("Scripts").GetComponent<GamePlayController>();
        gameData = GameObject.Find("Scripts").GetComponent<GameData>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    
}
