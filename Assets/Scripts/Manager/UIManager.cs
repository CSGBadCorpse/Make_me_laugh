using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance{get;private set;}
    public Canvas canvas{get;private set;}
    public CardHand playercardHand{get;private set;}
    public CardHand enemyCardHand{get;private set;}
    public WordBox wordBox{get;private set;}

    private void Awake()
    {
        Instance = this;
        canvas = FindObjectOfType<Canvas>();
        playercardHand = FindObjectOfType<CardHand>();
        wordBox = FindObjectOfType<WordBox>();
    }
}
