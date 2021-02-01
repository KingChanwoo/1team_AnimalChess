using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Stores all the stats and information of a champion character
/// </summary>
[CreateAssetMenu(fileName = "DefaultChampion", menuName = "AutoChess/Champion", order = 1)]
public class Champion : ScriptableObject
{
    ///Physical champion Prefab to create in the game
    public GameObject prefab;

    ///Projectile prefab to create when champion is attacking
    public GameObject attackProjectile;

    public int level;
    public int skillID;
    ///The champion name displayed on the UI frames
    public string uiname;
    public int grade;
    ///The buy gold cost of the champion from the shop
    public int cost;
    public int sellCost;

    ///The type of the champion
    public ChampionType type1;

    ///The type of the champion
    public ChampionType type2;

    ///The champion character starting health point
    // 두꺼운 가죽
    public float health = 100;

    ///The champion character starting health heal amount
    // 점액질 피부
    public float healthRegeneration = 0;

    /// The champion character starting sheild point
    // 껍데기
    public float shield = 0;

    ///The champion character starting mana point
    public float mana = 100;

    public float hitMana = 5;
    public float attackMana = 10;


    ///The champion character damage done on succesful attack
    public float damage = 10;
    public float attackSpeed = 1;

    public float defence = 0;

    ///The champion character starting critical probability
    // 치명적인 뿔
    public float critical = 0;

    ///The champion character starting evasion probability
    // 작은 몸집
    public float evasion = 0;


    ///The range the champion can start attack from
    public float attackRange = 1;

    //  플레이어 패배 시, 유닛이 살아있으면 플레이어HP에 전해줄 데미지
    public int damageToPlayer = 1;

    public float movementSpeed = 3.5f;

    public string skillName;
    public string skillExplain;
}



