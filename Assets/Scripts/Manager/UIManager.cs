using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance{get;private set;}
    public Canvas canvas{get;private set;}

    [Header("CardHand Component")]
    public CardHand playerCardHand;
    public CardHand enemyCardHand;

    [Header("SpeedBar Component")]
    public SpeedBar playerSpeedBar;
    public SpeedBar enemySpeedBar;

    [Header("GameManage UI")]
    public GameObject gameWinPanel;
    public GameObject gameOverPanel;


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
    
    public void GameWin()
    {
        Debug.Log("游戏胜利");
        gameWinPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void GameOver()
    {
        Debug.Log("游戏失败");
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
