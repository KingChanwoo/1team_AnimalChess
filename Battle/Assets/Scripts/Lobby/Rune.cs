using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "DefaultChampion", menuName = "AutoChess/Rune", order = 2)]
public class Rune : ScriptableObject
{
    public int runeID;
    public int limitLevel;
    public string runeName;
    public string runeInfo;
    public Sprite runeImage;
}
