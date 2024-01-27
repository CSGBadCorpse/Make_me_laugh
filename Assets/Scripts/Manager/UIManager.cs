using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance{get;private set;}
    public Canvas canvas{get;private set;}
    public CardHand playerCardHand;
    public CardHand enemyCardHand;

    public WordBox wordBox{get;private set;}

    private void Awake()
    {
        Instance = this;
        canvas = FindObjectOfType<Canvas>();
        // playerCardHand = FindObjectOfType<CardHand>();
        wordBox = FindObjectOfType<WordBox>();
        // enemyCardHand = FindObjectOfType<CardHand>();

    }
    
}
