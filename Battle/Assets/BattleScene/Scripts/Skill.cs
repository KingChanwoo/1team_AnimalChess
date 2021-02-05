using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//  버프 디버프 전투중인 챔피언 검출부터 다시하기.
public class Skill : MonoBehaviour
{
    GamePlayController gamePlayController;
    AIopponent aiOpponent;
    GameData gameData;
    WorldCanvasController worldCanvasController;
    Sound sound;

    public GameObject[,] combatChampionsArray;
    public List<ChampionController> entireChampion;
    public List<ChampionController> enemyChampion;
    public List<ChampionController> playerChampion;




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

    float duration26 = -1;
    public bool skill26buffOn = false;
    ChampionController skill26Attacker;

    float duration27 = -1;
    public bool skill27buffOn = false;
    ChampionController skill27Attacker;

    float duration28 = -1;
    public bool skill28buffOn = false;
    ChampionController skill28Attacker;

    float duration31 = -1;
    public bool skill31buffOn = false;
    ChampionController skill31Attacker;

    float duration32 = -1;
    public bool skill32buffOn = false;
    ChampionController skill32Attacker;

    float duration33 = -1;
    public bool skill33buffOn = false;
    ChampionController skill33Attacker;

    public bool skill37Active = false;
    public float shield = 0;

    float duration39 = -1;
    public bool skill39buffOn = false;
    ChampionController skill39Attacker;

    float duration43 = -1;
    public bool skill43buffOn = false;
    ChampionController skill43Attacker;

    float duration47 = -1;
    public bool skill47buffOn = false;
    ChampionController skill47Attacker;

    float duration52 = -1;
    public bool skill52buffOn = false;
    ChampionController skill52Attacker;

    float duration54 = -1;
    public bool skill54buffOn = false;

    float duration55 = -1;
    public bool skill55buffOn = false;

    float duration58 = -1;
    public bool skill58buffOn = false;
    ChampionController skill58Attacker;

    float duration59 = -1;
    public bool skill59buffOn = false;
    ChampionController skill59Attacker;

    float heal;
    float damage;
    float evasion;
    float attackspeed;
    float buff;
    float buff2;
    float deBuff;

    public void SkillFire(int ID, ChampionController attacker, ChampionController target)
    {
        enemyChampion = aiOpponent.enemyArray;
        playerChampion = gamePlayController.championArray;



        switch (ID)
        {
            case 1:
                attacker.currentHealth += attacker.maxHealth * 0.2f;
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 3);
                break;
            case 2:
                if (attacker.lvl == 1)
                {
                    target.OnGotStun(1);
                }
                else if (attacker.lvl == 2)
                {
                    target.OnGotStun(2);
                }
                else if (attacker.lvl == 3)
                {
                    target.OnGotStun(3);
                }
                attacker.SkillEffect(target.gameObject, target.transform.forward, 2);
                break;
            case 3:
                if (skill3buffOn == false)
                {
                    for (int i = 0; i < playerChampion.Count; i++)
                    {
                        Debug.Log(playerChampion[i]);
                        ChampionController champion = playerChampion[i];
                        skill3Attacker = attacker;

                        if (attacker.lvl == 1)
                            champion.currentDefence += 20;
                        else if (attacker.lvl == 2)
                            champion.currentDefence += 40;
                        else if (attacker.lvl == 3)
                            champion.currentDefence += 80;
                        duration3 = this.time + 10; // 지속시간    
                    }
                    skill3buffOn = true;
                }


                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 2);
                break;
            case 4:
                if (attacker.lvl == 1)
                {
                    damage = attacker.currentDamage * 1.5f;
                    if (target.currentShield < damage)
                    {
                        target.currentShield = 0;
                        target.currentHealth -= damage - target.currentShield;
                    }
                    else target.currentShield -= damage;
                    worldCanvasController.AddDamageText(attacker.transform.position + new Vector3(0, 2.5f, 0), damage, Color.red);
                    target.OnGotStun(2);
                }
                else if (attacker.lvl == 2)
                {

                    damage = attacker.currentDamage * 2;
                    if (target.currentShield < damage)
                    {
                        target.currentShield = 0;
                        target.currentHealth -= damage - target.currentShield;
                    }
                    else target.currentShield -= damage;
                    worldCanvasController.AddDamageText(attacker.transform.position + new Vector3(0, 2.5f, 0), damage, Color.red);
                    target.isStuned = true;
                    target.stunTimer = 3;
                }
                else if (attacker.lvl == 3)
                {
                    damage = attacker.currentDamage * 3;
                    if (target.currentShield < damage)
                    {
                        target.currentShield = 0;
                        target.currentHealth -= damage - target.currentShield;
                    }
                    else target.currentShield -= damage;
                    worldCanvasController.AddDamageText(attacker.transform.position + new Vector3(0, 2.5f, 0), damage, Color.red);
                    target.isStuned = true;
                    target.stunTimer = 4;
                }
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 2);
                break;
            case 5:
                if (skill5buffOn == false)
                {
                    skill5Attacker = attacker;
                    if (attacker.lvl == 1)
                        attacker.currentDefence += 50;
                    else if (attacker.lvl == 2)
                        attacker.currentDefence += 80;
                    else if (attacker.lvl == 3)
                        attacker.currentDefence += 130;
                    skill5buffOn = true;
                }
                duration5 = this.time + 60; // 지속시간   

                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 2);
                break;
            case 6:
                if (attacker.lvl == 1)
                {
                    damage = attacker.currentDamage * 2;
                    if (target.currentShield < damage)
                    {
                        target.currentShield = 0;
                        target.currentHealth -= damage - target.currentShield;
                    }
                    else target.currentShield -= damage;
                    worldCanvasController.AddDamageText(attacker.transform.position + new Vector3(0, 2.5f, 0), damage, Color.red);
                }
                else if (attacker.lvl == 2)
                {
                    damage = attacker.currentDamage * 2.5f;
                    if (target.currentShield < damage)
                    {
                        target.currentShield = 0;
                        target.currentHealth -= damage - target.currentShield;
                    }
                    else target.currentShield -= damage;
                    worldCanvasController.AddDamageText(attacker.transform.position + new Vector3(0, 2.5f, 0), damage, Color.red);
                }
                else if (attacker.lvl == 3)
                {
                    damage = attacker.currentDamage * 4;
                    if (target.currentShield < damage)
                    {
                        target.currentShield = 0;
                        target.currentHealth -= damage - target.currentShield;
                    }
                    else target.currentShield -= damage;
                    worldCanvasController.AddDamageText(attacker.transform.position + new Vector3(0, 2.5f, 0), damage, Color.red);
                }
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 2);
                break;
            case 7:
                if (skill7buffOn == false)
                {
                    for (int i = 0; i < playerChampion.Count; i++)
                    {
                        Debug.Log(playerChampion[i]);
                        ChampionController champion = playerChampion[i];

                        skill7Attacker = attacker;

                        if (attacker.lvl == 1)
                        {
                            buff = champion.currentDefence * 0.2f;
                            champion.currentDefence += buff;
                        }

                        else if (attacker.lvl == 2)
                        {
                            buff = champion.currentDefence * 0.3f;
                            champion.currentDefence += buff;
                        }

                        else if (attacker.lvl == 3)
                        {
                            buff = champion.currentDefence * 0.4f;
                            champion.currentDefence += buff;
                        }

                        duration7 = this.time + 20; // 지속시간   
                    }
                    skill7buffOn = true;
                }

                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 2);
                break;
            case 8:
                if (skill8buffOn == false)
                {
                    skill8Attacker = attacker;
                    skill8Target = target;
                    if (attacker.lvl == 1)
                    {
                        deBuff = target.currentAttackSpeed * 0.3f;
                        {
                            deBuff = target.currentAttackSpeed * 0.3f;
                            target.currentAttackSpeed -= deBuff;
                        }
                    }
                    else if (attacker.lvl == 2)
                    {
                        deBuff = target.currentAttackSpeed * 0.5f;
                        target.currentAttackSpeed -= deBuff;
                    }
                    else if (attacker.lvl == 3)
                    {
                        deBuff = target.currentAttackSpeed * 0.7f;
                        target.currentAttackSpeed -= deBuff;
                    }
                    skill8buffOn = true;
                    duration8 = this.time + 10; // 지속시간
                }
                attacker.SkillEffect(target.gameObject, attacker.transform.forward, 2);
                break;
            case 9:
                if (attacker.lvl == 1) attacker.currentShield = 400;
                else if (attacker.lvl == 2) attacker.currentShield = 800;
                else if (attacker.lvl == 3) attacker.currentShield = 1500;
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 2);
                break;
            case 10:
                if (attacker.lvl == 1)
                {
                    damage = attacker.currentDamage * 2;
                    if (target.currentShield < damage)
                    {
                        target.currentShield = 0;
                        target.currentHealth -= damage - target.currentShield;
                    }
                    else target.currentShield -= damage;
                    worldCanvasController.AddDamageText(attacker.transform.position + new Vector3(0, 2.5f, 0), damage, Color.red);
                }
                else if (attacker.lvl == 2)
                {
                    damage = attacker.currentDamage * 2.5f;
                    if (target.currentShield < damage)
                    {
                        target.currentShield = 0;
                        target.currentHealth -= damage - target.currentShield;
                    }
                    else target.currentShield -= damage;
                    worldCanvasController.AddDamageText(attacker.transform.position + new Vector3(0, 2.5f, 0), damage, Color.red);
                }
                else if (attacker.lvl == 3)
                {
                    damage = attacker.currentDamage * 3;
                    if (target.currentShield < damage)
                    {
                        target.currentShield = 0;
                        target.currentHealth -= damage - target.currentShield;
                    }
                    else target.currentShield -= damage;
                    worldCanvasController.AddDamageText(attacker.transform.position + new Vector3(0, 2.5f, 0), damage, Color.red);
                }
                attacker.SkillEffect(target.gameObject, target.transform.forward, 2);
                break;
            case 11:
                if (skill11buffOn == false)
                {
                    attacker.currentAttackSpeed *= 3;
                    duration11 = this.time + 5; // 지속시간
                }
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 2);
                break;
            case 12:
                if (attacker.lvl == 1)
                {
                    attacker.SilenceSkill(2);
                }
                else if (attacker.lvl == 2)
                {
                    attacker.SilenceSkill(4);
                }
                else if (attacker.lvl == 3)
                {
                    attacker.SilenceSkill(5);
                }
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 2);
                break;
            case 13:
                if (attacker.lvl == 1)
                {
                    attacker.OctopusSkill(2);
                }
                else if (attacker.lvl == 2)
                {
                    attacker.OctopusSkill(4);
                }
                else if (attacker.lvl == 3)
                {
                    attacker.OctopusSkill(6);
                }
                Vector3 dir = attacker.transform.forward - target.transform.position;
                attacker.SkillEffect(attacker.gameObject, dir, 2);
                break;
            case 14:
                skill14Attacker = attacker;
                skill14Target = target;
                damage = attacker.currentDamage * 1.5f;
                if (target.currentShield < damage)
                {
                    target.currentShield = 0;
                    target.currentHealth -= damage - target.currentShield;
                }
                else target.currentShield -= damage;

                worldCanvasController.AddDamageText(attacker.transform.position + new Vector3(0, 3, 0), damage, Color.red);

                if (skill14buffOn == false)
                {
                    if (attacker.lvl == 1)
                    {
                        deBuff = target.currentDefence * 0.1f;
                        target.currentDefence -= deBuff;
                    }

                    else if (attacker.lvl == 2)
                    {
                        deBuff = target.currentDefence * 0.2f;
                        target.currentDefence -= deBuff;
                    }

                    else if (attacker.lvl == 3)
                    {
                        deBuff = target.currentDefence * 0.3f;
                        target.currentDefence -= deBuff;
                    }

                    duration14 = this.time + 10; // 지속시간
                }
                attacker.SkillEffect(target.gameObject, target.transform.forward, 1);
                break;
            case 15:
                if (attacker.isSalamanderDead == true && attacker.isSalamanderSkillOn == true)
                {
                    if (attacker.lvl == 1)
                    {
                        attacker.SalamanderSkill(2);
                    }
                    else if (attacker.lvl == 2)
                    {
                        attacker.SalamanderSkill(4);
                    }
                    else if (attacker.lvl == 3)
                    {
                        attacker.SalamanderSkill(7);
                    }
                }
                else
                {
                    attacker.isSalamanderSkillOn = true;
                }

                break;
            case 16:
                if (skill16buffOn == false)
                {
                    for (int i = 0; i < playerChampion.Count; i++)
                    {
                        ChampionController champion = playerChampion[i];
                        skill16Attacker = attacker;
                        if (attacker.lvl == 1)
                        {
                            buff = champion.currentAttackSpeed * 0.2f;
                            champion.currentAttackSpeed += buff;
                        }

                        else if (attacker.lvl == 2)
                        {
                            buff = champion.currentAttackSpeed * 0.3f;
                            champion.currentAttackSpeed += buff;
                        }
                        else if (attacker.lvl == 3)
                        {
                            buff = champion.currentAttackSpeed * 0.5f;
                            champion.currentAttackSpeed += buff;
                        }
                        duration16 = this.time + 10; // 지속시간  
                    }
                    skill16buffOn = true;
                }
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 2);
                break;
            case 17:
                if (attacker.lvl == 1)
                {
                    heal = attacker.currentDamage;
                    attacker.SheepSkill(heal);
                }
                else if (attacker.lvl == 2)
                {
                    heal = attacker.currentDamage * 1.5f;
                    attacker.SheepSkill(heal);
                }
                else if (attacker.lvl == 3)
                {
                    heal = attacker.currentDamage * 3;
                    attacker.SheepSkill(heal);
                }
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 2);
                break;
            case 18:
                if (attacker.lvl == 1)
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
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 2);
                break;
            case 19:
                if (attacker.lvl == 1)
                {
                    damage = attacker.currentDamage * 1.5f;
                    if (target.currentShield < damage)
                    {
                        target.currentShield = 0;
                        target.currentHealth -= damage - target.currentShield;
                    }
                    else target.currentShield -= damage;
                    worldCanvasController.AddDamageText(attacker.transform.position + new Vector3(0, 2.5f, 0), damage, Color.red);
                    target.OnGotStun(2);
                }
                else if (attacker.lvl == 2)
                {
                    damage = attacker.currentDamage * 2;
                    if (target.currentShield < damage)
                    {
                        target.currentShield = 0;
                        target.currentHealth -= damage - target.currentShield;
                    }
                    else target.currentShield -= damage;
                    worldCanvasController.AddDamageText(attacker.transform.position + new Vector3(0, 2.5f, 0), damage, Color.red);
                    target.OnGotStun(2);
                }
                else if (attacker.lvl == 3)
                {
                    damage = attacker.currentDamage * 3;
                    if (target.currentShield < damage)
                    {
                        target.currentShield = 0;
                        target.currentHealth -= damage - target.currentShield;
                    }
                    else target.currentShield -= damage;
                    worldCanvasController.AddDamageText(attacker.transform.position + new Vector3(0, 2.5f, 0), damage, Color.red);
                    target.OnGotStun(2);
                }
                attacker.SkillEffect(target.gameObject, target.transform.forward, 2);
                break;
            case 20:
                attacker.ElephantSkill(5);
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 2);
                break;
            case 21:
                if (skill21buffOn == false)
                {
                    for (int i = 0; i < playerChampion.Count; i++)
                    {
                        ChampionController champion = playerChampion[i];
                        skill21Attacker = attacker;
                        if (attacker.lvl == 1)
                        {
                            buff = champion.currentAttackSpeed * 0.5f;
                            champion.currentAttackSpeed += buff;

                        }
                        else if (attacker.lvl == 2)
                        {
                            buff = champion.currentAttackSpeed * 0.75f;
                            champion.currentAttackSpeed += buff;

                        }
                        else if (attacker.lvl == 3)
                        {
                            buff = champion.currentAttackSpeed * 1f;
                            champion.currentAttackSpeed += buff;
                        }
                        duration21 = this.time + 5; // 지속시간  
                    }
                    skill21buffOn = true;
                }
                attacker.SkillEffect(target.gameObject, target.transform.forward, 2);
                break;
            case 22:
                if (attacker.lvl == 1)
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
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 2);
                break;
            case 23:
                for (int i = 0; i < enemyChampion.Count; i++)
                {
                    ChampionController champion = enemyChampion[i];
                    if (attacker.lvl == 1)
                    {
                        deBuff = champion.currentDamage * 0.03f;
                        champion.currentDamage -= deBuff;
                    }
                    else if (attacker.lvl == 2)
                    {
                        deBuff = champion.currentDamage * 0.05f;
                        champion.currentDamage -= deBuff;
                    }
                    else if (attacker.lvl == 3)
                    {
                        deBuff = champion.currentDamage * 0.08f;
                        champion.currentDamage -= deBuff;
                    }
                }
                attacker.SkillEffect(target.gameObject, target.transform.forward, 2);
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
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 2);
                break;
            case 25:
                if (skill25buffOn == false)
                {
                    for (int i = 0; i < playerChampion.Count; i++)
                    {
                        ChampionController champion = playerChampion[i];
                        skill25Attacker = attacker;

                        if (attacker.lvl == 1)
                        {
                            buff = champion.currentDamage * 0.1f;
                            champion.currentDamage += buff;
                        }
                        else if (attacker.lvl == 2)
                        {
                            buff = champion.currentDamage * 0.2f;
                            champion.currentDamage += buff;
                        }
                        else if (attacker.lvl == 3)
                        {
                            buff = champion.currentDamage * 0.3f;
                            champion.currentDamage += buff;
                        }
                        duration25 = this.time + 20; // 지속시간 
                    }
                    skill25buffOn = true;
                    attacker.currentHealth *= 0.5f;
                }

                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 2);
                break;
            case 26:
                skill26Attacker = attacker;
                if (skill26buffOn == false)
                {
                    if (attacker.lvl == 1)
                    {
                        buff = attacker.currentDamage * 0.3f;
                        attacker.currentDamage += buff;
                        buff2 = attacker.currentAttackSpeed * 0.3f;
                        attacker.currentAttackSpeed += buff2;
                    }
                    else if (attacker.lvl == 2)
                    {
                        buff = attacker.currentDamage * 0.5f;
                        attacker.currentDamage += buff;
                        buff2 = attacker.currentAttackSpeed * 0.5f;
                        attacker.currentAttackSpeed += buff2;
                    }
                    else if (attacker.lvl == 3)
                    {
                        buff = attacker.currentDamage * 0.7f;
                        attacker.currentDamage += buff;
                        buff2 = attacker.currentAttackSpeed * 0.7f;
                        attacker.currentAttackSpeed += buff2;
                    }
                    skill26buffOn = true;
                }
                duration26 = this.time + 10; // 지속시간  
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 2);
                break;
            case 27:
                if (skill27buffOn == false)
                {
                    if (attacker.lvl == 1)
                    {
                        buff = attacker.currentDefence * 0.5f;
                        attacker.currentDamage += buff;

                    }
                    else if (attacker.lvl == 2)
                    {
                        buff = attacker.currentDefence * 1f;
                        attacker.currentDamage += buff;
                    }
                    else if (attacker.lvl == 3)
                    {
                        buff = attacker.currentDefence * 1.5f;
                        attacker.currentDamage += buff;
                    }
                    skill27buffOn = true;
                }
                duration27 = this.time + 10; // 지속시간  
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 2);
                break;
            case 28:
                skill28Attacker = attacker;
                if (attacker.lvl == 1)
                    attacker.currentHealth += attacker.maxHealth * 0.1f;
                else if (attacker.lvl == 2)
                    attacker.currentHealth += attacker.maxHealth * 0.2f;
                else if (attacker.lvl == 3)
                    attacker.currentHealth += attacker.maxHealth * 0.35f;
                if (attacker.currentHealth >= attacker.maxHealth)
                    attacker.currentHealth = attacker.maxHealth;
                if (skill28buffOn == false)
                {
                    buff = attacker.currentAttackSpeed;
                    attacker.currentAttackSpeed += buff;
                    skill28buffOn = true;
                }
                duration28 = this.time + 3; // 지속시간
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 2);
                break;
            case 29:
                if (attacker.lvl == 1)
                {
                    damage = attacker.currentDamage * 2;
                    if (target.currentShield < damage)
                    {
                        target.currentShield = 0;
                        target.currentHealth -= damage - target.currentShield;
                    }
                    else target.currentShield -= damage;
                    worldCanvasController.AddDamageText(attacker.transform.position + new Vector3(0, 2.5f, 0), damage, Color.red);
                    target.OnGotStun(5);
                }
                else if (attacker.lvl == 2)
                {
                    damage = attacker.currentDamage * 3;
                    if (target.currentShield < damage)
                    {
                        target.currentShield = 0;
                        target.currentHealth -= damage - target.currentShield;
                    }
                    else target.currentShield -= damage;
                    worldCanvasController.AddDamageText(attacker.transform.position + new Vector3(0, 2.5f, 0), damage, Color.red);
                    target.OnGotStun(5);
                }
                else if (attacker.lvl == 3)
                {
                    damage = attacker.currentDamage * 5;
                    if (target.currentShield < damage)
                    {
                        target.currentShield = 0;
                        target.currentHealth -= damage - target.currentShield;
                    }
                    else target.currentShield -= damage;
                    worldCanvasController.AddDamageText(attacker.transform.position + new Vector3(0, 2.5f, 0), damage, Color.red);
                    target.OnGotStun(5);
                }
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 2);
                break;
            case 30:
                if (attacker.isRatDead == true && attacker.isRatSkillOn == true)
                {
                    if (attacker.lvl == 1)
                    {
                        attacker.RatSkill(5);
                    }
                    else if (attacker.lvl == 2)
                    {
                        attacker.RatSkill(8);
                    }
                    else if (attacker.lvl == 3)
                    {
                        attacker.RatSkill(12);
                    }
                }
                else
                {
                    attacker.isRatSkillOn = true;
                }
                break;
            case 31:
                skill31Attacker = attacker;
                if (skill31buffOn == false)
                {
                    if (attacker.lvl == 1)
                    {
                        buff = attacker.currentDamage;
                        attacker.currentDamage += buff;
                    }
                    else if (attacker.lvl == 2)
                    {
                        buff = attacker.currentDamage * 2;
                        attacker.currentDamage += buff;
                    }
                    else if (attacker.lvl == 3)
                    {
                        buff = attacker.currentDamage * 3;
                        attacker.currentDamage += buff;
                    }
                    skill31buffOn = true;
                }
                duration31 = this.time + 5; // 지속시간
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 2);
                break;
            case 32:
                skill32Attacker = attacker;
                if (skill32buffOn == false)
                {
                    attacker.currentCritical = 100;
                    if (attacker.lvl == 1)
                    {
                        buff = attacker.currentAttackSpeed;
                        attacker.currentAttackSpeed += buff;
                    }

                    else if (attacker.lvl == 2)
                    {
                        buff = attacker.currentAttackSpeed * 1.5f;
                        attacker.currentAttackSpeed += buff;
                    }
                    else if (attacker.lvl == 3)
                    {
                        buff = attacker.currentAttackSpeed * 2f;
                        attacker.currentAttackSpeed += buff;
                    }
                    skill32buffOn = true;
                }
                duration32 = this.time + 10; // 지속시간
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 2);
                break;
            case 33:
                if (attacker.lvl == 1) target.OnGotStun(2);
                else if (attacker.lvl == 2) target.OnGotStun(3);
                else if (attacker.lvl == 3) target.OnGotStun(5);

                skill33Attacker = attacker;
                if (skill33buffOn == false)
                {
                    buff = attacker.currentAttackSpeed * 3;
                    attacker.currentAttackSpeed += buff;
                    skill33buffOn = true;
                }
                duration33 = this.time + 3; // 지속시간
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 2);
                break;
            case 34:
                if (attacker.lvl == 1)
                {
                    attacker.ScorpionSkill(2);
                }
                else if (attacker.lvl == 2)
                {
                    attacker.ScorpionSkill(4);
                }
                else if (attacker.lvl == 3)
                {
                    attacker.ScorpionSkill(8);
                }
                break;
            case 35:
                break;
            case 36:
                // 패시브로 대체
                break;
            case 37:
                attacker.currentShield = 0;
                shield = attacker.snailStack * (attacker.maxHealth * 0.05f);
                Debug.Log(shield);
                Debug.Log(attacker.snailStack);
                attacker.currentShield += shield;
                if (skill37Active == false)
                {
                    Debug.Log("쉴드 떳냐? " + attacker.currentShield);
                    skill37Active = true;
                }

                // 쉴드데미지 영역은 ChampionController 863cs~
                break;
            case 38:
                if (attacker.lvl == 1)
                {
                    damage = attacker.currentDamage * 2f;
                    if (target.currentHealth < damage)
                    {
                        attacker.isBoarskill = true;
                    }
                    target.currentHealth -= damage;
                    worldCanvasController.AddDamageText(attacker.transform.position + new Vector3(0, 2.5f, 0), damage, Color.red);
                    target.OnGotStun(3);

                }
                else if (attacker.lvl == 2)
                {
                    damage = attacker.currentDamage * 4f;
                    if (target.currentHealth < damage)
                    {
                        attacker.isBoarskill = true;
                    }
                    target.currentHealth -= damage;
                    worldCanvasController.AddDamageText(attacker.transform.position + new Vector3(0, 2.5f, 0), damage, Color.red);
                    target.OnGotStun(3);
                }
                else if (attacker.lvl == 3)
                {
                    damage = attacker.currentDamage * 8;
                    if (target.currentHealth < damage)
                    {
                        attacker.isBoarskill = true;
                    }
                    target.currentHealth -= damage;
                    worldCanvasController.AddDamageText(attacker.transform.position + new Vector3(0, 2.5f, 0), damage, Color.red);
                    target.OnGotStun(3);
                }
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 0.5f);
                attacker.SkillEffect2(target.gameObject, attacker.transform.forward, 1.5f);
                break;
            case 39:
                if (skill39buffOn == false)
                {
                    for (int i = 0; i < playerChampion.Count; i++)
                    {
                        ChampionController champion = playerChampion[i];
                        skill39Attacker = attacker;

                        if (attacker.lvl == 1)
                        {
                            damage = champion.currentDamage * 0.2f;
                            champion.currentDamage += damage;
                        }
                        if (attacker.lvl == 2)
                        {
                            damage = champion.currentDamage * 0.3f;
                            champion.currentDamage += damage;
                        }
                        if (attacker.lvl == 3)
                        {
                            damage = champion.currentDamage * 0.5f;
                            champion.currentDamage += damage;
                        }
                        duration39 = this.time + 5; // 지속시간
                    }
                    skill39buffOn = true;
                }
                break;
            case 40:
                if (attacker.lvl == 1)
                {
                    attacker.ComodoSkill(5);
                }
                else if (attacker.lvl == 2)
                {
                    attacker.ComodoSkill(8);
                }
                else if (attacker.lvl == 3)
                {
                    attacker.ComodoSkill(10);
                }
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 1f);
                break;
            case 41:
                attacker.GoatskillOn();
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 5);
                break;
            case 42:
                // 스킬업음
                break;
            case 43:
                if (skill43buffOn == false)
                {
                    skill43Attacker = attacker;
                    attackspeed = attacker.currentAttackSpeed;
                    attacker.currentAttackSpeed += attackspeed;
                    skill43buffOn = true;
                    duration43 = this.time + 3;
                }
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 1f);
                break;
            case 44:
                Debug.Log("돌격병 소환");
                target.currentHealth -= attacker.currentDamage * 3f;
                worldCanvasController.AddDamageText(attacker.transform.position + new Vector3(0, 2.5f, 0), damage, Color.red);

                aiOpponent.EnemySummon(123, 100);
                aiOpponent.EnemySummon(123, 100);

                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 2f);
                break;
            case 45:
                Debug.Log("포병 소환");
                aiOpponent.EnemySummon(124, 100);

                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 2f);
                break;
            case 46:
                attacker.currentShield = 500;
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 1f);
                break;
            case 47:
                if (skill47buffOn == false)
                {
                    skill47Attacker = attacker;
                    evasion = attacker.currentEvasion * 0.4f;
                    attacker.currentEvasion += evasion;
                    skill47buffOn = true;
                    duration47 = this.time + 5;
                }
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 1f);
                break;
            case 48:
                // 패시브 스킬
                break;
            case 49:
                // 스킬 없음
                break;
            case 50:
                damage = attacker.currentDamage * 3f;
                for (int x = 0; x < Map.hexMapSizeX; x++)
                {
                    for (int z = 0; z < Map.hexMapSizeZ / 2; z++)
                    {
                        if (gamePlayController.gridChampionsArray[x, z] != null)
                        {
                            ChampionController championController = gamePlayController.gridChampionsArray[x, z].GetComponent<ChampionController>();
                            if (target.currentShield < damage)
                            {
                                target.currentShield = 0;
                                target.currentHealth -= damage - target.currentShield;
                            }
                            else target.currentShield -= damage;
                            championController.OnGotStun(1);
                        }
                    }
                }
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 1f);
                break;
            case 51:
                Debug.Log("현대병사 소환");
                for (int i = 0; i < aiOpponent.enemyArray.Count; i++)
                {
                    ChampionController championController = aiOpponent.enemyArray[i].GetComponent<ChampionController>();
                    championController.currentShield += 300;
                }
                aiOpponent.EnemySummon(130, 100);
                aiOpponent.EnemySummon(130, 100);

                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 2f);
                break;
            case 52:
                if (skill52buffOn == false)
                {
                    skill52Attacker = attacker;
                    evasion = attacker.currentEvasion;
                    attacker.currentEvasion = 70;
                }
                damage = attacker.currentDamage * 2f;
                for (int x = 0; x < Map.hexMapSizeX; x++)
                {
                    for (int z = 0; z < Map.hexMapSizeZ / 2; z++)
                    {
                        if (gamePlayController.gridChampionsArray[x, z] != null)
                        {
                            ChampionController championController = gamePlayController.gridChampionsArray[x, z].GetComponent<ChampionController>();
                            if (target.currentShield < damage)
                            {
                                target.currentShield = 0;
                                target.currentHealth -= damage - target.currentShield;
                            }
                            else target.currentShield -= damage;
                            championController.OnGotStun(2);
                        }
                    }
                }
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 1f);
                break;
            case 53:
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
                                float distance = Vector3.Distance(this.transform.position, aiOpponent.gridChampionsArray[x, z].transform.position);
                                //if new this champion is closer then best distance
                                if (distance < 9)
                                {
                                    championController.OnGotStun(3);
                                }
                            }
                        }
                    }
                }
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 1f);
                break;
            case 54:
                if (skill54buffOn == false)
                {
                    for (int i = 0; i < aiOpponent.enemyArray.Count; i++)
                    {
                        ChampionController championController = aiOpponent.enemyArray[i].GetComponent<ChampionController>();
                        buff = championController.currentDefence * 0.3f;
                        championController.currentDefence += buff;
                    }
                    duration54 = this.time + 10;
                }
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 2);
                break;
            case 55:
                if (skill55buffOn == false)
                {
                    for (int x = 0; x < Map.hexMapSizeX; x++)
                    {
                        for (int z = 0; z < Map.hexMapSizeZ / 2; z++)
                        {
                            if (gamePlayController.gridChampionsArray[x, z] != null)
                            {
                                ChampionController championController = gamePlayController.gridChampionsArray[x, z].GetComponent<ChampionController>();
                                deBuff = championController.currentDamage * 0.3f;
                                championController.currentDamage -= deBuff;
                            }
                        }
                    }
                    for (int i = 0; i < aiOpponent.enemyArray.Count; i++)
                    {
                        ChampionController championController = aiOpponent.enemyArray[i].GetComponent<ChampionController>();
                        buff = championController.currentDefence * 0.5f;
                        championController.currentDefence += buff;
                    }
                    duration55 = this.time + 10;
                }
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 2);
                break;
            case 56:
                // 스킬없음
                break;
            case 57:
                buff = target.currentMana;
                target.currentMana = 0;
                attacker.currentShield += buff * 6;
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 2);
                break;
            case 58:
                if (skill58buffOn == false)
                {
                    skill58Attacker = attacker;
                    evasion = attacker.currentEvasion;
                    attacker.currentEvasion = 90;
                    duration58 = this.time + 5;
                }
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 2);
                break;
            case 59:
                if (skill59buffOn == false)
                {
                    skill59Attacker = attacker;
                    damage = attacker.currentDamage;
                    attackspeed = attacker.currentAttackSpeed;
                    attacker.currentDamage += damage;
                    attacker.currentAttackSpeed += attackspeed;
                    duration59 = this.time + 10;
                }
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 2);
                break;
            case 60:
                damage = attacker.currentDamage * 3f;
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
                                float distance = Vector3.Distance(this.transform.position, aiOpponent.gridChampionsArray[x, z].transform.position);
                                //if new this champion is closer then best distance
                                if (distance < 6)
                                {
                                    championController.currentHealth -= damage;
                                    championController.OnGotStun(1);

                                }
                            }
                        }
                    }
                }
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 1f);
                break;
            case 61:
                attacker.Enemy61SkillOn();
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 6);
                break;
        }
    }





    // Start is called before the first frame update
    void Start()
    {
        gamePlayController = GameObject.Find("Scripts").GetComponent<GamePlayController>();
        aiOpponent = GameObject.Find("Scripts").GetComponent<AIopponent>();
        gameData = GameObject.Find("Scripts").GetComponent<GameData>();
        worldCanvasController = GameObject.Find("Scripts").GetComponent<WorldCanvasController>();
        sound = GameObject.Find("Scripts").GetComponent<Sound>();


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
                for (int i = 0; i < playerChampion.Count; i++)
                {
                    ChampionController champion = playerChampion[i];
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

        // 스킬5('워낭소리' 버프 Off)
        if (time >= duration5)
        {
            if (skill5buffOn)
            {
                if (skill5Attacker.lvl == 1)
                    skill5Attacker.currentDefence -= 50;
                else if (skill5Attacker.lvl == 2)
                    skill5Attacker.currentDefence -= 80;
                else if (skill5Attacker.lvl == 3)
                    skill5Attacker.currentDefence -= 130;
                skill5buffOn = false;
                skill5Attacker = null;
                duration5 = -1;
            }
        }

        // 스킬7('착시효과' 버프 Off)
        if (time >= duration7)
        {
            if (skill7buffOn)
            {
                for (int i = 0; i < playerChampion.Count; i++)
                {
                    ChampionController champion = playerChampion[i];
                    if (skill7Attacker.lvl == 1)
                        champion.currentDefence -= buff;
                    else if (skill7Attacker.lvl == 2)
                        champion.currentDefence -= buff;
                    else if (skill7Attacker.lvl == 3)
                        champion.currentDefence -= buff;
                    skill7Attacker = null;
                    duration7 = -1;
                }
            }
        }

        // 스킬8('카악퉤' 디버프 Off)
        if (time >= duration8)
        {
            if (skill8buffOn)
            {
                if (skill8Attacker.lvl == 1) skill8Target.currentAttackSpeed += deBuff;
                else if (skill8Attacker.lvl == 2) skill8Target.currentAttackSpeed += deBuff;
                else if (skill8Attacker.lvl == 3) skill8Target.currentAttackSpeed += deBuff;
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
                skill11Attacker.currentAttackSpeed *= 0.33f;

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
                if (skill14Attacker.lvl == 1) skill14Target.currentDefence += deBuff;
                else if (skill14Attacker.lvl == 2) skill14Target.currentDefence += deBuff;
                else if (skill14Attacker.lvl == 3) skill14Target.currentDefence += deBuff;

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
                for (int i = 0; i < playerChampion.Count; i++)
                {
                    ChampionController champion = playerChampion[i];
                    if (skill16Attacker.lvl == 1)
                        champion.currentAttackSpeed -= buff;
                    else if (skill16Attacker.lvl == 2)
                        champion.currentAttackSpeed -= buff;
                    else if (skill16Attacker.lvl == 3)
                        champion.currentAttackSpeed -= buff;
                    skill16buffOn = false;
                    skill16Attacker = null;
                    duration16 = -1;
                }
            }
        }

        // 스킬21('빠름빠름' 버프 Off)
        if (time >= duration21)
        {
            if (skill21buffOn)
            {
                for (int i = 0; i < playerChampion.Count; i++)
                {
                    ChampionController champion = playerChampion[i];
                    if (skill21Attacker.lvl == 1)
                        champion.currentAttackSpeed -= buff;
                    else if (skill21Attacker.lvl == 2)
                        champion.currentAttackSpeed -= buff;
                    else if (skill21Attacker.lvl == 3)
                        champion.currentAttackSpeed -= buff;
                    skill21buffOn = false;
                    skill21Attacker = null;
                    duration21 = -1;
                }
            }
        }

        // 스킬25('희생' 버프 Off)
        if (time >= duration25)
        {
            if (skill25buffOn)
            {
                for (int i = 0; i < playerChampion.Count; i++)
                {
                    ChampionController champion = playerChampion[i];
                    if (skill25Attacker.lvl == 1)
                        champion.currentDamage -= buff;
                    else if (skill25Attacker.lvl == 2)
                        champion.currentDamage -= buff;
                    else if (skill25Attacker.lvl == 3)
                        champion.currentDamage -= buff;
                    skill25buffOn = false;
                    skill25Attacker = null;
                    duration25 = -1;
                }
            }
        }

        // 스킬26('굶주림' 버프 Off)
        if (time >= duration26)
        {
            if (skill26buffOn)
            {

                if (skill26Attacker.lvl == 1)
                {
                    skill26Attacker.currentDamage -= buff;
                    skill26Attacker.currentAttackSpeed -= buff2;
                }
                else if (skill26Attacker.lvl == 2)
                {
                    skill26Attacker.currentDamage -= buff;
                    skill26Attacker.currentAttackSpeed -= buff2;
                }
                else if (skill26Attacker.lvl == 3)
                {
                    skill26Attacker.currentDamage -= buff;
                    skill26Attacker.currentAttackSpeed -= buff2;
                }
                skill26buffOn = false;
                skill26Attacker = null;
                duration26 = -1;

            }
        }

        //  스킬27('게거품' 버프 off)
        if (time >= duration27)
        {
            if (skill27buffOn)
            {
                for (int i = 0; i < playerChampion.Count; i++)
                {
                    ChampionController champion = playerChampion[i];
                    if (skill27Attacker.lvl == 1)
                        champion.currentDefence -= buff;
                    else if (skill27Attacker.lvl == 2)
                        champion.currentDefence -= buff;
                    else if (skill27Attacker.lvl == 3)
                        champion.currentDefence -= buff;
                    skill27buffOn = false;
                    skill27Attacker = null;
                    duration27 = -1;
                }
            }
        }

        //  스킬28('탈피' 버프 off)
        if (time >= duration28)
        {
            if (skill28buffOn)
            {
                skill28Attacker.currentAttackSpeed -= buff;
                skill28buffOn = false;
                skill28Attacker = null;
                duration28 = -1;
            }
        }

        //  스킬31('왕의분노' 버프 off)
        if (time >= duration31)
        {
            if (skill31buffOn)
            {
                if (skill31Attacker.lvl == 1)
                    skill31Attacker.currentDamage -= buff;
                else if (skill31Attacker.lvl == 2)
                    skill31Attacker.currentDamage -= buff;
                else if (skill31Attacker.lvl == 3)
                    skill31Attacker.currentDamage -= buff;
                skill31buffOn = false;
                skill31Attacker = null;
                duration28 = -1;
            }
        }

        //  스킬32('치명적인뿔' 버프 off)
        if (time >= duration32)
        {
            if (skill32buffOn)
            {
                skill32Attacker.currentCritical = 25;
                if (skill32Attacker.lvl == 1)
                    skill32Attacker.currentAttackSpeed -= buff;
                else if (skill32Attacker.lvl == 2)
                    skill32Attacker.currentAttackSpeed -= buff;
                else if (skill32Attacker.lvl == 3)
                    skill32Attacker.currentAttackSpeed -= buff;
                skill32buffOn = false;
                skill32Attacker = null;
                duration32 = -1;
            }
        }

        //  스킬33('저리비켜' 버프 off)
        if (time >= duration33)
        {
            if (skill33buffOn)
            {
                skill33Attacker.currentAttackSpeed -= buff;
                skill33buffOn = false;
                skill33Attacker = null;
                duration33 = -1;
            }
        }

        //  스킬39('폭식' 버프 off)
        if (time >= duration39)
        {
            if (skill39buffOn)
            {
                for (int i = 0; i < playerChampion.Count; i++)
                {
                    ChampionController champion = playerChampion[i];
                    champion.currentDamage -= damage;
                    skill39buffOn = false;
                    skill39Attacker = null;
                    duration39 = -1;
                }
            }
        }
        // 포병 자기 자신 공속버프
        if (time >= duration43)
        {
            if (skill43buffOn)
            {
                skill43Attacker.currentAttackSpeed -= attackspeed;
                skill43buffOn = false;
                duration43 = -1;
            }
        }

        // 스핏파이어 자기 자신 회피버프
        if (time >= duration47)
        {
            if (skill47buffOn)
            {
                skill47Attacker.currentEvasion -= evasion;
                skill47buffOn = false;
                duration47 = -1;
            }
        }

        if (time >= duration52)
        {
            if (skill52buffOn)
            {
                skill52Attacker.currentEvasion = evasion;
                skill52buffOn = false;
                duration52 = -1;
            }
        }

        // 호위함 적군전체 방어력버프
        if (time >= duration54)
        {
            if (skill54buffOn)
            {
                for (int i = 0; i < aiOpponent.enemyArray.Count; i++)
                {
                    aiOpponent.enemyArray[i].currentDefence -= buff;
                }
                skill54buffOn = false;
                duration54 = -1;
            }
        }

        if (time >= duration55)
        {
            if (skill55buffOn)
            {
                for (int x = 0; x < Map.hexMapSizeX; x++)
                {
                    for (int z = 0; z < Map.hexMapSizeZ / 2; z++)
                    {
                        if (gamePlayController.gridChampionsArray[x, z] != null)
                        {
                            ChampionController championController = gamePlayController.gridChampionsArray[x, z].GetComponent<ChampionController>();
                            deBuff = championController.currentDamage * 0.3f;
                            championController.currentDamage += deBuff;
                        }
                    }
                }

                for (int i = 0; i < aiOpponent.enemyArray.Count; i++)
                {
                    aiOpponent.enemyArray[i].currentDefence -= buff;
                }
                skill55buffOn = false;
                duration55 = -1;
            }
        }

        if (time >= duration58)
        {
            if (skill58buffOn)
            {
                skill58Attacker.currentEvasion = evasion;
                skill58buffOn = false;
                duration58 = -1;
            }
        }

        if (time >= duration59)
        {
            if (skill59buffOn)
            {
                skill59Attacker.currentDamage -= damage;
                skill59Attacker.currentAttackSpeed -= attackspeed;
                skill59buffOn = false;
                duration59 = -1;
            }
        }
    }
}




