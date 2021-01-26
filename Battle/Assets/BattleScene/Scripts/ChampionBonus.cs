using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChampionBonusType {Shield,Health,Critical,Regeneration,Evasion,TiedDamage,Attack,AttackMana,AttackSpeed,Summon,AtkDef,MoveSpeed
                               ,Evil,Wealth,Sin7,Admirer,Zodiacal,TenLongevity,Fecyndiry,Loyality,Death,Strength,King,Ability};
public enum BonusTarget {Self, Enemy};

/// <summary>
/// Controls the bonuses to get when have enough champions of the same type
/// </summary>
[System.Serializable]
public class ChampionBonus
{
    public GamePlayController gamePlayController;


    ///Type of the bonus
    public ChampionBonusType championBonusType;

    ///Target of the bonus
    public BonusTarget bonusTarget;

    ///How many champions needed to get the bonus effect
    public float championCount1 = 0;
    public float championCount2 = 0;
    public float championCount3 = 0;

    ///Float value of the bonus
    public float bonusValue1 = 0;
    public float bonusValue2 = 0;
    public float bonusValue3 = 0;

    ///How many secounds bonus lasts
    public float duration;

    ///Prefab to instantiate when bonus occours
    public GameObject effectPrefab;

    void Awake()
    {
        gamePlayController = GameObject.Find("Scripts").GetComponent<GamePlayController>();
    }


   /// <summary>
   /// Calculates bonuses of a champion when attacking
   /// </summary>
   /// <param name="champion"></param>
   /// <param name="targetChampion"></param>
   /// <returns></returns>
    public void ApplyOnAttack(ChampionController champion, ChampionController targetChampion)
    {
        
        bool addEffect = true;
        //  switch (championBonusType)
        //  {
        //      case ChampionBonusType.Damage :
        //          finalDamage += bonusValue1;
        //          break;
        //      case ChampionBonusType.Stun:
        //          int rand = Random.Range(0, 100);
        //          if (rand < bonusValue1)
        //          {
        //              targetChampion.OnGotStun(duration);
        //              addEffect = true;
        //          }
        //          break;
        //      case ChampionBonusType.Heal:
        //          champion.OnGotHeal(bonusValue1);
        //          addEffect = true;
        //          break;
        //      case ChampionBonusType.Shield:
        //          champion.OnGotShield(bonusValue1,bonusValue2);
        //          addEffect = true;
        //          break;
        //      default:
        //          break;
        //  }


        if (addEffect)
        {
            if (bonusTarget == BonusTarget.Self)
               champion.AddEffect(effectPrefab, duration);
            else if (bonusTarget == BonusTarget.Enemy)
               targetChampion.AddEffect(effectPrefab, duration);
        }
    }

    /// <summary>
    /// Calculates bonuses of a Champion when got hit
    /// </summary>
    /// <param name="champion"></param>
    /// <param name="damage"></param>
    /// <returns></returns>
    //  public float ApplyOnGotHit(ChampionController champion, float damage)
    //  {
    //      switch (championBonusType)
    //      {        
    //          case ChampionBonusType.Defense:
    //              damage = ((100 - bonusValue1) / 100) * damage;
    //              break;   
    //          default:
    //              break;
    //      }
    //  
    //      return damage;
    //  }


    //  시너지 변수


    //  시너지 적용 함수
    public void ApplySynergy(ChampionController champion, int num)
    {
        switch (championBonusType)
        {
            //  외형 시너지 : Type1
            //--------------------------------------------------------------------------------
            //  껍데기 시너지
            case ChampionBonusType.Shield:
                if (num >= championCount2)
                {
                    if (champion.champType1.displayName == "껍데기")
                    {
                        champion.OnGotShield(bonusValue2);
                    }
                }
                else if (num >= championCount1)
                {
                    if (champion.champType1.displayName == "껍데기")
                    {
                        champion.OnGotShield(bonusValue1);
                    }
                }
                break;
            case ChampionBonusType.Health:
                if (num >= championCount3)
                {
                    if (champion.champType1.displayName == "두꺼운가죽")
                    {
                        champion.maxHealth += bonusValue3;
                        champion.currentHealth += bonusValue3;
                    }
                }
                else if (num >= championCount2)
                {
                    if (champion.champType1.displayName == "두꺼운가죽")
                    {
                        champion.maxHealth = champion.champion.health + bonusValue2;
                        champion.currentHealth += bonusValue2;
                    }
                }
                else if (num >= championCount1)
                {
                    if (champion.champType1.displayName == "두꺼운가죽")
                    {
                        champion.maxHealth += bonusValue1;
                        champion.currentHealth += bonusValue1;
                    }
                }
                break;
            case ChampionBonusType.Critical:
                champion.currentCritical = 50;
                break;
            case ChampionBonusType.Regeneration:
                if(num >= championCount3)
                {
                    champion.currentHealthReg = bonusValue3;
                }
                else if (num >= championCount2)
                {
                    champion.currentHealthReg = bonusValue2;
                }
                else if (num >= championCount1)
                {
                    champion.currentHealthReg = bonusValue1;
                }
                break;
            case ChampionBonusType.Evasion:
                if(num >= championCount2)
                {
                    if (champion.champType1.displayName == "작은몸집")
                    {
                        champion.currentEvasion = bonusValue2;
                    }
                }
                else if (num >= championCount1)
                {
                    if (champion.champType1.displayName == "작은몸집")
                    {
                        champion.currentEvasion = bonusValue1;
                    }
                }
                break;
            case ChampionBonusType.Attack:
                if(num >= championCount2)
                {
                    champion.currentDamage += bonusValue2;
                }
                else if (num >= championCount1)
                {
                    champion.currentDamage += bonusValue1;
                }
                break;
            case ChampionBonusType.AttackMana:
                if(num >= championCount2)
                {
                    if(champion.champType1.displayName == "가축")
                    {
                        champion.currentAttackMana = champion.champion.attackMana * bonusValue2;
                    }
                }
                else if(num >= championCount1)
                {
                    if (champion.champType1.displayName == "가축")
                    {
                        champion.currentAttackMana = champion.champion.attackMana * bonusValue1;
                    }
                }
                break;
            case ChampionBonusType.AttackSpeed:
                if (num >= championCount2)
                {
                    if(champion.champType1.displayName == "화려한무늬")
                    {
                        champion.currentAttackSpeed = champion.champion.attackSpeed * (1 + (bonusValue2 / 100));
                    }
                }
                else if (num >= championCount1)
                {
                    if (champion.champType1.displayName == "화려한무늬")
                    {
                        champion.currentAttackSpeed = champion.champion.attackSpeed * (1+(bonusValue1 / 100));
                    }
                }
                break;
            case ChampionBonusType.AtkDef:
                if(num >= championCount3)
                {
                    champion.currentDamage = champion.champion.damage * (1 + (bonusValue3 / 100));
                    champion.currentDefence = champion.champion.defence * (1 + (bonusValue3 / 100));
                }
                else if (num >= championCount2)
                {
                    champion.currentDamage = champion.champion.damage * (1 + (bonusValue2 / 100));
                    champion.currentDefence = champion.champion.defence * (1 + (bonusValue2 / 100));
                }
                else if (num >= championCount1)
                {
                    champion.currentDamage = champion.champion.damage * (1 + (bonusValue1 / 100));
                    champion.currentDefence = champion.champion.defence * (1 + (bonusValue1 / 100));
                }
                break;
            case ChampionBonusType.MoveSpeed:
                if(champion.champType1.displayName == "단단한부리")
                {
                    champion.currentMoveSpeed = champion.champion.movementSpeed + bonusValue1; // 이속 bonusValue1
                    champion.currentAttackSpeed = champion.champion.attackSpeed * (1+(bonusValue2/100)); // 공속 bonusValue2
                }
                break;

            //  상징 시너지 : Type1
            //--------------------------------------------------------------------------------
            case ChampionBonusType.Sin7:
                champion.sin7 = true;
                if(num >= championCount3)
                    champion.sin7Shield = bonusValue3;
                else if(num >= championCount2)
                    champion.sin7Shield = bonusValue2;
                else if(num >= championCount1)
                    champion.sin7Shield = bonusValue1;
                break;
            case ChampionBonusType.Wealth:
                gamePlayController.wealth = true;
                if (num >= championCount3)
                    gamePlayController.wealthMoney = bonusValue3;
                else if (num >= championCount2)
                    gamePlayController.wealthMoney = bonusValue2;
                else if (num >= championCount1)
                    gamePlayController.wealthMoney = bonusValue1;
                break;
            default:
                break;
        }
    }
    
    //   데미지 공식!!!!
    public float ApplyOnGotHit(ChampionController hit,ChampionController champion, int num, float damage)
    {
        float finalDamage = 0;
        int ran = Random.Range(1, 101);
        string type1 = champion.champType1.displayName;

        switch (championBonusType)
        {
            case ChampionBonusType.TiedDamage:
                if (type1 == "위장")
                {
                    if (ran <= champion.currentCritical)
                    {
                        finalDamage = damage * 1.5f;
                    }
                    else finalDamage = damage;
                }
                break;
            case ChampionBonusType.Evil:
                if(num >= championCount2)
                {
                    if (type1 == "악의상징")
                    {
                        if (ran <= champion.currentCritical)
                        {
                            finalDamage = damage * (1 - (hit.currentDefence / (hit.currentDefence + 100))) * 1.5f + bonusValue2;
                        }
                        else finalDamage = damage * (1 - (hit.currentDefence / (hit.currentDefence + 100))) + bonusValue2;
                    }
                }
                else if(num >= championCount1)
                {
                    if (type1 == "악의상징")
                    {
                        if (ran <= champion.currentCritical)
                        {
                            finalDamage = damage * (1 - (hit.currentDefence / (hit.currentDefence + 100))) * 1.5f + bonusValue1;
                        }
                        else finalDamage = damage * (1 - (hit.currentDefence / (hit.currentDefence + 100))) + bonusValue1;
                    }
                }
                break;
            case ChampionBonusType.Admirer:

                break;
            default:
                if (ran <= champion.currentCritical)
                {
                    finalDamage = damage * (1 - (hit.currentDefence / (hit.currentDefence + 100)));
                }
                else finalDamage = damage * (1 - (hit.currentDefence / (hit.currentDefence + 100)));
                break;
            

        }
        return finalDamage;
    }
}
