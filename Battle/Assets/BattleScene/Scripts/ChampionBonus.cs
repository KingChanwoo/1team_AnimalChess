using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChampionBonusType {Damage, Defense, Stun, Heal, Shield};
public enum BonusTarget {Self, Enemy};

/// <summary>
/// Controls the bonuses to get when have enough champions of the same type
/// </summary>
[System.Serializable]
public class ChampionBonus
{
    public GamePlayController gamePlayController;
    ///How many champions needed to get the bonus effect
    public int championCount = 0;


    ///Type of the bonus
    public ChampionBonusType championBonusType;

    ///Target of the bonus
    public BonusTarget bonusTarget;

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

    public void ApplySynergy(ChampionController champion, ChampionController targetChampion)
    {
        switch (championBonusType)
        {
            case ChampionBonusType.Shield:
                champion.OnGotShield(bonusValue1, bonusValue2, bonusValue3);
                break;
            default:
                break;
        }
    }
}
