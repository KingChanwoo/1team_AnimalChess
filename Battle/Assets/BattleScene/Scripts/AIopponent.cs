﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controlls Enemy champions
/// </summary>
public class AIopponent : MonoBehaviour
{
    public ChampionShop championShop;
    public Map map;
    public UIController uIController;
    public GamePlayController gamePlayController;
    public GameData gameData;
    public Stage1 stage1;
    
    

    public GameObject[,] gridChampionsArray;

    public Dictionary<ChampionType, int> championTypeCount;
    public List<ChampionBonus> activeBonusList;

    public List<Champion> enemyList;
    public List<ChampionController> enemyArray;
    ///The damage that player takes when losing a round
    public int damageToPlayer = 0;
    public int round = 1;

    private void Awake()
    {
        gameData = GameObject.Find("Scripts").GetComponent<GameData>();
        stage1 = GameObject.Find("Scripts").GetComponent<Stage1>();
        round = 1;
    }
    /// <summary>
    /// Called when map is created
    /// </summary>
    public void OnMapReady()
    {
        gridChampionsArray = new GameObject[Map.hexMapSizeX, Map.hexMapSizeZ / 2];


        // 1라운드 유닛 배치
        stage1.Round(round);
        // AddRandomChampion();
    }

    /// <summary> 네 잘들립니다!
    /// Called when a stage is finished
    /// </summary>
    /// <param name="stage"></param>
    public void OnGameStageComplate(GameStage stage)
    {
        if (stage == GameStage.Preparation)
        {
            //start champion combat
            for (int x = 0; x < Map.hexMapSizeX; x++)
            {
                for (int z = 0; z < Map.hexMapSizeZ / 2; z++)
                {
                    //there is a champion
                    if (gridChampionsArray[x, z] != null)
                    {
                        //get character
                        ChampionController championController = gridChampionsArray[x, z].GetComponent<ChampionController>();

                        //start combat
                        championController.OnCombatStart();
                    }

                }
            }
        }

        if (stage == GameStage.Combat)
        {
            //totall damage player takes
            int damage = 0;
            Debug.Log(enemyArray.Count);
            for (int i = 0; i < enemyArray.Count; i++)
            {
                if (!enemyArray[i].isDead)
                {
                    damage += enemyArray[i].champion.damageToPlayer;
                }
            }
            Debug.Log(damage);
            //iterate champions
            //start champion combat
            /*
        for (int x = 0; x < Map.hexMapSizeX; x++)
        {
            for (int z = 0; z < Map.hexMapSizeZ / 2; z++)
            {
                //there is a champion
                if (gridChampionsArray[x, z] != null)
                {
                    //get character
                    ChampionController championController = gridChampionsArray[x, z].GetComponent<ChampionController>();

                    // 플레이어 패배 시, 생존 유닛 별 다른 데미지 적용/부여


                    for (int i = 0; i < enemyList.Count; i++)
                    {
                        if (gridChampionsArray[x, z].name == enemyList[i].prefab.name + "(Clone)")
                        {
                            //calculate player damage for every champion
                            if (championController.currentHealth > 0)
                            {
                                damage += enemyList[i].damageToPlayer;
                                Debug.Log("데미지" + damage);
                            }
                        }
                        break;  
                    }

                }

            }
        }
*/
            //player takes damage
            gamePlayController.TakeDamage(damage);
            
            if(damage == 0)
            {
                gamePlayController.winBonus = 1;
                gamePlayController.continuedWin++;
                gamePlayController.continuedLose = 0;
                round++;
            }
            else
            {
                gamePlayController.winBonus = 0;
                gamePlayController.continuedLose++;
                gamePlayController.continuedWin = 0;
            }
            

            ResetChampions();

            enemyArray.Clear();
            stage1.Round(round);
          //  AddRandomChampion();
        }
    }

    /// <summary>
    /// Returns empty position in the map grid
    /// </summary>
    /// <param name="emptyIndexX"></param>
    /// <param name="emptyIndexZ"></param>
    private void GetEmptySlot(out int emptyIndexX, out int emptyIndexZ)
    {
        emptyIndexX = -1;
        emptyIndexZ = -1;

        //get first empty inventory slot
        for (int x = 0; x < Map.hexMapSizeX; x++)
        {
            for (int z = 0; z < Map.hexMapSizeZ / 2; z++)
            {
                if (gridChampionsArray[x, z] == null)
                {
                    emptyIndexX = x;
                    emptyIndexZ = z;
                    break;
                }
            }    
        }
    }
    public void EnemySummon(int n, float powerRate)
    {
        int flag = 0;
        for (int x = 0; x < Map.hexMapSizeX; x++)
        {
            if (flag == 1)
            {
                break;
            }
            for (int z = 0; z < Map.hexMapSizeZ / 2; z++)
            {
                if (gridChampionsArray[x, z] == null)
                {
                    Champion enemy = gameData.championsArray[n];
                    enemy.damage = enemy.damage * (powerRate / 100);
                    enemy.health = enemy.health * (powerRate / 100);
                    //instantiate champion prefab
                    GameObject enemyPrefab = Instantiate(enemy.prefab);

                    //add champion to array
                    gridChampionsArray[x, z] = enemyPrefab;

                    Debug.Log(gridChampionsArray[x, z].name);
                    //get champion controller
                    ChampionController championController = enemyPrefab.GetComponent<ChampionController>();

                    //setup chapioncontroller
                    championController.Init(enemy, ChampionController.TEAMID_AI);

                    //set grid position
                    championController.SetGridPosition(Map.GRIDTYPE_HEXA_MAP, x, z+4);

                    //set position and rotation
                    championController.SetWorldPosition();
                    championController.SetWorldRotation();

                    enemyList.Add(enemy);
                    enemyArray.Add(championController);

                    championController.OnCombatStart();
                    flag = 1;
                    
                }
                if (flag == 1)
                {
                    break;
                }
            }

        }
    }

    /// <summary>
    /// Creates and adds a new random champion to the map
    /// </summary>
    public void AddEnemy(int n, int indexX, int indexZ, float powerRate)
    {
        //get an empty slot
        //int indexX;
        //int indexZ;
        //GetEmptySlot(out indexX, out indexZ);

        //dont add champion if there is no empty slot
        //if (indexX == -1 || indexZ == -1)
        //if (indexX == -1 || indexZ == -1)
        //    return;

        Champion enemy = gameData.championsArray[n];
        enemy.damage = enemy.damage * (powerRate/100);
        enemy.health = enemy.health * (powerRate/100);
        //instantiate champion prefab
        GameObject enemyPrefab = Instantiate(enemy.prefab);

        //add champion to array
        gridChampionsArray[indexX, indexZ] = enemyPrefab;

        //get champion controller
        ChampionController championController = enemyPrefab.GetComponent<ChampionController>();

        //setup chapioncontroller
        championController.Init(enemy, ChampionController.TEAMID_AI);

        //set grid position
        championController.SetGridPosition(Map.GRIDTYPE_HEXA_MAP, indexX, indexZ + 4);

        //set position and rotation
        championController.SetWorldPosition();
        championController.SetWorldRotation();

        enemyList.Add(enemy);
        enemyArray.Add(championController);

        //  //check for champion upgrade
        //  List<ChampionController> championList_lvl_1 = new List<ChampionController>();
        //  List<ChampionController> championList_lvl_2 = new List<ChampionController>();
        //  
        //  for (int x = 0; x < Map.hexMapSizeX; x++)
        //  {
        //      for (int z = 0; z < Map.hexMapSizeZ / 2; z++)
        //      {
        //          //there is a champion
        //          if (gridChampionsArray[x, z] != null)
        //          {
        //              //get character
        //              ChampionController cc = gridChampionsArray[x, z].GetComponent<ChampionController>();
        //  
        //              //check if is the same type of champion that we are buying
        //              if (cc.champion == enemy)
        //              {
        //                  if (cc.lvl == 1)
        //                      championList_lvl_1.Add(cc);
        //                  else if (cc.lvl == 2)
        //                      championList_lvl_2.Add(cc);
        //              }
        //          }
        //  
        //      }
        //  }
        //  
        //  //if we have 3 we upgrade a champion and delete rest
        //  if (championList_lvl_1.Count == 3)
        //  {
        //      //upgrade
        //      championList_lvl_1[2].UpgradeLevel();
        //  
        //      //destroy gameobjects
        //      Destroy(championList_lvl_1[0].gameObject);
        //      Destroy(championList_lvl_1[1].gameObject);
        //  
        //      //we upgrade to lvl 3
        //      if (championList_lvl_2.Count == 2)
        //      {
        //          //upgrade
        //          championList_lvl_1[2].UpgradeLevel();
        //  
        //          //destroy gameobjects
        //          Destroy(championList_lvl_2[0].gameObject);
        //          Destroy(championList_lvl_2[1].gameObject);
        //      }
        //  }


       CalculateBonuses();
    }

    /// <summary>
    /// Resets all owned champions on the grid 
    /// </summary>
    private void ResetChampions()
    {
        for (int x = 0; x < Map.hexMapSizeX; x++)
        {
            for (int z = 0; z < Map.hexMapSizeZ / 2; z++)
            {
                //there is a champion
                if (gridChampionsArray[x, z] != null)
                {
                    //get character
                    ChampionController championController = gridChampionsArray[x, z].GetComponent<ChampionController>();

                    //set position and rotation
                    Destroy(championController.gameObject);
                    



                }

            }
        }
    }

    /// <summary>
    /// Called when a game finished and needs restart
    /// </summary>
    public void Restart()
    {
        for (int x = 0; x < Map.hexMapSizeX; x++)
        {
            for (int z = 0; z < Map.hexMapSizeZ / 2; z++)
            {
                //there is a champion
                if (gridChampionsArray[x, z] != null)
                {
                    //get character
                    ChampionController championController = gridChampionsArray[x, z].GetComponent<ChampionController>();

                    Destroy(championController.gameObject);
                    gridChampionsArray[x, z] = null;

                }

            }
        }

        //AddRandomChampion();
        //AddRandomChampion();
    }

    /// <summary>
    /// Called when champion health goes belove 0
    /// </summary>
    public void OnChampionDeath()
    {
        bool allDead = IsAllChampionDead();

        if (allDead)
        {
            
            gamePlayController.EndRound();
        }
    }


    /// <summary>
    /// Checks if all champion is dead
    /// </summary>
    /// <returns></returns>
    private bool IsAllChampionDead()
    {
        int championCount = 0;
        int championDead = 0;
        //start own champion combat
        for (int x = 0; x < Map.hexMapSizeX; x++)
        {
            for (int z = 0; z < Map.hexMapSizeZ / 2; z++)
            {
                //there is a champion
                if (gridChampionsArray[x, z] != null)
                {
                    //get character
                    ChampionController championController = gridChampionsArray[x, z].GetComponent<ChampionController>();


                    championCount++;
                    
                    if (championController.isDead)
                        championDead++;


                }

            }
        }

        if (championDead == championCount)
            return true;

        return false;

    }

    /// <summary>
    /// Calculates champion bonuses
    /// </summary>
    private void CalculateBonuses()
    {
        //init dictionary
        championTypeCount = new Dictionary<ChampionType, int>();

        for (int x = 0; x < Map.hexMapSizeX; x++)
        {
            for (int z = 0; z < Map.hexMapSizeZ / 2; z++)
            {
                //there is a champion
                if (gridChampionsArray[x, z] != null)
                {
                    //get champion
                    Champion c = gridChampionsArray[x, z].GetComponent<ChampionController>().champion;

                    if (championTypeCount.ContainsKey(c.type1))
                    {
                        int cCount = 0;
                        championTypeCount.TryGetValue(c.type1, out cCount);

                        cCount++;

                        championTypeCount[c.type1] = cCount;
                    }
                    else
                    {
                        championTypeCount.Add(c.type1, 1);
                    }

                    if (championTypeCount.ContainsKey(c.type2))
                    {
                        int cCount = 0;
                        championTypeCount.TryGetValue(c.type2, out cCount);

                        cCount++;

                        championTypeCount[c.type2] = cCount;
                    }
                    else
                    {
                        championTypeCount.Add(c.type2, 1);
                    }

                }
            }
        }

        activeBonusList = new List<ChampionBonus>();

        foreach (KeyValuePair<ChampionType, int> m in championTypeCount)
        {
            ChampionBonus championBonus = m.Key.championBonus;

            //have enough champions to get bonus
            if (m.Value >= championBonus.championCount1)
            {
                activeBonusList.Add(championBonus);
            }
        }

    }

}
