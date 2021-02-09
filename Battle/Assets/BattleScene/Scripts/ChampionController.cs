using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

/// <summary>
/// Controls a single champion movement and combat
/// </summary>
public class ChampionController : MonoBehaviour
{
    public Animator championAnimator;


    public static int TEAMID_PLAYER = 0;
    public static int TEAMID_AI = 1;


    public GameObject levelupEffectPrefab;
    public GameObject projectileStart;

    public UIController uIController;


    public GameObject AttackEffectPrefab;
    public GameObject SkillEffectPrefab;
    public GameObject SkillEffectPrefab2;


    [HideInInspector]
    public int gridType = 0;
    [HideInInspector]
    public int gridPositionX = 0;
    [HideInInspector]
    public int gridPositionZ = 0;

    [HideInInspector]
    ///Team of this champion, can be player = 0, or enemy = 1
    public int teamID = 0;


    [HideInInspector]
    public Champion champion;

    [HideInInspector]
    ///Maximum health of the champion
    public float maxHealth = 0;

    [HideInInspector]
    ///current health of the champion 
    public float currentHealth = 0;
    public float currentHealthReg = 0;

    [HideInInspector]
    ///current health of the champion 
    public float currentShield = 0;

    [HideInInspector]
    public float maxMana = 0;
    public int sellCost;

    [HideInInspector]
    public float currentMana = 0;
    public float currentHitMana = 5;
    public float currentAttackMana = 10;

    [HideInInspector]
    ///Current damage of the champion deals with a attack
    public float currentDamage = 0;
    public float currentCritical = 0;
    public float currentEvasion = 0;
    public float currentAttackSpeed = 1;

    [HideInInspector]
    public float currentDefence = 0;

    public float currentMoveSpeed = 3.5f;

    [HideInInspector]
    ///The upgrade level of the champion
    public int lvl;

    public int skillID;

    private Map map;
    public GamePlayController gamePlayController;
    private AIopponent aIopponent;
    private ChampionAnimation championAnimation;
    public WorldCanvasController worldCanvasController;

    public Skill skillScript;

    private NavMeshAgent navMeshAgent;

    private Vector3 gridTargetPosition;

    private bool _isDragged = false;

    [HideInInspector]
    public bool isAttacking = false;

    [HideInInspector]
    public bool isDead = false;

    private bool isInCombat = false;
    private float combatTimer = 0;

    public bool isStuned = false;
    public float stunTimer = 0;
    
    private bool isEnemy48passive = true;

    private bool isEnemy61skillChanneling = false;
    private float enemy61skillChannelingTimer = 0;
    private int enemy61skillCount = 0;


    public bool isBoarskill = false;

    public bool isCrocodileStack = false;
    public float crocodileStack = 0;
    private float crocodilesec = 0;
    private float crocodileTimer = 0;
    private float crocodileBleedingDamage = 0;

    public bool isRatDead = false;
    public bool isRatSkillOn = false;
    private bool isRatSkill = false;
    private float RatSkillTimer = 0;

    public bool isSalamanderDead = false;
    public bool isSalamanderSkillOn = false;
    private bool isSalamanderSkill = false;
    private float SalamanderSkillTimer = 0;
    private int salamanderskillCount = 0;
    private float salamanderPoisonDamage = 0;
    private float salamandersec = 0;

    private bool isComodoStack = false;
    private float comodoStack = 0;
    private float comodoStackLevel = 0;
    private float comodoPoisonDamage = 0;
    private float comodoStackTimer = 0;
    private float comodosec = 0;

    private bool isScorpionSkill = false;
    private float ScorpionSkillTimer = 0;
    private float scorpionPoisonDamage = 0;
    private float scorpionsec = 0;

    public bool isSilence = false;
    public float silenceTimer = 0;

    private bool isOctopusSkill = false;
    private float OctopusSkillTimer = 0;

    private bool isGoatskillChanneling = false;
    private float goatskillChannelingTimer = 0;
    private int goatskillCount = 0;



    public bool sin7 = false;
    public float sin7Shield = 0;

    public bool admirer = false;
    public float admirerValue = 0;

    public bool loyality = false;
    public float loyalityValue1 = 0;
    public float loyalityValue2 = 0;

    public bool death = false;
    public float deathValue1 = 0;
    public float deathValue2 = 0;

    public bool strength = false;
    public float strengthValue1 = 0;
    public float strengthValue2 = 0;

    public bool ability = false;
    public float abilityValue1 = 0;

    public float snailStack = 0;



    public ChampionType champType1;
    public ChampionType champType2;

    private List<Effect> effects;


    float atkSpeedAnimator;


    /// Start is called before the first frame update
    void Awake()
    {
        uIController = GameObject.Find("Scripts").GetComponent<UIController>();
        championAnimator = this.gameObject.GetComponent<Animator>();
        skillScript = GameObject.Find("Scripts").GetComponent<Skill>();
        atkSpeedAnimator = championAnimator.GetFloat("attackSpeed");
    }

    /// <summary>
    /// When champion created Champion and teamID passed
    /// </summary>
    /// <param name="_champion"></param>
    /// <param name="_teamID"></param>
    public void Init(Champion _champion, int _teamID)
    {
        champion = _champion;
        teamID = _teamID;

        //store scripts
        map = GameObject.Find("Scripts").GetComponent<Map>();
        aIopponent = GameObject.Find("Scripts").GetComponent<AIopponent>();
        gamePlayController = GameObject.Find("Scripts").GetComponent<GamePlayController>();
        worldCanvasController = GameObject.Find("Scripts").GetComponent<WorldCanvasController>();
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        championAnimation = this.GetComponent<ChampionAnimation>();
        championAnimator = GetComponent<Animator>();

        //disable agent
        navMeshAgent.enabled = false;

        lvl = champion.level;
        skillID = champion.skillID;

        champType1 = champion.type1;
        champType2 = champion.type2;
        //set stats
        if (PlayerPrefs.GetInt("usedRune") == 2 && teamID == TEAMID_PLAYER)
        {
            maxHealth = champion.health * 1.1f;
            currentHealth = champion.health * 1.1f;
        }
        else
        {
            maxHealth = champion.health;
            currentHealth = champion.health;
        }
        currentHealthReg = champion.healthRegeneration;
        currentShield = champion.shield;

        maxMana = champion.mana;
        currentMana = 20;
        currentHitMana = champion.hitMana;
        currentAttackMana = champion.attackMana;

        if(PlayerPrefs.GetInt("usedRune") == 1 && teamID == TEAMID_PLAYER)
        {
            currentDamage = champion.damage *1.05f;
        }
        else
        {
            currentDamage = champion.damage;
        }
        currentCritical = champion.critical;
        currentEvasion = champion.evasion;
        currentAttackSpeed = champion.attackSpeed;

        currentDefence = champion.defence;

        currentMoveSpeed = champion.movementSpeed;

        sellCost = champion.sellCost;

        worldCanvasController.AddHealthBar(this.gameObject);
        worldCanvasController.AddManaBar(this.gameObject);


        effects = new List<Effect>();
    }
    public bool synergyIsApply = true;
    public bool wealthOn = false;
    public float wealthValue = 0;

    public float timeLoyal = 1;
    public float timeDeath = 1;
    public float timeStrength = 1;
    /// Update is called once per frame
    void Update()
    {
        championAnimator.SetFloat("attackSpeed", (atkSpeedAnimator * currentAttackSpeed) + 0.3f);
        gameObject.GetComponent<NavMeshAgent>().speed = currentMoveSpeed;


        if (GameObject.FindGameObjectWithTag("propeller") != null)
        {
            for (int i = 0; i < GameObject.FindGameObjectsWithTag("propeller").Length; i++)
            {
                GameObject.FindGameObjectsWithTag("propeller")[i].transform.rotation *= Quaternion.Euler(new Vector3(0, 30, 0));
            }
        }


        if (wealthOn == true)
            gamePlayController.wealth = true;
        else gamePlayController.wealth = false;

        gamePlayController.wealthMoney = wealthValue;


        timeLoyal += Time.deltaTime;
        if (timeLoyal > 0 && timeLoyal < 1)
        {
            timeLoyal = 1;
            if (champType2.displayName == "충성의상징")
            {
                currentDamage /= 1 + (loyalityValue2 / 100);
            }
        }

        if (timeDeath > 0 && timeDeath < 1)
        {
            timeDeath = 1;
            currentDamage /= 1 + (deathValue2 / 100);
        }

        if (timeStrength > 0 && timeStrength < 1)
        {
            timeStrength = 1;
            currentAttackSpeed /= 1 + (strengthValue2 / 100);
        }

        if (synergyIsApply && gamePlayController.currentGameStage == GameStage.Combat)
        {
            ApplyActiveSynergy();
            synergyIsApply = false;
        }

        if (_isDragged)
        {
            //Create a ray from the Mouse click position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //hit distance
            float enter = 100.0f;
            if (map.m_Plane.Raycast(ray, out enter))
            {
                //Get the point that is clicked
                Vector3 hitPoint = ray.GetPoint(enter);

                //new character position
                Vector3 p = new Vector3(hitPoint.x, 1.0f, hitPoint.z);

                //move champion
                this.transform.position = Vector3.Lerp(this.transform.position, p, 10.1f);
            }
        }
        else
        {
            if (gamePlayController.currentGameStage == GameStage.Preparation)
            {
                //calc distance
                float distance = Vector3.Distance(gridTargetPosition, this.transform.position);

                if (distance > 0.25f)
                {
                    this.transform.position = Vector3.Lerp(this.transform.position, gridTargetPosition, 0.1f);
                }
                else
                {
                    this.transform.position = gridTargetPosition;
                }
            }
        }



        if (isInCombat && isStuned == false)
        {
            if (target == null)
            {
                combatTimer += Time.deltaTime;
                if (combatTimer > 0.5f)
                {
                    combatTimer = 0;

                    TryAttackNewTarget();
                }
            }


            //combat 
            if (target != null)
            {
                //rotate towards target
                this.transform.LookAt(target.transform, Vector3.up);

                if (target.GetComponent<ChampionController>().isDead == true) //target champion is alive
                {
                    //remove target if targetchampion is dead 
                    target = null;
                    navMeshAgent.isStopped = true;
                }
                else
                {
                    if (isAttacking == false)
                    {
                        //calculate distance
                        float distance = Vector3.Distance(this.transform.position, target.transform.position);

                        //if we are close enough to attack 
                        if (distance < champion.attackRange)
                        {
                            DoAttack();
                        }
                        else
                        {
                            navMeshAgent.SetDestination(target.transform.position);
                        }
                    }
                }
            }
        }





        //check for stuned effect
        if (isStuned)
        {
            stunTimer -= Time.deltaTime;
            if (stunTimer < 0)
            {
                isStuned = false;
                if (target != null)
                {
                    //set pathfinder target
                    navMeshAgent.destination = target.transform.position;
                    navMeshAgent.isStopped = false;
                }
            }
        }
        if (skillID == 48)
        {
            if (isEnemy48passive)
            {
                currentDamage = currentDamage * 2.0f;
                currentDefence = currentDefence * 2.0f;
                if(currentShield <= 0)
                {
                    isEnemy48passive = false;
                }
            }
        }

        if (isBoarskill)
        {
            currentMana = maxMana;
            isBoarskill = false;
        }

        if (isCrocodileStack)
        {
            crocodileTimer += Time.deltaTime;
            if (crocodileTimer > crocodilesec)
            {
                float bleedingDamage = crocodileBleedingDamage * crocodileStack;
                currentHealth -= bleedingDamage;
                worldCanvasController.AddDamageText(gameObject.GetComponent<Transform>().position + new Vector3(0, 2.5f, 0), bleedingDamage, Color.red);
                crocodilesec++;
            }
        }


        if (isComodoStack)
        {
            comodoStackTimer += Time.deltaTime;
            if (this.comodoStackLevel == 1)
            {
                comodoPoisonDamage = this.maxHealth * 0.02f * comodoStack;
            }
            else if (this.comodoStackLevel == 2)
            {
                comodoPoisonDamage = this.maxHealth * 0.04f * comodoStack;
            }
            else if (this.comodoStackLevel == 3)
            {
                comodoPoisonDamage = this.maxHealth * 0.08f * comodoStack;
            }
            if (2 > comodosec)
            {
                if (comodoStackTimer > comodosec)
                {
                    currentHealth -= comodoPoisonDamage;
                    worldCanvasController.AddDamageText(gameObject.GetComponent<Transform>().position + new Vector3(0, 2.5f, 0), comodoPoisonDamage, Color.red);
                    comodosec++;
                }
            }
            else
            {
                isComodoStack = false;
                comodosec = 0;
                comodoStackTimer = 0;
            }

        }

        if (isRatSkill)
        {
            RatSkillTimer -= Time.deltaTime;
            if (RatSkillTimer < 0)
            {
                /*
                if(보스유닛이라면)
                최대 체력의 50% 피해
                */
                Debug.Log("체력 1 됨");
                currentHealth = 1;
                isRatSkill = false;
            }
        }

        if (isSalamanderSkill)
        {
            SalamanderSkillTimer += Time.deltaTime;

            if (salamanderskillCount > salamandersec)
            {
                if (SalamanderSkillTimer > salamandersec)
                {
                    currentHealth -= salamanderPoisonDamage;
                    worldCanvasController.AddDamageText(gameObject.GetComponent<Transform>().position + new Vector3(0, 2.5f, 0), salamanderPoisonDamage, Color.red);
                    salamandersec++;
                }
            }
            else
            {
                isSalamanderSkill = false;
                salamandersec = 0;
                SalamanderSkillTimer = 0;
            }

        }

        if (isScorpionSkill)
        {
            ScorpionSkillTimer += Time.deltaTime;

            if (3 >= scorpionsec)
            {
                if (ScorpionSkillTimer > scorpionsec)
                {
                    currentHealth -= scorpionPoisonDamage;
                    worldCanvasController.AddDamageText(gameObject.GetComponent<Transform>().position + new Vector3(0, 2.5f, 0), scorpionPoisonDamage, Color.red);
                    scorpionsec++;
                }
            }
            else
            {
                isScorpionSkill = false;
                scorpionsec = 1;
                ScorpionSkillTimer = 0;
            }
        }


        if (isSilence)
        {
            silenceTimer -= Time.deltaTime;
            if (silenceTimer < 0)
            {
                isSilence = false;
            }
        }


        if (isOctopusSkill)
        {
            OctopusSkillTimer -= Time.deltaTime;
            if (OctopusSkillTimer < 0)
            {
                currentDamage = champion.damage;
                isOctopusSkill = false;
            }
        }



        if (isGoatskillChanneling)
        {
            goatskillChannelingTimer -= Time.deltaTime;
            Debug.Log(goatskillCount + "= 스킬시전 횟수");
            if (goatskillChannelingTimer < 4.9 && goatskillCount == 0)
            {
                goatskillCount++;
                GoatSkill();
            }
            else if (goatskillChannelingTimer < 3.9 && goatskillCount == 1)
            {
                goatskillCount++;
                GoatSkill();
            }
            else if (goatskillChannelingTimer < 2.9 && goatskillCount == 2)
            {
                goatskillCount++;
                GoatSkill();
            }
            else if (goatskillChannelingTimer < 1.9 && goatskillCount == 3)
            {
                goatskillCount++;
                GoatSkill();
            }
            else if (goatskillChannelingTimer < 0.9 && goatskillCount == 4)
            {
                goatskillCount++;
                GoatSkill();
            }

            if (goatskillCount == 5)
            {
                Debug.Log("염소스킬끝");
                isGoatskillChanneling = false;
                DoAttack();
            }
        }

        if (isEnemy61skillChanneling)
        {
            enemy61skillChannelingTimer -= Time.deltaTime;
            Debug.Log(enemy61skillCount + "= 스킬시전 횟수");
            if (enemy61skillChannelingTimer < 5.9 && enemy61skillCount == 0)
            {
                enemy61skillCount++;
                Enemy61Skill();
            }
            else if (enemy61skillChannelingTimer < 4.9 && enemy61skillCount == 1)
            {
                enemy61skillCount++;
                Enemy61Skill();
            }
            else if (enemy61skillChannelingTimer < 3.9 && enemy61skillCount == 2)
            {
                enemy61skillCount++;
                Enemy61Skill();
            }
            else if (enemy61skillChannelingTimer < 2.9 && enemy61skillCount == 3)
            {
                enemy61skillCount++;
                Enemy61Skill();
            }
            else if (enemy61skillChannelingTimer < 1.9 && enemy61skillCount == 4)
            {
                enemy61skillCount++;
                Enemy61Skill();
            }
            else if (enemy61skillChannelingTimer < 0.9 && enemy61skillCount == 5)
            {
                enemy61skillCount++;
                Enemy61Skill();
            }

            if (enemy61skillCount == 6)
            {
                Debug.Log("61스킬끝");
                isEnemy61skillChanneling = false;
                DoAttack();
            }
        }


    }

    /// <summary>
    /// Set dragged when moving champion with mouse
    /// </summary>
    public bool IsDragged
    {
        get { return _isDragged; }
        set { _isDragged = value; }
    }

    /// <summary>
    /// Resets champion after combat is over
    /// </summary>
    public void Reset()
    {
        //set active
        this.gameObject.SetActive(true);

        //reset stats
        maxHealth = champion.health * lvl;
        currentHealth = champion.health * lvl;
        currentShield = champion.shield;
        currentMana = champion.mana;
        isDead = false;
        isInCombat = false;
        target = null;
        isAttacking = false;
        

        skillScript.skill3buffOn = false;
        skillScript.skill5buffOn = false;
        skillScript.skill7buffOn = false;
        skillScript.skill8buffOn = false;
        skillScript.skill11buffOn = false;
        skillScript.skill14buffOn = false;
        skillScript.skill16buffOn = false;
        skillScript.skill21buffOn = false;
        skillScript.skill25buffOn = false;
        skillScript.skill26buffOn = false;
        skillScript.skill27buffOn = false;
        skillScript.skill28buffOn = false;
        skillScript.skill31buffOn = false;
        skillScript.skill32buffOn = false;
        skillScript.skill33buffOn = false;
        skillScript.skill37Active = false;
        skillScript.skill39buffOn = false;


        //reset position
        SetWorldPosition();
        SetWorldRotation();

        //remove all effects
        foreach (Effect e in effects)
        {
            e.Remove();
        }

        effects = new List<Effect>();

        synergyIsApply = true;
    }

    /// <summary>
    /// Assign new grid position
    /// </summary>
    /// <param name="_gridType"></param>
    /// <param name="_gridPositionX"></param>
    /// <param name="_gridPositionZ"></param>
    public void SetGridPosition(int _gridType, int _gridPositionX, int _gridPositionZ)
    {
        gridType = _gridType;
        gridPositionX = _gridPositionX;
        gridPositionZ = _gridPositionZ;


        //set new target when chaning grid position
        gridTargetPosition = GetWorldPosition();
    }

    /// <summary>
    /// Convert grid position to world position
    /// </summary>
    /// <returns></returns>
    public Vector3 GetWorldPosition()
    {
        //get world position
        Vector3 worldPosition = Vector3.zero;

        if (gridType == Map.GRIDTYPE_OWN_INVENTORY)
        {
            worldPosition = map.ownInventoryGridPositions[gridPositionX];
        }
        else if (gridType == Map.GRIDTYPE_HEXA_MAP)
        {
            worldPosition = map.mapGridPositions[gridPositionX, gridPositionZ];

        }

        return worldPosition;
    }

    /// <summary>
    /// Move to corrent world position
    /// </summary>
    public void SetWorldPosition()
    {
        navMeshAgent.enabled = false;

        //get world position
        Vector3 worldPosition = GetWorldPosition();

        this.transform.position = worldPosition;

        gridTargetPosition = worldPosition;
    }

    /// <summary>
    /// Set correct rotation
    /// </summary>
    public void SetWorldRotation()
    {
        Vector3 rotation = Vector3.zero;

        if (teamID == 0)
        {
            rotation = new Vector3(0, 200, 0);
        }
        else if (teamID == 1)
        {
            rotation = new Vector3(0, 20, 0);
        }
        this.transform.rotation = Quaternion.Euler(rotation);
    }

    public void AttackEffect()
    {
        GameObject Attackeffect = Instantiate(AttackEffectPrefab);

        //set position
        Attackeffect.transform.position = target.transform.position;

        //destroy effect after finished
        Destroy(Attackeffect, 2.0f);
    }


    public void SkillEffect(GameObject T, Vector3 dir, float skilltime)
    {
        Debug.Log("스킬발동");
        gamePlayController.SkillSound();
        GameObject SkillEffect = Instantiate(SkillEffectPrefab);

        //set position
        SkillEffect.transform.position = T.transform.position;
        SkillEffect.transform.forward = dir;

        //destroy effect after finished
        Destroy(SkillEffect, skilltime);
    }
    public void SkillEffect2(GameObject T, Vector3 dir, float time)
    {
        Debug.Log("스킬발동");
        GameObject SkillEffect = Instantiate(SkillEffectPrefab2);

        //set position
        SkillEffect.transform.position = T.transform.position;
        SkillEffect.transform.forward = dir;

        //destroy effect after finished
        Destroy(SkillEffect, time);
    }

    /// <summary>
    /// Upgrade champion lvl
    /// </summary>
    public void UpgradeLevel()
    {

        GameObject levelupEffect = Instantiate(levelupEffectPrefab);

        //set position
        levelupEffect.transform.position = this.transform.position;

        //destroy effect after finished
        Destroy(levelupEffect, 1.0f);
    }


    public void ElephantSkill(float range)
    {
        float skillrange = range;
        float Elephantcount = 0;
        for (int x = 0; x < Map.hexMapSizeX; x++)
        {
            for (int z = 0; z < Map.hexMapSizeZ / 2; z++)
            {
                if (aIopponent.gridChampionsArray[x, z] != null)
                {
                    ChampionController championController = aIopponent.gridChampionsArray[x, z].GetComponent<ChampionController>();

                    if (championController.isDead == false)
                    {
                        //calculate distance
                        float distance = Vector3.Distance(this.transform.position, aIopponent.gridChampionsArray[x, z].transform.position);
                        //if new this champion is closer then best distance
                        if (distance < skillrange)
                        {
                            Elephantcount++;
                            float damage = this.currentDamage;
                            if (championController.currentShield < damage)
                            {
                                championController.currentShield = 0;
                                championController.currentHealth -= damage - championController.currentShield;
                            }
                            else championController.currentShield -= damage;
                        }
                    }

                }
            }
        }
        if (this.lvl == 1)
        {
            currentShield += maxHealth * 0.1f * Elephantcount;
        }
        if (this.lvl == 2)
        {
            currentShield += maxHealth * 0.2f * Elephantcount;
        }
        if (this.lvl == 3)
        {
            currentShield += maxHealth * 0.4f * Elephantcount;
        }
    }

    public void SheepSkill(float damage)
    {
        for (int x = 0; x < Map.hexMapSizeX; x++)
        {
            for (int z = 0; z < Map.hexMapSizeZ / 2; z++)
            {
                if (gamePlayController.gridChampionsArray[x, z] != null)
                {
                    ChampionController championController = gamePlayController.gridChampionsArray[x, z].GetComponent<ChampionController>();
                    championController.currentHealth += damage;
                    if (championController.currentHealth > championController.maxHealth)
                    {
                        championController.currentHealth = championController.maxHealth;
                    }
                }
            }
        }
    }

    public void SalamanderSkill(float time)
    {
        float skillrange = 5;
        //find enemy
        Debug.Log("살라맨더 스킬 시작");
        SkillEffect(this.gameObject, this.transform.forward, 2);
        if (teamID == TEAMID_PLAYER)
        {
            for (int x = 0; x < Map.hexMapSizeX; x++)
            {
                for (int z = 0; z < Map.hexMapSizeZ / 2; z++)
                {
                    if (aIopponent.gridChampionsArray[x, z] != null)
                    {
                        ChampionController championController = aIopponent.gridChampionsArray[x, z].GetComponent<ChampionController>();

                        if (championController.isDead == false)
                        {
                            //calculate distance
                            float distance = Vector3.Distance(this.transform.position, aIopponent.gridChampionsArray[x, z].transform.position);
                            //if new this champion is closer then best distance
                            if (distance < skillrange)
                            {
                                championController.isSalamanderSkill = true;
                                championController.salamanderskillCount = (int)time;
                                championController.salamanderPoisonDamage = currentDamage;
                                Debug.Log("대상 : " + championController);

                            }
                        }

                    }
                }
            }
        }
    }


    public void RatSkill(float range)
    {
        isDead = false;
        float skillrange = range;
        //find enemy
        SkillEffect(this.gameObject, this.transform.forward, 2);
        if (teamID == TEAMID_PLAYER)
        {
            for (int x = 0; x < Map.hexMapSizeX; x++)
            {
                for (int z = 0; z < Map.hexMapSizeZ / 2; z++)
                {
                    if (aIopponent.gridChampionsArray[x, z] != null)
                    {
                        ChampionController championController = aIopponent.gridChampionsArray[x, z].GetComponent<ChampionController>();

                        if (championController.isDead == false)
                        {
                            //calculate distance
                            float distance = Vector3.Distance(this.transform.position, aIopponent.gridChampionsArray[x, z].transform.position);
                            //if new this champion is closer then best distance
                            if (distance < skillrange)
                            {
                                championController.isRatSkill = true;
                                championController.RatSkillTimer = 15;
                            }
                        }

                    }
                }
            }
        }
    }

    public void ComodoSkill(float range)
    {
        float skillrange = range;
        //find enemy
        if (teamID == TEAMID_PLAYER)
        {
            for (int x = 0; x < Map.hexMapSizeX; x++)
            {
                for (int z = 0; z < Map.hexMapSizeZ / 2; z++)
                {
                    if (aIopponent.gridChampionsArray[x, z] != null)
                    {
                        ChampionController championController = aIopponent.gridChampionsArray[x, z].GetComponent<ChampionController>();

                        if (championController.isDead == false)
                        {
                            //calculate distance
                            float distance = Vector3.Distance(this.transform.position, aIopponent.gridChampionsArray[x, z].transform.position);

                            //if new this champion is closer then best distance
                            if (distance < skillrange)
                            {
                                Debug.Log("거리 :" + distance + "/ 타겟 :" + championController);
                                championController.isStuned = true;
                                championController.stunTimer = 3;
                                championController.isComodoStack = true;
                                championController.comodoStack = 10;
                                championController.comodoStackLevel = this.lvl;
                            }
                        }
                    }
                }
            }
        }
    }
    
    public void FrogSkill(float rate, float time)
    {
        float skillrange = 5;
        for (int x = 0; x < Map.hexMapSizeX; x++)
        {
            for (int z = 0; z < Map.hexMapSizeZ / 2; z++)
            {
                if (aIopponent.gridChampionsArray[x, z] != null)
                {
                    ChampionController championController = aIopponent.gridChampionsArray[x, z].GetComponent<ChampionController>();

                    if (championController.isDead == false)
                    {
                        //calculate distance
                        float distance = Vector3.Distance(this.transform.position, aIopponent.gridChampionsArray[x, z].transform.position);

                        //if new this champion is closer then best distance
                        if (distance < skillrange)
                        {
                            float damage = this.currentDamage * rate;
                            if (championController.currentShield < damage)
                            {
                                championController.currentShield = 0;
                                championController.currentHealth -= damage - championController.currentShield;
                            }
                            else championController.currentShield -= damage;
                            championController.OnGotStun(time);
                            SkillEffect(championController.gameObject, this.transform.forward, 1);
                            worldCanvasController.AddDamageText(gameObject.GetComponent<Transform>().position + new Vector3(0, 2.5f, 0), this.currentDamage * damage, Color.red);
                        }
                    }
                }
            }
        }
    }
  
    

    public void ScorpionSkill(float damage)
    {
        float skillrange = 6;
        //find enemy
        SkillEffect(this.gameObject, this.transform.forward, 2);
        if (teamID == TEAMID_PLAYER)
        {
            for (int x = 0; x < Map.hexMapSizeX; x++)
            {
                for (int z = 0; z < Map.hexMapSizeZ / 2; z++)
                {
                    if (aIopponent.gridChampionsArray[x, z] != null)
                    {
                        ChampionController championController = aIopponent.gridChampionsArray[x, z].GetComponent<ChampionController>();

                        if (championController.isDead == false)
                        {
                            //calculate distance
                            float distance = Vector3.Distance(this.transform.position, aIopponent.gridChampionsArray[x, z].transform.position);

                            //if new this champion is closer then best distance
                            if (distance < skillrange)
                            {
                                Debug.Log("거리 :" + distance + "/ 타겟 :" + championController);
                                championController.currentHealth -= this.currentDamage * damage;
                                worldCanvasController.AddDamageText(gameObject.GetComponent<Transform>().position + new Vector3(0, 2.5f, 0), this.currentDamage * damage, Color.red);
                                championController.isScorpionSkill = true;
                                championController.scorpionPoisonDamage = this.currentDamage * 0.5f;
                            }
                        }
                    }
                }
            }
        }
    }

    public void OctopusSkill(float time)
    {
        RaycastHit[] OctopusSkillhit;
        float skillrange = 7;
        OctopusSkillTimer = time;
        OctopusSkillhit = Physics.RaycastAll(transform.position, transform.forward, skillrange);
        for (int i = 0; i < OctopusSkillhit.Length; i++)
        {
            if (OctopusSkillhit[i].collider.gameObject.tag == "Enemy")
            {
                GameObject gameObject = OctopusSkillhit[i].collider.gameObject;
                Debug.Log("넌 실명 당했다" + OctopusSkillhit[i].collider.gameObject);
                gameObject.GetComponent<ChampionController>().isOctopusSkill = true;
                gameObject.GetComponent<ChampionController>().OctopusSkillTimer = time;
               gameObject.GetComponent<ChampionController>().currentDamage = 0;
            }
        }
    }

    public void Enemy61SkillOn()
    {
        isEnemy61skillChanneling = true;
        isStuned = true;
        stunTimer = 6;
        enemy61skillChannelingTimer = 6;
        enemy61skillCount = 0;
        navMeshAgent.isStopped = true;
    }


    public void Enemy61Skill()
    {
        for (int x = 0; x < Map.hexMapSizeX; x++)
        {
            for (int z = 0; z < Map.hexMapSizeZ / 2; z++)
            {
                if (gamePlayController.gridChampionsArray[x, z] != null)
                {
                    ChampionController championController = gamePlayController.gridChampionsArray[x, z].GetComponent<ChampionController>();
                    if (championController.isDead == false)
                    {
                        float damage;
                        damage = currentDamage * 0.5f;
                        championController.currentHealth -= damage;
                        int manaBurn = Random.Range(1, 101);
                        if (manaBurn < 30)
                        {
                            championController.currentMana -= 20;
                        }
                        worldCanvasController.AddDamageText(gameObject.GetComponent<Transform>().position + new Vector3(0, 2.5f, 0), this.currentDamage * damage, Color.red);
                    }
                }
            }
        }
    }


    public void GoatskillOn()
    {
        isGoatskillChanneling = true;
        isStuned = true;
        stunTimer = 5;
        goatskillChannelingTimer = 5;
        goatskillCount = 0;
        navMeshAgent.isStopped = true;
    }
    public void GoatSkill()
    {
        RaycastHit[] GoatSkillhit;
        float skillrange = 20;
        float damage = 0;
        if (this.lvl == 1)
        {
            damage = this.currentDamage;
        }
        if (this.lvl == 2)
        {
            damage = this.currentDamage * 1f;
        }
        if (this.lvl == 3)
        {
            damage = this.currentDamage * 10;
        }
        GoatSkillhit = Physics.RaycastAll(transform.position, transform.forward, skillrange);
        for (int i = 0; i < GoatSkillhit.Length; i++)
        {
            if (GoatSkillhit[i].collider.gameObject.tag == "Enemy")
            {
                GameObject gameObject = GoatSkillhit[i].collider.gameObject;
                gameObject.GetComponent<ChampionController>().currentHealth -= damage;
                worldCanvasController.AddDamageText(gameObject.GetComponent<Transform>().position + new Vector3(0, 2.5f, 0), damage, Color.red);
                Debug.Log(damage);
                Debug.Log(gameObject);
            }
        }
    }

    public void SilenceSkill(float time)
    {
        silenceTimer = time;
        float skillrange = 12;
        //find enemy
        if (teamID == TEAMID_PLAYER)
        {
            for (int x = 0; x < Map.hexMapSizeX; x++)
            {
                for (int z = 0; z < Map.hexMapSizeZ / 2; z++)
                {
                    if (aIopponent.gridChampionsArray[x, z] != null)
                    {
                        ChampionController championController = aIopponent.gridChampionsArray[x, z].GetComponent<ChampionController>();

                        if (championController.isDead == false)
                        {
                            //calculate distance
                            float distance = Vector3.Distance(this.transform.position, aIopponent.gridChampionsArray[x, z].transform.position);

                            //if new this champion is closer then best distance
                            if (distance < skillrange)
                            {
                                Debug.Log("거리 :" + distance + "/ 타겟 :" + championController);
                                championController.isSilence = true;
                            }
                        }
                    }
                }
            }
        }
    }

    private GameObject target;
    /// <summary>
    /// Find the a champion the the closest world position
    /// </summary>
    /// <returns></returns>
    private GameObject FindTarget()
    {
        GameObject closestEnemy = null;
        float bestDistance = 1000;
        //find enemy
        if (teamID == TEAMID_PLAYER)
        {
            for (int x = 0; x < Map.hexMapSizeX; x++)
            {
                for (int z = 0; z < Map.hexMapSizeZ / 2; z++)
                {
                    if (aIopponent.gridChampionsArray[x, z] != null)
                    {
                        ChampionController championController = aIopponent.gridChampionsArray[x, z].GetComponent<ChampionController>();

                        if (championController.isDead == false)
                        {
                            //calculate distance
                            float distance = Vector3.Distance(this.transform.position, aIopponent.gridChampionsArray[x, z].transform.position);

                            //if new this champion is closer then best distance
                            if (distance < bestDistance)
                            {
                                bestDistance = distance;
                                closestEnemy = aIopponent.gridChampionsArray[x, z];
                            }
                        }
                    }
                }
            }
        }
        else if (teamID == TEAMID_AI)
        {

            for (int x = 0; x < Map.hexMapSizeX; x++)
            {
                for (int z = 0; z < Map.hexMapSizeZ / 2; z++)
                {
                    if (gamePlayController.gridChampionsArray[x, z] != null)
                    {
                        ChampionController championController = gamePlayController.gridChampionsArray[x, z].GetComponent<ChampionController>();

                        if (championController.isDead == false)
                        {
                            //calculate distance
                            float distance = Vector3.Distance(this.transform.position, gamePlayController.gridChampionsArray[x, z].transform.position);

                            //if new this champion is closer then best distance
                            if (distance < bestDistance)
                            {
                                bestDistance = distance;
                                closestEnemy = gamePlayController.gridChampionsArray[x, z];
                            }
                        }
                    }
                }
            }

        }


        return closestEnemy;
    }

    /// <summary>
    /// Looks for new target to attack if there is any
    /// </summary>
    private void TryAttackNewTarget()
    {
        //find closest enemy
        target = FindTarget();

        //if target found
        if (target != null)
        {
            //set pathfinder target
            navMeshAgent.destination = target.transform.position;


            navMeshAgent.isStopped = false;
        }
    }

    /// <summary>
    /// Called when gamestage.combat starts
    /// </summary>
    public void OnCombatStart()
    {
        IsDragged = false;

        this.transform.position = gridTargetPosition;


        //in combat grid
        if (gridType == Map.GRIDTYPE_HEXA_MAP)
        {
            isInCombat = true;

            navMeshAgent.enabled = true;

            TryAttackNewTarget();

        }

    }


    /// <summary>
    /// Start attack against enemy champion
    /// </summary>
    private void DoAttack()
    {
        isAttacking = true;

        //stop navigation
        navMeshAgent.isStopped = true;

        championAnimation.DoAttack(true);

        AttackEffect();


    }

    /// <summary>
    /// Called when attack animation finished
    /// </summary>
    public void OnAttackAnimationFinished()
    {
        isAttacking = false;

        if (target != null)
        {
            //  //get enemy target champion
            ChampionController targetChamoion = target.GetComponent<ChampionController>();
            //  
            //  List<ChampionBonus> activeBonuses = null;
            //  
            //  if (teamID == TEAMID_PLAYER)
            //  {
            //      activeBonuses = gamePlayController.activeBonusList;
            //  }
            //  foreach (ChampionBonus b in activeBonuses)
            //  {
            //      b.ApplyOnAttack(this, targetChamoion);
            //  }

            if (champion.uiname == "상어")
            {
                Debug.Log("상어");
                if (this.lvl == 1) SharkSkill(targetChamoion, 20);
                else if (this.lvl == 2) SharkSkill(targetChamoion, 30);
                else if (this.lvl == 3) SharkSkill(targetChamoion, 40);
            }

            //deal damage
            bool isTargetDead = targetChamoion.OnGotHit(currentDamage, this);

            if (champion.uiname == "악어")
            {
                Debug.Log("공격횟수");
                int ranBleeding = Random.Range(1, 101);
                if (ranBleeding > 50)
                {
                    targetChamoion.isCrocodileStack = true;
                    targetChamoion.crocodileStack++;
                    Debug.Log("출혈스택");
                    targetChamoion.crocodileBleedingDamage = currentDamage * 0.1f;
                    if (lvl == 1 && targetChamoion.crocodileStack >= 10)
                    {
                        Debug.Log("처형");
                        targetChamoion.currentHealth = 0;
                        SkillEffect(target.gameObject, target.transform.forward, 1f);
                        currentHealth += maxHealth * 0.5f;
                        if (currentHealth > maxHealth)
                        {
                            currentHealth = maxHealth;
                        }
                        DoAttack();

                    }
                    else if (lvl == 2 && targetChamoion.crocodileStack >= 8)
                    {
                        targetChamoion.currentHealth = 0;
                        SkillEffect(target.gameObject, target.transform.forward, 1f);
                        currentHealth += maxHealth * 0.5f;
                        if (currentHealth > maxHealth)
                        {
                            currentHealth = maxHealth;
                        }
                        DoAttack();
                    }
                    else if (lvl == 3 && targetChamoion.crocodileStack >= 5)
                    {
                        targetChamoion.currentHealth = 0;
                        SkillEffect(target.gameObject, target.transform.forward, 1f);
                        currentHealth += maxHealth * 0.5f;
                        if (currentHealth > maxHealth)
                        {
                            currentHealth = maxHealth;
                        }
                        DoAttack();
                    }
                }
            }


            if (champion.uiname == "코모도왕도마뱀")
            {
                targetChamoion.isComodoStack = true;
                targetChamoion.comodoStackLevel = this.lvl;
                if (targetChamoion.comodoStack < 10)
                {
                    targetChamoion.comodoStack++;
                }
            }

            if (champion.uiname == "달팽이")
            {
                Debug.Log("쌓이냐?");
                snailStack++;
            }
            // 타격 시, 마나 회복
            currentMana += currentAttackMana;
            if (currentMana >= maxMana)
            {
                // 스킬 구현
                if (target != null)
                {

                    skillScript.SkillFire(skillID, this, target.GetComponent<ChampionController>());
                    currentMana = 0;
                    if (strength)
                    {
                        if (champType2.displayName == "힘의상징")
                        {
                            currentAttackSpeed *= 1 + (strengthValue2 / 100);
                            timeStrength = -strengthValue1;
                        }
                    }

                    if (ability)
                    {
                        gamePlayController.Ability(abilityValue1);
                    }
                }
                else
                {
                    currentMana = maxMana;
                }
            }

            if (admirer == true)
            {
                if (champType2.displayName == "숭배자")
                {
                    currentHealth += (maxHealth - currentHealth) * (admirerValue / 100);
                    if (currentHealth >= maxHealth) currentHealth = maxHealth;
                }
            }

            //target died from attack
            if (isTargetDead)
            {
                if (champType2.displayName == "죽음의상징")
                {
                    if (death == true)
                    {
                        gamePlayController.Death(deathValue2);
                    }
                }

                if (sin7)
                {
                    gamePlayController.Sin7Shield(sin7Shield);
                }
                TryAttackNewTarget();
            }


            //create projectile if have one
            if (champion.attackProjectile != null && projectileStart != null)
            {
                GameObject projectile = Instantiate(champion.attackProjectile);
                projectile.transform.position = projectileStart.transform.position;

                projectile.GetComponent<Projectile>().Init(target);


            }
        }
    }

    /// <summary>
    /// Called when this champion takes damage
    /// </summary>
    /// <param name="damage"></param>
    public bool OnGotHit(float damage, ChampionController by)
    {
        Dictionary<ChampionBonus, int> activeBonuses = null;



        activeBonuses = gamePlayController.activeBonus;


        float finalDamage = damage;
        if (activeBonuses != null)
        {
            foreach (KeyValuePair<ChampionBonus, int> b in activeBonuses)
            {
                finalDamage = b.Key.ApplyOnGotHit(this, by, b.Value, finalDamage);
            }
        }
        else
        {
            int ranCri = Random.Range(1, 101);
            if (ranCri <= currentCritical)
            {
                finalDamage = damage * (1.0f - (currentDefence / (currentDefence + 100.0f))) * 1.5f;
            }
            else finalDamage = damage * (1.0f - (1.0f * currentDefence / (1.0f * currentDefence + 100.0f)));
        }


        int ran = Random.Range(1, 101);

        if (ran <= currentEvasion)
        {
            finalDamage = 0;
        }
        else
        {
            if (currentShield == 0)
            {
                currentHealth -= finalDamage;
            }
            else if (currentShield < finalDamage)
            {
                currentShield = 0;
                currentHealth -= finalDamage - currentShield;
                if (champion.uiname == "달팽이")
                {
                    if (skillScript.skill37Active == true)
                    {
                        if (this.lvl == 1)
                            SnailSkill(0.1f, 6);
                        else if (this.lvl == 2)
                            SnailSkill(0.2f, 6);
                        else if (this.lvl == 3)
                            SnailSkill(1, 6);
                        skillScript.skill37Active = false;
                    }
                }
            }
            else
            {
                currentShield -= finalDamage;
            }
        }


        //  피격 시, 마나 회복
        currentMana += currentHitMana;


        //death
        if (currentHealth <= 0)
        {
            if (isSalamanderSkillOn == true)
            {
                isSalamanderDead = true;
                skillScript.SkillFire(skillID, this, target.GetComponent<ChampionController>());

            }
            if (isRatSkillOn == true)
            {
                isRatDead = true;
                skillScript.SkillFire(skillID, this, target.GetComponent<ChampionController>());
                isRatDead = false;
            }
            if (teamID == TEAMID_PLAYER)
            {
                if (loyality == true)
                {
                    gamePlayController.Loyality(loyalityValue2);
                }
            }


            this.gameObject.SetActive(false);
            isDead = true;

            aIopponent.OnChampionDeath();
            gamePlayController.OnChampionDeath();
        }




        //add floating text
        worldCanvasController.AddDamageText(this.transform.position + new Vector3(0, 2.5f, 0), finalDamage, Color.white);

        return isDead;
    }

    public void SnailSkill(float rate, float range)
    {
        SkillEffect2(this.gameObject, this.transform.forward, 1f);
        for (int x = 0; x < Map.hexMapSizeX; x++)
        {
            for (int z = 0; z < Map.hexMapSizeZ / 2; z++)
            {
                if (aIopponent.gridChampionsArray[x, z] != null)
                {
                    ChampionController championController = aIopponent.gridChampionsArray[x, z].GetComponent<ChampionController>();

                    if (championController.isDead == false)
                    {
                        //calculate distance
                        float distance = Vector3.Distance(this.transform.position, aIopponent.gridChampionsArray[x, z].transform.position);
                        //if new this champion is closer then best distance
                        if (distance < range)
                        {
                            float damage = skillScript.shield * rate;
                            Debug.Log(damage);
                            if (championController.currentShield == 0)
                            {
                                championController.currentHealth -= damage;
                            }
                            else if (championController.currentShield < damage)
                            {
                                championController.currentShield = 0;
                                championController.currentHealth -= damage - championController.currentShield;
                            }
                            else
                            {
                                championController.currentShield -= damage;
                            }
                            worldCanvasController.AddDamageText(championController.transform.position + new Vector3(0, 2, 0), damage, Color.red);
                            snailStack = 0;
                        }
                    }

                }
            }
        }
    }

    public void SharkSkill(ChampionController target, float rate)
    {
        if (target.currentHealth <= target.maxHealth * (rate / 100))
        {
            target.currentHealth = 0;
            SkillEffect(this.gameObject, this.transform.forward, 1f);
        }
    }


    /// <summary>
    /// Called when this champion get stuned
    /// </summary>
    /// <param name="stunEffectPrefab"></param>
    public void OnGotStun(float duration)
    {
        isStuned = true;
        stunTimer = duration;

        //  championAnimation.IsAnimated(false);

        navMeshAgent.isStopped = true;
    }

    /// <summary>
    /// Called when this champion get healed
    /// </summary>
    /// <param name="stunEffectPrefab"></param>
    public void OnGotHeal(float f)
    {
        currentHealth += f;
    }

    public void OnGotShield(float shield)
    {
        currentShield += maxHealth * (shield / 100);
    }





    /// <summary>
    /// Add effect to this champion
    /// </summary>
    public void AddEffect(GameObject effectPrefab, float duration)
    {
        if (effectPrefab == null)
            return;

        //look for effect
        bool foundEffect = false;
        foreach (Effect e in effects)
        {
            if (effectPrefab == e.effectPrefab)
            {
                e.duration = duration;
                foundEffect = true;
            }
        }

        //not found effect
        if (foundEffect == false)
        {
            Effect effect = this.gameObject.AddComponent<Effect>();
            effect.Init(effectPrefab, this.gameObject, duration);
            effects.Add(effect);
        }

    }

    /// <summary>
    /// Remove effect when expired
    /// </summary>
    public void RemoveEffect(Effect effect)
    {
        effects.Remove(effect);
        effect.Remove();
    }


    public void ApplyActiveSynergy()
    {
        // 능력치 초기화
        maxHealth = champion.health;
        currentHealth = champion.health;
        currentHealthReg = champion.healthRegeneration;
        currentShield = champion.shield;

        maxMana = champion.mana;
        currentMana = 20;
        currentHitMana = champion.hitMana;
        currentAttackMana = champion.attackMana;

        currentDamage = champion.damage;
        currentCritical = champion.critical;
        currentEvasion = champion.evasion;
        currentAttackSpeed = champion.attackSpeed;

        currentDefence = champion.defence;

        currentMoveSpeed = champion.movementSpeed;
        sin7 = false;
        sin7Shield = 0;
        wealthOn = false;
        wealthValue = 0;
        admirer = false;
        admirerValue = 0;
        loyality = false;
        loyalityValue1 = 0;
        loyalityValue2 = 0;
        death = false;
        deathValue1 = 0;
        deathValue2 = 0;
        timeLoyal = 1;
        timeDeath = 1;
        strength = false;
        strengthValue1 = 0;
        strengthValue2 = 0;
        timeStrength = 1;
        ability = false;
        abilityValue1 = 0;


        // 시너지 적용
        Dictionary<ChampionBonus, int> activeBonuses = null;

        if (teamID == TEAMID_PLAYER)
        {
            activeBonuses = gamePlayController.activeBonus;
            if (activeBonuses != null)
            {
                foreach (KeyValuePair<ChampionBonus, int> b in activeBonuses)
                {
                    b.Key.ApplySynergy(this, b.Value);
                }
            }
        }
    }
}


