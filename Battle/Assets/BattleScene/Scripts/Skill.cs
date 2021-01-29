using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    GamePlayController gamePlayController;
    GameData gameData;
    WorldCanvasController worldCanvasController;

    public GameObject[,] combatChampionsArray;

    public float time = 0;

    float duration3 = -1;
    public bool skill3buffOn = false;
    ChampionController skill3Attacker;

    float duration5 = -1;
    public bool skill5buffOn = false;
    ChampionController skill5Attacker;

    float duration7 = -1;
    public bool skill7buffOn = false;
    ChampionController skill7Attacker;

    float duration8 = -1;
    public bool skill8buffOn = false;
    ChampionController skill8Attacker;
    ChampionController skill8Target;

    float duration11 = -1;
    public bool skill11buffOn = false;
    ChampionController skill11Attacker;

    float duration14 = -1;
    public bool skill14buffOn = false;
    ChampionController skill14Attacker;
    ChampionController skill14Target;

    float duration16 = -1;
    public bool skill16buffOn = false;
    ChampionController skill16Attacker;

    float duration21 = -1;
    public bool skill21buffOn = false;
    ChampionController skill21Attacker;

    float duration25 = -1;
    public bool skill25buffOn = false;
    ChampionController skill25Attacker;



    public void SkillFire(int ID, ChampionController attacker, ChampionController target)
    {
        switch (ID)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                for (int x = 0; x < Map.hexMapSizeX; x++)
                {
                    for (int z = 0; z < Map.hexMapSizeZ; z++)
                    {
                        if (combatChampionsArray[x, z] != null)
                        {
                            ChampionController champion = combatChampionsArray[x, z].GetComponent<ChampionController>();
                            skill3Attacker = attacker;
                            if (skill3buffOn == false)
                            {
                                if (champion.teamID == 0)
                                {
                                    if (attacker.lvl == 1)
                                        champion.currentDefence += 20;
                                    else if (attacker.lvl == 2)
                                        champion.currentDefence += 40;
                                    else if (attacker.lvl == 3)
                                        champion.currentDefence += 80;
                                    skill3buffOn = true;
                                }
                            }
                            duration3 = this.time + 10; // 지속시간                 
                        }
                    }
                }
                break;
            case 4:
                break;
            case 5:
                for (int x = 0; x < Map.hexMapSizeX; x++)
                {
                    for (int z = 0; z < Map.hexMapSizeZ; z++)
                    {
                        if (combatChampionsArray[x, z] != null)
                        {
                            ChampionController champion = combatChampionsArray[x, z].GetComponent<ChampionController>();
                            skill5Attacker = attacker;
                            if (skill5buffOn == false)
                            {
                                if (champion.teamID == 0)
                                {
                                    if (attacker.lvl == 1)
                                        champion.currentDefence += 50;
                                    else if (attacker.lvl == 2)
                                        champion.currentDefence += 80;
                                    else if (attacker.lvl == 3)
                                        champion.currentDefence += 130;
                                    skill5buffOn = true;
                                }
                            }
                            duration5 = this.time + 60; // 지속시간
                        }
                    }
                }
                break;
            case 6:
                break;
            case 7:
                for (int x = 0; x < Map.hexMapSizeX; x++)
                {
                    for (int z = 0; z < Map.hexMapSizeZ; z++)
                    {
                        if (combatChampionsArray[x, z] != null)
                        {
                            ChampionController champion = combatChampionsArray[x, z].GetComponent<ChampionController>();
                            skill7Attacker = attacker;
                            if (skill7buffOn == false)
                            {
                                if (champion.teamID == 0)
                                {
                                    if (attacker.lvl == 1)
                                        champion.currentDefence += champion.currentDamage * (20 / 100);
                                    else if (attacker.lvl == 2)
                                        champion.currentDefence += champion.currentDamage * (30 / 100);
                                    else if (attacker.lvl == 3)
                                        champion.currentDefence += champion.currentDamage * (40 / 100);
                                    skill7buffOn = true;
                                }
                            }
                            duration7 = this.time + 20; // 지속시간                 
                        }
                    }
                }
                break;
            case 8:
                if (skill8buffOn == false)
                {
                    skill8Attacker = attacker;
                    skill8Target = target;
                    if (attacker.lvl == 1) target.currentAttackSpeed *= 0.7f;
                    else if (attacker.lvl == 2) target.currentAttackSpeed *= 0.5f;
                    else if (attacker.lvl == 3) target.currentAttackSpeed *= 0.3f;
                    skill8buffOn = true;
                    duration8 = this.time + 10; // 지속시간
                }
                break;
            case 9:
                if (attacker.lvl == 1) attacker.currentShield += 400;
                else if (attacker.lvl == 2) attacker.currentShield += 800;
                else if (attacker.lvl == 3) attacker.currentShield += 1500;
                break;
            case 10:
                break;
            case 11:
                if (skill11buffOn == false)
                {
                    attacker.currentAttackSpeed *= 300 / 100;
                    duration11 = this.time + 5; // 지속시간
                }
                break;
            case 12:
                break;
            case 13:
                float time = 1;
                if (attacker.lvl == 1)
                {
                    time *= 2;
                    attacker.OctopusSkill(time);
                }
                else if (attacker.lvl == 2)
                {
                    time *= 4;
                    attacker.OctopusSkill(time);
                }
                else if (attacker.lvl == 3)
                {
                    time *= 6;
                    attacker.OctopusSkill(time);
                }
                break;
            case 14:
                skill14Attacker = attacker;
                skill14Target = target;
                float damage = attacker.currentDamage * (150 / 100);
                if (target.currentShield < damage)
                {
                    target.currentShield = 0;
                    target.currentHealth -= damage - target.currentShield;
                }
                else target.currentShield -= damage;

                worldCanvasController.AddDamageText(attacker.transform.position + new Vector3(0, 2.5f, 0), damage);

                if (skill14buffOn == false)
                {
                    if (attacker.lvl == 1) target.currentDefence *= 0.9f;
                    else if (attacker.lvl == 2) target.currentDefence *= 0.8f;
                    else if (attacker.lvl == 3) target.currentDefence *= 0.7f;
                    duration14 = this.time + 10; // 지속시간
                }
                break;
            case 15:
                break;
            case 16:
                for (int x = 0; x < Map.hexMapSizeX; x++)
                {
                    for (int z = 0; z < Map.hexMapSizeZ; z++)
                    {
                        if (combatChampionsArray[x, z] != null)
                        {
                            ChampionController champion = combatChampionsArray[x, z].GetComponent<ChampionController>();
                            skill16Attacker = attacker;
                            if (skill16buffOn == false)
                            {
                                if (champion.teamID == 0)
                                {
                                    if (attacker.lvl == 1)
                                        champion.currentDefence += champion.currentAttackSpeed * (120 / 100);
                                    else if (attacker.lvl == 2)
                                        champion.currentDefence += champion.currentAttackSpeed * (130 / 100);
                                    else if (attacker.lvl == 3)
                                        champion.currentDefence += champion.currentAttackSpeed * (150 / 100);
                                    skill16buffOn = true;
                                }
                            }
                            duration16 = this.time + 10; // 지속시간                 
                        }
                    }
                }
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
                if (attacker.lvl == 1) attacker.currentShield += attacker.maxHealth * 0.1f;
                else if (attacker.lvl == 2) attacker.currentShield += attacker.maxHealth * 0.2f;
                else if (attacker.lvl == 3) attacker.currentShield += attacker.maxHealth * 0.4f;
                break;
            case 21:
                for (int x = 0; x < Map.hexMapSizeX; x++)
                {
                    for (int z = 0; z < Map.hexMapSizeZ; z++)
                    {
                        if (combatChampionsArray[x, z] != null)
                        {
                            ChampionController champion = combatChampionsArray[x, z].GetComponent<ChampionController>();
                            skill21Attacker = attacker;
                            if (skill21buffOn == false)
                            {
                                if(champion.teamID == 0)
                                {
                                    if (attacker.lvl == 1)
                                        champion.currentAttackSpeed *= (150 / 100);
                                    else if (attacker.lvl == 2)
                                        champion.currentAttackSpeed *= (175 / 100);
                                    else if (attacker.lvl == 3)
                                        champion.currentAttackSpeed *= (200 / 100);
                                    skill21buffOn = true;
                                }
                            }
                            duration21 = this.time + 5; // 지속시간                 
                        }
                    }
                }
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
                for (int x = 0; x < Map.hexMapSizeX; x++)
                {
                    for (int z = 0; z < Map.hexMapSizeZ; z++)
                    {
                        if (combatChampionsArray[x, z] != null)
                        {
                            ChampionController champion = combatChampionsArray[x, z].GetComponent<ChampionController>();
                            if (champion.teamID == 1) 
                            {
                                if (attacker.lvl == 1) champion.currentDamage *= 97 / 100;
                                else if (attacker.lvl == 2) champion.currentDamage *= 95 / 100;
                                else if (attacker.lvl == 3) champion.currentDamage *= 98 / 100;
                            }
                        }
                    }
                }
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
                attacker.currentHealth *= 50 / 100;
                for (int x = 0; x < Map.hexMapSizeX; x++)
                {
                    for (int z = 0; z < Map.hexMapSizeZ; z++)
                    {
                        if (combatChampionsArray[x, z] != null)
                        {
                            ChampionController champion = combatChampionsArray[x, z].GetComponent<ChampionController>();
                            skill21Attacker = attacker;
                            if (skill21buffOn == false)
                            {
                                if (champion.teamID == 0)
                                {
                                    if (attacker.lvl == 1)
                                        champion.currentAttackSpeed *= (150 / 100);
                                    else if (attacker.lvl == 2)
                                        champion.currentAttackSpeed *= (175 / 100);
                                    else if (attacker.lvl == 3)
                                        champion.currentAttackSpeed *= (200 / 100);
                                    skill21buffOn = true;
                                }
                            }
                            duration21 = this.time + 10; // 지속시간                 
                        }
                    }
                }
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
                float damege = attacker.currentDamage;
                if (attacker.lvl == 1)
                {                 
                    attacker.GoatSkill(damege);
                }
                else if (attacker.lvl == 2)
                {
                    damege *= 2.5f;
                    attacker.GoatSkill(damege);
                }
                else if (attacker.lvl == 3)
                {
                    damege *= 10;
                    attacker.GoatSkill(damege);
                }
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
        worldCanvasController = GameObject.Find("Scripts").GetComponent<WorldCanvasController>();
    }

    // Update is called once per frame
    void Update()
    {
        // 지속시간 용 타이머
        time += Time.deltaTime;

        // 스킬3('패턴파악' 버프 Off)
        if (time >= duration3)
        {
            if (skill3buffOn)
            {
                for (int x = 0; x < Map.hexMapSizeX; x++)
                {
                    for (int z = 0; z < Map.hexMapSizeZ / 2; z++)
                    {
                        //there is a champion
                        if (combatChampionsArray[x, z] != null)
                        {
                            ChampionController champion = combatChampionsArray[x, z].GetComponent<ChampionController>();
                            if (skill3Attacker.lvl == 1)
                                champion.currentDefence -= 20;
                            else if (skill3Attacker.lvl == 2)
                                champion.currentDefence -= 40;
                            else if (skill3Attacker.lvl == 3)
                                champion.currentDefence -= 80;
                            skill3buffOn = false;
                            skill3Attacker = null;
                            duration3 = -1;
                        }
                    }
                }
            }
        }

        // 스킬5('워낭소리' 버프 Off)
        if (time >= duration5)
        {
            if (skill5buffOn)
            {
                for (int x = 0; x < Map.hexMapSizeX; x++)
                {
                    for (int z = 0; z < Map.hexMapSizeZ / 2; z++)
                    {
                        //there is a champion
                        if (combatChampionsArray[x, z] != null)
                        {
                            ChampionController champion = combatChampionsArray[x, z].GetComponent<ChampionController>();
                            if (skill5Attacker.lvl == 1)
                                champion.currentDefence -= 50;
                            else if (skill5Attacker.lvl == 2)
                                champion.currentDefence -= 80;
                            else if (skill5Attacker.lvl == 3)
                                champion.currentDefence -= 130;
                            skill5buffOn = false;
                            skill5Attacker = null;
                            duration5 = -1;
                        }
                    }
                }
            }
        }

        // 스킬7('착시효과' 버프 Off)
        if (time >= duration7)
        {
            if (skill7buffOn)
            {
                for (int x = 0; x < Map.hexMapSizeX; x++)
                {
                    for (int z = 0; z < Map.hexMapSizeZ / 2; z++)
                    {
                        //there is a champion
                        if (combatChampionsArray[x, z] != null)
                        {
                            ChampionController champion = combatChampionsArray[x, z].GetComponent<ChampionController>();
                            if (skill7Attacker.lvl == 1)
                                champion.currentDefence -= champion.currentDamage * (20 / 100);
                            else if (skill7Attacker.lvl == 2)
                                champion.currentDefence -= champion.currentDamage * (30 / 100);
                            else if (skill7Attacker.lvl == 3)
                                champion.currentDefence -= champion.currentDamage * (40 / 100);
                            skill7buffOn = false;
                            skill7Attacker = null;
                            duration7 = -1;
                        }
                    }
                }
            }
        }

        // 스킬8('카악퉤' 디버프 Off)
        if (time >= duration8)
        {
            if (skill8buffOn)
            {
                if (skill8Attacker.lvl == 1) skill8Target.currentAttackSpeed *= (1 / 0.7f);
                else if (skill8Attacker.lvl == 2) skill8Target.currentAttackSpeed *= (1 / 0.5f);
                else if (skill8Attacker.lvl == 3) skill8Target.currentAttackSpeed *= (1 / 0.3f);
                skill8buffOn = false;
                skill8Attacker = null;
                skill8Target = null;
                duration8 = -1;
            }
        }

        // 스킬11('힘찬연어' 버프 Off)
        if (time >= duration11)
        {
            if (skill11buffOn)
            {
                skill11Attacker.currentAttackSpeed *= (1 / 3);

                skill11buffOn = false;
                skill11Attacker = null;
                duration11 = -1;
            }
        }

        // 스킬14('쪼아대기' 디버프 Off)
        if (time >= duration14)
        {
            if (skill14buffOn)
            {
                if (skill14Attacker.lvl == 1) skill14Target.currentDefence *= 1 / 0.9f;
                else if (skill14Attacker.lvl == 2) skill14Target.currentDefence *= 1 / 0.8f;
                else if (skill14Attacker.lvl == 3) skill14Target.currentDefence *= 1 / 0.7f;

                skill14buffOn = false;
                skill14Attacker = null;
                skill14Target = null;
                duration14 = -1;
            }
        }

        // 스킬16('나를따르라' 버프 Off)
        if (time >= duration16)
        {
            if (skill16buffOn)
            {
                for (int x = 0; x < Map.hexMapSizeX; x++)
                {
                    for (int z = 0; z < Map.hexMapSizeZ / 2; z++)
                    {
                        if (combatChampionsArray[x, z] != null)
                        {
                            ChampionController champion = combatChampionsArray[x, z].GetComponent<ChampionController>();
                            if (skill16Attacker.lvl == 1)
                                champion.currentDefence -= champion.currentDamage * (100 / 120);
                            else if (skill16Attacker.lvl == 2)
                                champion.currentDefence -= champion.currentDamage * (100 / 130);
                            else if (skill16Attacker.lvl == 3)
                                champion.currentDefence -= champion.currentDamage * (100 / 150);
                            skill16buffOn = false;
                            skill16Attacker = null;
                            duration16 = -1;
                        }
                    }
                }
            }
        }

        // 스킬21('빠름빠름' 버프 Off)
        if (time >= duration21)
        {
            if (skill21buffOn)
            {
                for (int x = 0; x < Map.hexMapSizeX; x++)
                {
                    for (int z = 0; z < Map.hexMapSizeZ / 2; z++)
                    {
                        if (combatChampionsArray[x, z] != null)
                        {
                            ChampionController champion = combatChampionsArray[x, z].GetComponent<ChampionController>();
                            if (skill21Attacker.lvl == 1)
                                champion.currentDefence -= champion.currentAttackSpeed * (100 / 150);
                            else if (skill21Attacker.lvl == 2)
                                champion.currentDefence -= champion.currentAttackSpeed * (100 / 175);
                            else if (skill21Attacker.lvl == 3)
                                champion.currentDefence -= champion.currentAttackSpeed * (100 / 200);
                            skill21buffOn = false;
                            skill21Attacker = null;
                            duration21 = -1;
                        }
                    }
                }
            }
        }


    }
}



    
