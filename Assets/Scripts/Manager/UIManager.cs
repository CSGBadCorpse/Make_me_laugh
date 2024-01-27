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

    public SpeedBar playerSpeedBar;
    public SpeedBar enemySpeedBar;

    public WordBox wordBox{get;private set;}

    private void Awake()
    {
        // Debug.Log(Screen.width + "x" + Screen.height);
        Instance = this;
        canvas = FindObjectOfType<Canvas>();
        // playerCardHand = FindObjectOfType<CardHand>();
        wordBox = FindObjectOfType<WordBox>();
        // enemyCardHand = FindObjectOfType<CardHand>();

    }
    
}
