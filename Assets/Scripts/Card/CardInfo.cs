using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CardInfo", menuName = "ScriptableObject/DefaultCardInfo")]
public class CardInfo : ScriptableObject
{
    public int CardID;
    public string CardName;
    public string CardDescription;
    public string CardFunnyWords;
    public int CardCost;
    public bool IsActive;
}
