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
                    target.isStuned = true;
                    target.stunTimer = 1;
                }
                else if (attacker.lvl == 2)
                {
                    target.isStuned = true;
                    target.stunTimer = 2;
                }
                else if (attacker.lvl == 3)
                {
                    target.isStuned = true;
                    target.stunTimer = 3; ;
                }
                attacker.SkillEffect(target.gameObject, target.transform.forward, 2);
                break;
            case 3:
                for (int i = 0; i < playerChampion.Count; i++)
                {
                    ChampionController champion = playerChampion[i];
                    skill3Attacker = attacker;
                    if (skill3buffOn == false)
                    {
                        if (attacker.lvl == 1)
                            champion.currentDefence += 20;
                        else if (attacker.lvl == 2)
                            champion.currentDefence += 40;
                        else if (attacker.lvl == 3)
                            champion.currentDefence += 80;
                        skill3buffOn = true;
                    }
                    duration3 = this.time + 10; // 지속시간    
                }
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 2);
                break;
            case 4:
                if (attacker.lvl == 1)
                {
                    damage = attacker.currentDamage * 1.5f;
                    target.currentHealth -= damage;
                    worldCanvasController.AddDamageText(attacker.transform.position + new Vector3(0, 2.5f, 0), damage, Color.red);
                    target.isStuned = true;
                    target.stunTimer = 2;
                }
                else if (attacker.lvl == 2)
                {

                    damage = attacker.currentDamage * 2;
                    target.currentHealth -= damage;
                    worldCanvasController.AddDamageText(attacker.transform.position + new Vector3(0, 2.5f, 0), damage, Color.red);
                    target.isStuned = true;
                    target.stunTimer = 3;
                }
                else if (attacker.lvl == 3)
                {
                    damage = attacker.currentDamage * 3;
                    target.currentHealth -= damage;
                    worldCanvasController.AddDamageText(attacker.transform.position + new Vector3(0, 2.5f, 0), damage, Color.red);
                    target.isStuned = true;
                    target.stunTimer = 4;
                }
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 2);
                break;
            case 5:
                for (int i = 0; i < playerChampion.Count; i++)
                {
                    ChampionController champion = playerChampion[i];
                    skill5Attacker = attacker;
                    if (skill5buffOn == false)
                    {
                        if (attacker.lvl == 1)
                            champion.currentDefence += 50;
                        else if (attacker.lvl == 2)
                            champion.currentDefence += 80;
                        else if (attacker.lvl == 3)
                            champion.currentDefence += 130;
                        skill5buffOn = true;
                    }
                    duration5 = this.time + 60; // 지속시간   
                }
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 2);
                break;
            case 6:
                if (attacker.lvl == 1)
                {
                    damage = attacker.currentDamage * 2;
                    target.currentHealth -= damage;
                    worldCanvasController.AddDamageText(attacker.transform.position + new Vector3(0, 2.5f, 0), damage, Color.red);
                }
                else if (attacker.lvl == 2)
                {
                    damage = attacker.currentDamage * 2.5f;
                    target.currentHealth -= damage;
                    worldCanvasController.AddDamageText(attacker.transform.position + new Vector3(0, 2.5f, 0), damage, Color.red);
                }
                else if (attacker.lvl == 3)
                {
                    damage = attacker.currentDamage * 4;
                    target.currentHealth -= damage;
                    worldCanvasController.AddDamageText(attacker.transform.position + new Vector3(0, 2.5f, 0), damage, Color.red);
                }
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 2);
                break;
            case 7:
                for (int i = 0; i < playerChampion.Count; i++)
                {
                    ChampionController champion = playerChampion[i];
                    skill7Attacker = attacker;
                    if (skill7buffOn == false)
                    {
                        if (attacker.lvl == 1)
                            champion.currentDefence += champion.currentDamage * (20 / 100);
                        else if (attacker.lvl == 2)
                            champion.currentDefence += champion.currentDamage * (30 / 100);
                        else if (attacker.lvl == 3)
                            champion.currentDefence += champion.currentDamage * (40 / 100);
                        skill7buffOn = true;
                    }
                    duration7 = this.time + 20; // 지속시간   
                }
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 2);
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
                attacker.SkillEffect(target.gameObject, attacker.transform.forward, 2);
                break;
            case 9:
                if (attacker.lvl == 1) attacker.currentShield += 400;
                else if (attacker.lvl == 2) attacker.currentShield += 800;
                else if (attacker.lvl == 3) attacker.currentShield += 1500;
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 2);
                break;
            case 10:
                if (attacker.lvl == 1)
                {
                    damage = attacker.currentDamage * 2;
                    target.currentHealth -= damage;
                    worldCanvasController.AddDamageText(attacker.transform.position + new Vector3(0, 2.5f, 0), damage, Color.red);
                }
                else if (attacker.lvl == 2)
                {
                    damage = attacker.currentDamage * 2.5f;
                    target.currentHealth -= damage;
                    worldCanvasController.AddDamageText(attacker.transform.position + new Vector3(0, 2.5f, 0), damage, Color.red);
                }
                else if (attacker.lvl == 3)
                {
                    damage = attacker.currentDamage * 3;
                    target.currentHealth -= damage;
                    worldCanvasController.AddDamageText(attacker.transform.position + new Vector3(0, 2.5f, 0), damage, Color.red);
                }
                attacker.SkillEffect(target.gameObject, target.transform.forward, 2);
                break;
            case 11:
                if (skill11buffOn == false)
                {
                    attacker.currentAttackSpeed *= 300 / 100;
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
                damage = attacker.currentDamage * (150 / 100);
                if (target.currentShield < damage)
                {
                    target.currentShield = 0;
                    target.currentHealth -= damage - target.currentShield;
                }
                else target.currentShield -= damage;

                worldCanvasController.AddDamageText(attacker.transform.position + new Vector3(0, 3, 0), damage, Color.red);

                if (skill14buffOn == false)
                {
                    if (attacker.lvl == 1) target.currentDefence *= 0.9f;
                    else if (attacker.lvl == 2) target.currentDefence *= 0.8f;
                    else if (attacker.lvl == 3) target.currentDefence *= 0.7f;
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
                for (int i = 0; i < playerChampion.Count; i++)
                {
                    ChampionController champion = playerChampion[i];
                    skill16Attacker = attacker;
                    if (skill16buffOn == false)
                    {
                        if (attacker.lvl == 1)
                            champion.currentAttackSpeed *= (120 / 100);
                        else if (attacker.lvl == 2)
                            champion.currentAttackSpeed *= (130 / 100);
                        else if (attacker.lvl == 3)
                            champion.currentAttackSpeed *= (150 / 100);
                        skill16buffOn = true;

                    }
                    duration16 = this.time + 10; // 지속시간  
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
                    target.currentHealth -= damage;
                    worldCanvasController.AddDamageText(attacker.transform.position + new Vector3(0, 2.5f, 0), damage, Color.red);
                    target.isStuned = true;
                    target.stunTimer = 2;
                }
                else if (attacker.lvl == 2)
                {
                    damage = attacker.currentDamage * 2;
                    target.currentHealth -= damage;
                    worldCanvasController.AddDamageText(attacker.transform.position + new Vector3(0, 2.5f, 0), damage, Color.red);
                    target.isStuned = true;
                    target.stunTimer = 2;
                }
                else if (attacker.lvl == 3)
                {
                    damage = attacker.currentDamage * 3;
                    target.currentHealth -= damage;
                    worldCanvasController.AddDamageText(attacker.transform.position + new Vector3(0, 2.5f, 0), damage, Color.red);
                    target.isStuned = true;
                    target.stunTimer = 2;
                }
                attacker.SkillEffect(target.gameObject, target.transform.forward, 2);
                break;
            case 20:
                if (attacker.lvl == 1) attacker.currentShield += attacker.maxHealth * 0.1f;
                else if (attacker.lvl == 2) attacker.currentShield += attacker.maxHealth * 0.2f;
                else if (attacker.lvl == 3) attacker.currentShield += attacker.maxHealth * 0.4f;
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 2);
                break;
            case 21:
                for (int i = 0; i < playerChampion.Count; i++)
                {
                    ChampionController champion = playerChampion[i];
                    skill21Attacker = attacker;
                    if (skill21buffOn == false)
                    {
                        if (attacker.lvl == 1)
                            champion.currentAttackSpeed *= (150 / 100);
                        else if (attacker.lvl == 2)
                            champion.currentAttackSpeed *= (175 / 100);
                        else if (attacker.lvl == 3)
                            champion.currentAttackSpeed *= (200 / 100);
                        skill21buffOn = true;
                    }
                    duration21 = this.time + 5; // 지속시간  
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
                    if (attacker.lvl == 1) champion.currentDamage *= 97 / 100;
                    else if (attacker.lvl == 2) champion.currentDamage *= 95 / 100;
                    else if (attacker.lvl == 3) champion.currentDamage *= 92 / 100;
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
                attacker.currentHealth *= 50 / 100;
                for (int i = 0; i < playerChampion.Count; i++)
                {
                    ChampionController champion = playerChampion[i];
                    skill25Attacker = attacker;
                    if (skill25buffOn == false)
                    {
                        if (attacker.lvl == 1)
                            champion.currentDamage *= (110 / 100);
                        else if (attacker.lvl == 2)
                            champion.currentDamage *= (120 / 100);
                        else if (attacker.lvl == 3)
                            champion.currentDamage *= (130 / 100);
                        skill25buffOn = true;
                    }
                    duration25 = this.time + 20; // 지속시간 
                }
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 2);
                break;
            case 26:
                skill26Attacker = attacker;
                if (skill26buffOn == false)
                {
                    if (attacker.lvl == 1)
                    {
                        attacker.currentDamage *= (130 / 100);
                        attacker.currentAttackSpeed *= (130 / 100);
                    }
                    else if (attacker.lvl == 2)
                    {
                        attacker.currentDamage *= (150 / 100);
                        attacker.currentAttackSpeed *= (150 / 100);
                    }
                    else if (attacker.lvl == 3)
                    {
                        attacker.currentDamage *= (170 / 100);
                        attacker.currentAttackSpeed *= (170 / 100);
                    }
                    skill26buffOn = true;
                }
                duration26 = this.time + 10; // 지속시간  
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 2);
                break;
            case 27:
                for (int i = 0; i < playerChampion.Count; i++)
                {
                    ChampionController champion = playerChampion[i];
                    skill27Attacker = attacker;
                    if (skill27buffOn == false)
                    {
                        if (attacker.lvl == 1)
                            champion.currentDefence += 50;
                        else if (attacker.lvl == 2)
                            champion.currentDefence += 100;
                        else if (attacker.lvl == 3)
                            champion.currentDefence += 150;
                        skill27buffOn = true;
                    }
                    duration27 = this.time + 10; // 지속시간 
                }
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 2);
                break;
            case 28:
                skill28Attacker = attacker;
                if (attacker.lvl == 1)
                    attacker.currentHealth += attacker.maxHealth * (10 / 100);
                else if (attacker.lvl == 2)
                    attacker.currentHealth += attacker.maxHealth * (20 / 100);
                else if (attacker.lvl == 3)
                    attacker.currentHealth += attacker.maxHealth * (35 / 100);
                if (attacker.currentHealth >= attacker.maxHealth)
                    attacker.currentHealth = attacker.maxHealth;
                if (skill28buffOn == false)
                {
                    attacker.currentAttackSpeed *= 200 / 100;
                    skill28buffOn = true;
                }
                duration28 = this.time + 3; // 지속시간
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 2);
                break;
            case 29:
                if (attacker.lvl == 1)
                {
                    damage = attacker.currentDamage * 2;
                    target.currentHealth -= damage;
                    worldCanvasController.AddDamageText(attacker.transform.position + new Vector3(0, 2.5f, 0), damage, Color.red);
                    target.isStuned = true;
                    target.stunTimer = 5;
                }
                else if (attacker.lvl == 2)
                {
                    damage = attacker.currentDamage * 3;
                    target.currentHealth -= damage;
                    worldCanvasController.AddDamageText(attacker.transform.position + new Vector3(0, 2.5f, 0), damage, Color.red);
                    target.isStuned = true;
                    target.stunTimer = 5;
                }
                else if (attacker.lvl == 3)
                {
                    damage = attacker.currentDamage * 5;
                    target.currentHealth -= damage;
                    worldCanvasController.AddDamageText(attacker.transform.position + new Vector3(0, 2.5f, 0), damage, Color.red);
                    target.isStuned = true;
                    target.stunTimer = 5;
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
                        attacker.currentDamage *= (200 / 100);
                    else if (attacker.lvl == 2)
                        attacker.currentDamage *= (300 / 100);
                    else if (attacker.lvl == 3)
                        attacker.currentDamage *= (400 / 100);
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
                        attacker.currentAttackSpeed *= 200 / 100;
                    else if (attacker.lvl == 2)
                        attacker.currentAttackSpeed *= 250 / 100;
                    else if (attacker.lvl == 3)
                        attacker.currentAttackSpeed *= 300 / 100;
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
                    attacker.currentAttackSpeed *= 400 / 100;
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
                    target.isStuned = true;
                    target.stunTimer = 3;

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
                    target.isStuned = true;
                    target.stunTimer = 3;
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
                    target.isStuned = true;
                    target.stunTimer = 3;
                }
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 0.5f);
                attacker.SkillEffect2(target.gameObject, attacker.transform.forward, 1.5f);
                break;
            case 39:
                for (int i = 0; i < playerChampion.Count; i++)
                {
                    ChampionController champion = playerChampion[i];
                    skill39Attacker = attacker;
                    if (skill39buffOn == false)
                    {
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

                        skill39buffOn = true;
                    }
                    duration39 = this.time + 5; // 지속시간
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
                target.currentHealth -= attacker.currentDamage * 3f;
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 1f);
                break;
            case 45:
                // 소환 스킬
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
                            championController.currentHealth -= damage;
                            championController.isStuned = true;
                            championController.stunTimer = 1;
                        }
                    }
                }
                attacker.SkillEffect(attacker.gameObject, attacker.transform.forward, 1f);
                break;
            case 51:
                // 소환 스킬
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
                            championController.currentHealth -= damage;
                            championController.isStuned = true;
                            championController.stunTimer = 2;
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
                                    championController.isSilence = true;
                                    championController.silenceTimer = 3;
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
                                    championController.isStuned = true;
                                    championController.stunTimer = 1;
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
                for (int i = 0; i < playerChampion.Count; i++)
                {
                    ChampionController champion = playerChampion[i];
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

        // 스킬7('착시효과' 버프 Off)
        if (time >= duration7)
        {
            if (skill7buffOn)
            {
                for (int i = 0; i < playerChampion.Count; i++)
                {
                    ChampionController champion = playerChampion[i];
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
                for (int i = 0; i < playerChampion.Count; i++)
                {
                    ChampionController champion = playerChampion[i];
                    if (skill16Attacker.lvl == 1)
                        champion.currentAttackSpeed *= (100 / 120);
                    else if (skill16Attacker.lvl == 2)
                        champion.currentAttackSpeed *= (100 / 130);
                    else if (skill16Attacker.lvl == 3)
                        champion.currentAttackSpeed *= (100 / 150);
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
                        champion.currentAttackSpeed *= (100 / 150);
                    else if (skill21Attacker.lvl == 2)
                        champion.currentAttackSpeed *= (100 / 175);
                    else if (skill21Attacker.lvl == 3)
                        champion.currentAttackSpeed *= (100 / 200);
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
                        champion.currentDamage *= (100 / 110);
                    else if (skill25Attacker.lvl == 2)
                        champion.currentDamage *= (100 / 120);
                    else if (skill25Attacker.lvl == 3)
                        champion.currentDamage *= (100 / 130);
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
                    skill26Attacker.currentDamage *= (100 / 130);
                    skill26Attacker.currentAttackSpeed *= (100 / 130);
                }
                else if (skill26Attacker.lvl == 2)
                {
                    skill26Attacker.currentDamage *= (100 / 150);
                    skill26Attacker.currentAttackSpeed *= (100 / 150);
                }
                else if (skill26Attacker.lvl == 3)
                {
                    skill26Attacker.currentDamage *= (100 / 170);
                    skill26Attacker.currentAttackSpeed *= (100 / 170);
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
                        champion.currentDefence -= 50;
                    else if (skill27Attacker.lvl == 2)
                        champion.currentDefence -= 100;
                    else if (skill27Attacker.lvl == 3)
                        champion.currentDefence -= 150;
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
                skill28Attacker.currentAttackSpeed *= 100 / 200;
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
                    skill31Attacker.currentDamage *= 100 / 200;
                else if (skill31Attacker.lvl == 2)
                    skill31Attacker.currentDamage *= 100 / 300;
                else if (skill31Attacker.lvl == 3)
                    skill31Attacker.currentDamage *= 100 / 400;
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
                    skill32Attacker.currentAttackSpeed *= 100 / 200;
                else if (skill32Attacker.lvl == 2)
                    skill32Attacker.currentAttackSpeed *= 100 / 250;
                else if (skill32Attacker.lvl == 3)
                    skill32Attacker.currentAttackSpeed *= 100 / 300;
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
                skill33Attacker.currentAttackSpeed *= 100 / 400;
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




