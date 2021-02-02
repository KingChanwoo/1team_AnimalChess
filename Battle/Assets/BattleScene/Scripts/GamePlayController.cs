using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum GameStage { Preparation, Combat, Loss };

/// <summary>
/// Controlls most of the game logic and player interactions
/// </summary>
public class GamePlayController : MonoBehaviour
{
    EventSystem eventSystem;

    List<ChampionController> summonlist = new List<ChampionController>();
    public List<ChampionController> skillrangeenemylist = new List<ChampionController>();
    public int gridT;
    public int gridX;
    public int gridZ;

    public GameObject Rain;
    public bool isRain;
    public bool isSnow;
    public GameObject Snow;
    public float weather = 0;
    public float weathercheck = 0;

    public Map map;
    public InputController inputController;
    public GameData gameData;
    public UIController uIController;
    public AIopponent aIopponent;
    public ChampionShop championShop;

    [HideInInspector]
    public GameObject[] ownChampionInventoryArray;
    [HideInInspector]
    public GameObject[] oponentChampionInventoryArray;
    [HideInInspector]
    public GameObject[,] gridChampionsArray;
    public List<ChampionController> championArray;

    public Text resultText;


    public GameStage currentGameStage;
    private float timer = 0;

    ///The time available to place champions
    public int PreparationStageDuration = 16;
    ///Maximum time the combat stage can last
    public int CombatStageDuration = 60;
    ///base gold value to get after every round
    public int baseGoldIncome = 5;
    public int winBonus = 0;

    public float currentExp = 0;
    public float needExp;



    public int currentChampionLimit = 1;
    [HideInInspector]
    public int currentChampionCount = 0;

    public int currentGold = 5;
    [HideInInspector]
    public int currentHP = 100;
    [HideInInspector]
    public int timerDisplay = 0;

    public Dictionary<ChampionType, int> championTypeCount;
    public Dictionary<ChampionBonus, int> activeBonus;
    public List<ChampionBonus> activeBonusList;
    public List<int> activeBonusNumList;

    public int continuedWin = 0;
    public int continuedLose = 0;

    public bool wealth = false;
    public float wealthMoney = 0;

    public bool summonSynergy = false;
    public float summonSynergyValue = 0;

    /// Start is called before the first frame update
    void Start()
    {
        //set starting gamestage
        currentGameStage = GameStage.Preparation;

        //init arrays
        ownChampionInventoryArray = new GameObject[Map.inventorySize];
        oponentChampionInventoryArray = new GameObject[Map.inventorySize];
        gridChampionsArray = new GameObject[Map.hexMapSizeX, Map.hexMapSizeZ / 2];

        CheckExp();
        uIController.UpdateUI();

        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
    }

    /// Update is called once per frame
    void Update()
    {
        //manage game stage
        if (currentGameStage == GameStage.Preparation)
        {
            //  timer += Time.deltaTime;
            //  
            //  timerDisplay = (int) (PreparationStageDuration - timer);
            //  
            //  uIController.UpdateTimerText();
            //  
            //  if (timer > PreparationStageDuration)
            //  {
            //      timer = 0;
            //  
            //      //  OnGameStageComplate();
            //  }
        }
        else if (currentGameStage == GameStage.Combat)
        {
            timer += Time.deltaTime;

            timerDisplay = (int)(CombatStageDuration - timer);

            uIController.UpdateTimerText();

            if (timer > CombatStageDuration)
            {
                timer = 0;

                OnGameStageComplate();
            }
        }

    }




    /// <summary>
    /// Adds champion from shop to inventory
    /// </summary>
    public bool BuyChampionFromShop(Champion champion)
    {
        //get first empty inventory slot
        int emptyIndex = -1;
        for (int i = 0; i < ownChampionInventoryArray.Length; i++)
        {
            if (ownChampionInventoryArray[i] == null)
            {
                emptyIndex = i;
                break;
            }
        }

        //return if no slot to add champion
        if (emptyIndex == -1)
            return false;

        //we dont have enought gold return
        if (currentGold < champion.cost)
            return false;

        //instantiate champion prefab
        GameObject championPrefab = Instantiate(champion.prefab);

        //get championController
        ChampionController championController = championPrefab.GetComponent<ChampionController>();

        //setup chapioncontroller
        championController.Init(champion, ChampionController.TEAMID_PLAYER);


        //set grid position
        championController.SetGridPosition(Map.GRIDTYPE_OWN_INVENTORY, emptyIndex, -1);

        //set position and rotation
        championController.SetWorldPosition();
        championController.SetWorldRotation();


        //store champion in inventory array
        StoreChampionInArray(Map.GRIDTYPE_OWN_INVENTORY, map.ownTriggerArray[emptyIndex].gridX, -1, championPrefab);




        //only upgrade when in preparation stage
        if (currentGameStage == GameStage.Preparation)
            TryUpgradeChampion(champion); //upgrade champion


        //deduct gold
        currentGold -= champion.cost;

        //set gold on ui
        uIController.UpdateUI();

        //return true if succesful buy
        return true;
    }

   

    public void Summon(Champion champion)
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
                //there is a champion
                if (gridChampionsArray[x, z] == null)
                {
                    GameObject championPrefab = Instantiate(champion.prefab);




                    //get championController
                    ChampionController championController = championPrefab.GetComponent<ChampionController>();

                    //gridChampionsArray[x, z] = championController2.gameObject;
                    //setup chapioncontroller
                    championController.Init(champion, ChampionController.TEAMID_PLAYER);
                    if (summonSynergy)
                    {
                        championController.currentDamage *= (summonSynergyValue);
                        championController.maxHealth *= (summonSynergyValue);
                        championController.currentHealth *= (summonSynergyValue);
                        championController.currentDefence *= (summonSynergyValue);
                    }

                    //set grid position
                    championController.SetGridPosition(Map.GRIDTYPE_HEXA_MAP, x, z);

                    //set position and rotation
                    championController.SetWorldPosition();
                    championController.SetWorldRotation();
                    StoreChampionInArray(Map.GRIDTYPE_HEXA_MAP, x, z, championPrefab);

                    championController.OnCombatStart();
                    flag = 1;
                    //  ChampionController championController2 = gridChampionsArray[x, z].GetComponent<ChampionController>();
                    summonlist.Add(championController);
                    if (flag == 1)
                    {
                        break;
                    }
                }
            }
         
        }
    }

    public void RemoveSummon()
    {
        for (int i = 0; i < summonlist.Count; i++)
        {
            RemoveChampionFromArray(Map.GRIDTYPE_HEXA_MAP, summonlist[i].gridPositionX, summonlist[i].gridPositionZ);
            if (summonlist != null)
                Destroy(summonlist[i].gameObject);
        }

    }

    public bool Compose(Champion champion)
    {
        //get first empty inventory slot
        int emptyIndex = -1;
        for (int i = 0; i < ownChampionInventoryArray.Length; i++)
        {
            if (ownChampionInventoryArray[i] == null)
            {
                emptyIndex = i;
                break;
            }
        }

        //return if no slot to add champion
        if (emptyIndex == -1)
            return false;

        //instantiate champion prefab
        GameObject championPrefab = Instantiate(champion.prefab);

        //get championController
        ChampionController championController = championPrefab.GetComponent<ChampionController>();

        //setup chapioncontroller
        championController.Init(champion, ChampionController.TEAMID_PLAYER);

        //set grid position

        championController.SetGridPosition(Map.GRIDTYPE_OWN_INVENTORY, emptyIndex, -1);

        //set position and rotation
        championController.SetWorldPosition();
        championController.SetWorldRotation();


        //store champion in inventory array
        //StoreChampionInArray(Map.GRIDTYPE_HEXA_MAP,gridX, gridZ, championPrefab);
        StoreChampionInArray(Map.GRIDTYPE_OWN_INVENTORY, map.ownTriggerArray[emptyIndex].gridX, -1, championPrefab);


        //set gold on ui
        uIController.UpdateUI();


        //return true if succesful buy
        return true;
    }

    /// <summary>
    /// Check all champions if a upgrade is possible
    /// </summary>
    /// <param name="champion"></param>
    private void TryUpgradeChampion(Champion champion)
    {
        int flag = 0;
        //check for champion upgrade
        List<ChampionController> championList_lvl_1 = new List<ChampionController>();

        if (champion.grade < 2)
        {
            for (int i = 0; i < ownChampionInventoryArray.Length; i++)
            {
                //there is a champion
                if (ownChampionInventoryArray[i] != null)
                {
                    //get character
                    ChampionController championController = ownChampionInventoryArray[i].GetComponent<ChampionController>();

                    //check if is the same type of champion that we are buying
                    if (championController.champion == champion)
                    {
                        championList_lvl_1.Add(championController);
                    }
                }
            }

            for (int x = 0; x < Map.hexMapSizeX; x++)
            {
                for (int z = 0; z < Map.hexMapSizeZ / 2; z++)
                {
                    //there is a champion
                    if (gridChampionsArray[x, z] != null)
                    {
                        //get character
                        ChampionController championController = gridChampionsArray[x, z].GetComponent<ChampionController>();

                        //check if is the same type of champion that we are buying
                        if (championController.champion == champion)
                        {
                            championList_lvl_1.Add(championController);
                        }
                    }

                }
            }
        }


        //if we have 3 we upgrade a champion and delete rest
        if (championList_lvl_1.Count > 2)
        {
            flag = 1;
            championList_lvl_1[0].UpgradeLevel();

            gridT = championList_lvl_1[0].gridType;
            gridX = championList_lvl_1[0].gridPositionX;
            gridZ = championList_lvl_1[0].gridPositionZ;

            RemoveChampionFromArray(championList_lvl_1[0].gridType, championList_lvl_1[0].gridPositionX, championList_lvl_1[0].gridPositionZ);
            RemoveChampionFromArray(championList_lvl_1[1].gridType, championList_lvl_1[1].gridPositionX, championList_lvl_1[1].gridPositionZ);
            RemoveChampionFromArray(championList_lvl_1[2].gridType, championList_lvl_1[2].gridPositionX, championList_lvl_1[2].gridPositionZ);

            //destroy gameobjects
            Destroy(championList_lvl_1[0].gameObject);
            Destroy(championList_lvl_1[1].gameObject);
            Destroy(championList_lvl_1[2].gameObject);

            for (int i = 0; i < gameData.championsArray.Length; i++)
            {
                if (champion == gameData.championsArray[i])
                {
                    champion = gameData.championsArray[i + 1];

                    Compose(champion);
                    break;
                }
            }
            if (flag == 1)
            {
                flag = 0;
                TryUpgradeChampion(champion);
            }
        }

        currentChampionCount = GetChampionCountOnHexGrid();

        //update ui
        uIController.UpdateUI();

    }

    public GameObject draggedChampion = null;
    private TriggerInfo dragStartTrigger = null;

    /// <summary>
    /// When we start dragging champions on map
    /// </summary>
    public void StartDrag()
    {
        if (currentGameStage != GameStage.Preparation)
            return;

        //get trigger info
        TriggerInfo triggerinfo = inputController.triggerInfo;
        //if mouse cursor on trigger
        if (triggerinfo != null)
        {
            dragStartTrigger = triggerinfo;

            GameObject championGO = GetChampionFromTriggerInfo(triggerinfo);

            if (championGO != null)
            {
                //show indicators
                map.ShowIndicators();

                draggedChampion = championGO;

                //isDragging = true;

                championGO.GetComponent<ChampionController>().IsDragged = true;
                //Debug.Log("STARTDRAG");
            }

        }
    }

    /// <summary>
    /// When we stop dragging champions on map
    /// </summary>
    public void StopDrag()
    {
        //hide indicators
        map.HideIndicators();

        int championsOnField = GetChampionCountOnHexGrid();


        if (draggedChampion != null)
        {
            //set dragged
            draggedChampion.GetComponent<ChampionController>().IsDragged = false;

            //get trigger info
            TriggerInfo triggerinfo = inputController.triggerInfo;

            //if mouse cursor on trigger
            if (triggerinfo != null)
            {
                //get current champion over mouse cursor
                GameObject currentTriggerChampion = GetChampionFromTriggerInfo(triggerinfo);

                //there is another champion in the way
                if (currentTriggerChampion != null)
                {
                    //store this champion to start position
                    StoreChampionInArray(dragStartTrigger.gridType, dragStartTrigger.gridX, dragStartTrigger.gridZ, currentTriggerChampion);

                    //store this champion to dragged position
                    StoreChampionInArray(triggerinfo.gridType, triggerinfo.gridX, triggerinfo.gridZ, draggedChampion);
                }
                else
                {
                    //we are adding to combat field
                    if (triggerinfo.gridType == Map.GRIDTYPE_HEXA_MAP)
                    {
                        //only add if there is a free spot or we adding from combatfield
                        if (championsOnField < currentChampionLimit || dragStartTrigger.gridType == Map.GRIDTYPE_HEXA_MAP)
                        {
                            //remove champion from dragged position
                            RemoveChampionFromArray(dragStartTrigger.gridType, dragStartTrigger.gridX, dragStartTrigger.gridZ);

                            //add champion to dragged position
                            StoreChampionInArray(triggerinfo.gridType, triggerinfo.gridX, triggerinfo.gridZ, draggedChampion);

                            if (dragStartTrigger.gridType != Map.GRIDTYPE_HEXA_MAP)
                            {
                                championsOnField++;
                                draggedChampion.GetComponent<ChampionController>().synergyIsApply = true;
                            }

                        }
                    }
                    else if (triggerinfo.gridType == Map.GRIDTYPE_OWN_INVENTORY)
                    {
                        //remove champion from dragged position
                        RemoveChampionFromArray(dragStartTrigger.gridType, dragStartTrigger.gridX, dragStartTrigger.gridZ);

                        //add champion to dragged position
                        StoreChampionInArray(triggerinfo.gridType, triggerinfo.gridX, triggerinfo.gridZ, draggedChampion);

                        if (dragStartTrigger.gridType == Map.GRIDTYPE_HEXA_MAP)
                        {
                            championsOnField--;
                            draggedChampion.GetComponent<ChampionController>().synergyIsApply = true;
                        }

                    }



                }




            }


            CalculateBonuses();

            currentChampionCount = GetChampionCountOnHexGrid();

            //update ui
            uIController.UpdateUI();


            draggedChampion = null;
        }


    }
    public bool enableSell = false;
    public void SellEnable()
    {
        enableSell = true;
    }
    public void SellDisable()
    {
        enableSell = false;
    }


    /// <summary>
    /// Get champion gameobject from triggerinfo
    /// </summary>
    /// <param name="triggerinfo"></param>
    /// <returns></returns>
    private GameObject GetChampionFromTriggerInfo(TriggerInfo triggerinfo)
    {
        GameObject championGO = null;

        if (triggerinfo.gridType == Map.GRIDTYPE_OWN_INVENTORY)
        {
            championGO = ownChampionInventoryArray[triggerinfo.gridX];
        }
        else if (triggerinfo.gridType == Map.GRIDTYPE_OPONENT_INVENTORY)
        {
            championGO = oponentChampionInventoryArray[triggerinfo.gridX];
        }
        else if (triggerinfo.gridType == Map.GRIDTYPE_HEXA_MAP)
        {
            championGO = gridChampionsArray[triggerinfo.gridX, triggerinfo.gridZ];
        }

        return championGO;
    }

    /// <summary>
    /// Store champion gameobject in array
    /// </summary>
    /// <param name="triggerinfo"></param>
    /// <param name="champion"></param>
    private void StoreChampionInArray(int gridType, int gridX, int gridZ, GameObject champion)
    {
        //assign current trigger to champion
        ChampionController championController = champion.GetComponent<ChampionController>();
        championController.SetGridPosition(gridType, gridX, gridZ);

        if (gridType == Map.GRIDTYPE_OWN_INVENTORY)
        {
            ownChampionInventoryArray[gridX] = champion;
        }
        else if (gridType == Map.GRIDTYPE_HEXA_MAP)
        {
            gridChampionsArray[gridX, gridZ] = champion;
        }
    }

    /// <summary>
    /// Remove champion from array
    /// </summary>
    /// <param name="triggerinfo"></param>
    private void RemoveChampionFromArray(int type, int gridX, int gridZ)
    {
        if (type == Map.GRIDTYPE_OWN_INVENTORY)
        {
            ownChampionInventoryArray[gridX] = null;
        }
        else if (type == Map.GRIDTYPE_HEXA_MAP)
        {
            gridChampionsArray[gridX, gridZ] = null;
        }
    }

    /// <summary>
    /// Returns the number of champions we have on the map
    /// </summary>
    /// <returns></returns>
    private int GetChampionCountOnHexGrid()
    {
        int count = 0;
        for (int x = 0; x < Map.hexMapSizeX; x++)
        {
            for (int z = 0; z < Map.hexMapSizeZ / 2; z++)
            {
                //there is a champion
                if (gridChampionsArray[x, z] != null)
                {
                    count++;
                    
                }
            }
        }

        return count;
    }

    /// <summary>
    /// Calculates the bonuses we have currently
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

        activeBonus = new Dictionary<ChampionBonus, int>();
        activeBonusNumList = new List<int>();

        foreach (KeyValuePair<ChampionType, int> m in championTypeCount)
        {
            ChampionBonus championBonus = m.Key.championBonus;
            int bonusNum = m.Value;

            //have enough champions to get bonus
            if (bonusNum >= championBonus.championCount1)
            {
                activeBonus.Add(championBonus, bonusNum);
                activeBonusNumList.Add(bonusNum);
            }
        }

    }

    /// <summary>
    /// Resets all champion stats and positions
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

                    //reset
                    championController.Reset();
                }

            }
        }
    }

    /// <summary>
    /// Called when a game stage is finished
    /// </summary>
    public void OnGameStageComplate()
    {
        //tell ai that stage complated
        aIopponent.OnGameStageComplate(currentGameStage);

        if (currentGameStage == GameStage.Preparation)
        {
            //set new game stage
            currentGameStage = GameStage.Combat;


            if (isSnow)
            {
                for (int x = 0; x < Map.hexMapSizeX; x++)
                {
                    for (int z = 0; z < Map.hexMapSizeZ / 2; z++)
                    {
                        if (gridChampionsArray[x, z] != null)
                        {
                            ChampionController championController = gridChampionsArray[x, z].GetComponent<ChampionController>();
                            championController.currentDamage = championController.currentDamage * 0.9f;
                        }
                    }
                }
            }

            if (isRain)
            {
                for (int x = 0; x < Map.hexMapSizeX; x++)
                {
                    for (int z = 0; z < Map.hexMapSizeZ / 2; z++)
                    {
                        if (gridChampionsArray[x, z] != null)
                        {
                            ChampionController championController = gridChampionsArray[x, z].GetComponent<ChampionController>();
                            championController.currentHealth = championController.currentHealth * 0.9f;
                        }
                    }
                }
            }






            //show indicators
            map.HideIndicators();

            uIController.ready.gameObject.SetActive(false);

            //hide timer text
            uIController.SetTimerTextActive(true);


            if (draggedChampion != null)
            {
                //stop dragging    
                draggedChampion.GetComponent<ChampionController>().IsDragged = false;
                draggedChampion = null;
            }


            for (int i = 0; i < ownChampionInventoryArray.Length; i++)
            {
                //there is a champion
                if (ownChampionInventoryArray[i] != null)
                {
                    //get character
                    ChampionController championController = ownChampionInventoryArray[i].GetComponent<ChampionController>();

                    //start combat
                    championController.OnCombatStart();
                }
            }

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
                        championArray.Add(championController);
                        //start combat
                        championController.OnCombatStart();
                    }

                }
            }


            //check if we start with 0 champions
            if (IsAllChampionDead())
            {

                EndRound();
            }


        }
        else if (currentGameStage == GameStage.Combat)
        {

            //소환수 제거
            RemoveSummon();
            //set new game stage
            currentGameStage = GameStage.Preparation;
            championArray.Clear();

            uIController.ready.gameObject.SetActive(true);

            //show timer text
            uIController.SetTimerTextActive(false);

            //reset champion
            ResetChampions();

            //go through all champion infos
            for (int i = 0; i < gameData.championsArray.Length; i++)
            {
                TryUpgradeChampion(gameData.championsArray[i]);
            }


            //add gold
            currentGold += CalculateIncome();
            if (wealth)
            {
                currentGold += (int)wealthMoney;
            }

            currentExp += 2;
            CheckExp();

            //set gold ui
            uIController.UpdateUI();

            //refresh shop ui
            if (uIController.isLock == false)
            {
                championShop.RefreshShop(true);
            }

            //check if we have lost
            if (currentHP <= 0)
            {
                currentGameStage = GameStage.Loss;
                resultText.text = "패배";
                uIController.ResultScreen();

            }

            int wn = Random.Range(0, 101);
            if (wn < 90)
            {
                weathercheck++;
                wn = Random.Range(0, 101);
                if (wn < 50)
                {

                    Rain.SetActive(false);
                    Snow.SetActive(true);
                    isRain = false;
                    isSnow = true;
                }
                else
                {
                    Snow.SetActive(false);
                    Rain.SetActive(true);
                    isSnow = false;
                    isRain = true;
                }
            }

        }
    }

    /// <summary>
    /// Returns the number of gold we should recieve
    /// </summary>
    /// <returns></returns>
    private int CalculateIncome()
    {
        int income = 0;

        //banked gold
        int bank = (int)(currentGold / 10);


        income += baseGoldIncome;
        income += bank;
        income += winBonus;
        if (continuedWin > 4) income += 2;
        else if (continuedWin > 1) income++;
        else if (continuedLose > 4) income += 4;
        else if (continuedLose > 2) income += 3;
        else if (continuedLose > 1) income += 2;


        return income;
    }


    public void CheckExp()
    {
        if (currentChampionLimit == 1)
        {
            needExp = 2;
        }
        else if (currentChampionLimit == 2)
        {
            needExp = 4;
        }
        else if (currentChampionLimit == 3)
        {
            needExp = 6;
        }
        else if (currentChampionLimit == 4)
        {
            needExp = 10;
        }
        else if (currentChampionLimit == 5)
        {
            needExp = 20;
        }
        else if (currentChampionLimit == 6)
        {
            needExp = 36;
        }
        else if (currentChampionLimit == 7)
        {
            needExp = 56;
        }
        else if (currentChampionLimit == 8)
        {
            needExp = 80;
        }
        else
        {
            needExp = 100;
        }

        if (currentExp >= needExp)
        {
            currentExp -= needExp;
            currentChampionLimit++;
        }

    }

    /// <summary>
    /// Incrases the available champion slots by 1
    /// </summary>
    public void Buylvl()
    {
        //return if we dont have enough gold
        if (currentGold < 4)
            return;

        if (currentChampionLimit < 9)
        {

            currentExp += 40;
            CheckExp();
            CheckExp();
            //decrase gold
            currentGold -= 4;

            //update ui
            uIController.UpdateUI();

        }

    }

    /// <summary>
    /// Called when round was lost
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        uIController.UpdateUI();

    }

    /// <summary>
    /// Called when Game was lost
    /// </summary>
    public void RestartGame()
    {



        //remove champions
        for (int i = 0; i < ownChampionInventoryArray.Length; i++)
        {
            //there is a champion
            if (ownChampionInventoryArray[i] != null)
            {
                //get character
                ChampionController championController = ownChampionInventoryArray[i].GetComponent<ChampionController>();

                Destroy(championController.gameObject);
                ownChampionInventoryArray[i] = null;
            }

        }

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

        //reset stats
        currentHP = 100;
        currentGold = 5;
        currentGameStage = GameStage.Preparation;
        currentChampionLimit = 3;
        currentChampionCount = GetChampionCountOnHexGrid();

        uIController.UpdateUI();

        //restart ai
        aIopponent.Restart();

        //show hide ui
        uIController.ShowGameScreen();


    }


    /// <summary>
    /// Ends the round
    /// </summary>
    public void EndRound()
    {
        timer = CombatStageDuration - 3; //reduce timer so game ends fast
    }


    /// <summary>
    /// Called when a champion killd
    /// </summary>
    public void OnChampionDeath()
    {
        bool allDead = IsAllChampionDead();

        if (allDead)
        {
            winBonus = 0;
            continuedLose++;
            continuedWin = 0;
            EndRound();
        }
    }


    /// <summary>
    /// Returns true if all the champions are dead
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

    public void SellChampion()
    {

        if (draggedChampion != null)
        {
            currentGold += draggedChampion.GetComponent<Champion>().cost;
        }
    }

    public void Sin7Shield(float shield)
    {
        for (int x = 0; x < Map.hexMapSizeX; x++)
        {
            for (int z = 0; z < Map.hexMapSizeZ / 2; z++)
            {
                //there is a champion
                if (gridChampionsArray[x, z] != null)
                {
                    ChampionController championController = gridChampionsArray[x, z].GetComponent<ChampionController>();
                    if (championController.champType2.displayName == "7대죄악")
                    {
                        championController.currentShield += shield;
                    }
                }

            }
        }
    }
    public void Loyality(float atk)
    {
        for (int x = 0; x < Map.hexMapSizeX; x++)
        {
            for (int z = 0; z < Map.hexMapSizeZ / 2; z++)
            {
                //there is a champion
                if (gridChampionsArray[x, z] != null)
                {
                    ChampionController championController = gridChampionsArray[x, z].GetComponent<ChampionController>();
                    if (championController.champType2.displayName == "충성의상징")
                    {
                        championController.currentDamage *= 1 + (atk / 100);
                        championController.timeLoyal = -championController.loyalityValue1;
                    }
                }
            }
        }
    }

    public void Death(float atk)
    {
        for (int x = 0; x < Map.hexMapSizeX; x++)
        {
            for (int z = 0; z < Map.hexMapSizeZ / 2; z++)
            {
                //there is a champion
                if (gridChampionsArray[x, z] != null)
                {
                    ChampionController championController = gridChampionsArray[x, z].GetComponent<ChampionController>();
                    championController.currentDamage *= 1 + (atk / 100);
                    championController.timeDeath = -championController.deathValue1;

                }
            }
        }
    }

    public void Ability(float bonus)
    {
        for (int x = 0; x < Map.hexMapSizeX; x++)
        {
            for (int z = 0; z < Map.hexMapSizeZ / 2; z++)
            {
                //there is a champion
                if (gridChampionsArray[x, z] != null)
                {
                    ChampionController championController = gridChampionsArray[x, z].GetComponent<ChampionController>();
                    championController.currentMana += bonus;
                }
            }
        }
    }

}