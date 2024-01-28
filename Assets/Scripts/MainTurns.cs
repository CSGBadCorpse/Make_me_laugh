using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MainTurns : MonoBehaviour
{
    // private Player playerInstance;
    // private Enemy enemyInstance;
    public static MainTurns Instance;

    public static UnityEvent Win;
    public static UnityEvent Lose;

    public GameObject winObject;
    public GameObject failObject;
    // private bool isPaused = false;
    private void Awake()
    {
        Instance = this;
        // playerInstance = Player.Instance;
        // enemyInstance = Enemy.Instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //random add card
        if (Enemy.Instance.IsEnemyHappy())
        {
            Win?.Invoke();
            winObject.SetActive(true);
            // TogglePause();
        }
        else if(Player.Instance.IsPlayerSad()&&!Enemy.Instance.IsEnemyHappy())
        {   
            Lose?.Invoke();
            failObject.SetActive(true);
            // TogglePause();
        }
    }
    // void TogglePause()
    // {
    //     // 切换暂停状态
    //     isPaused = !isPaused;
    //
    //     // 根据暂停状态设置时间缩放
    //     if (isPaused)
    //     {
    //         Time.timeScale = 0f; // 暂停时间
    //     }
    //     else
    //     {
    //         Time.timeScale = 1f; // 恢复正常时间流逝
    //     }
    // }

    public void ProcessEffect(Card card,bool isAll = false)
    {
        int id = card.cardInfo.CardID;
        
        switch (id)
        {
            
            case 1:
                
                if (Player.Instance.GetCardListLength() > 1&& !isAll)
                {
                    Debug.Log("不能使用");
                    card.canUsed = false;
                }
                else
                {
                    card.canUsed = true;
                }

                if (!card.CanUse())
                {
                    return;
                }
                Player.Instance.UseCard(card,isAll);
                Enemy.Instance.Heal( card.cardInfo.EffectValue);
                
                
                break;
            case 2:
                Player.Instance.UseCard(card,isAll);
                Enemy.Instance.Heal(card.cardInfo.EffectValue);
                break;
            case 3:
                Player.Instance.UseCard(card,isAll);
                card.usedCount++;
                Enemy.Instance.Heal(card.cardInfo.EffectValue+card.usedCount);
                break;
            case 4:
                Player.Instance.UseCard(card,isAll);
                
                for (int i = Player.Instance.GetCardListLength()-1;i>=0;i--)
                {
                    ProcessEffect(Player.Instance.GetCardFromIndex(i),true);
                }
            
                break;
            case 5:
                Player.Instance.UseCard(card,isAll);
                Player.Instance.Heal(card.cardInfo.EffectValue);
                break;
            case 6:
                Player.Instance.UseCard(card,isAll);
                UIManager.Instance.playerSpeedBar.SubDrawTime(card.cardInfo.EffectValue);
                break;
            case 7:
                Player.Instance.UseCard(card,isAll);
                Player.Instance.Heal(card.cardInfo.EffectValue);
                break;
            case 8:
                Enemy.Instance.UseCard(card,isAll);
                Player.Instance.TakeDamage(card.cardInfo.EffectValue);
                break;
            case 9:
                Enemy.Instance.UseCard(card,isAll);
                if(Enemy.Instance.cardList.Count==0){
                    Player.Instance.TakeDamage(card.cardInfo.EffectValue);    
                }
                
                break;
            case 10:
                Enemy.Instance.UseCard(card,isAll);
                Player.Instance.GetCardFromIndex(0).isActive= false;
                Enemy.Instance.Heal(card.cardInfo.EffectValue);
                break;



        }
    }
    
}
