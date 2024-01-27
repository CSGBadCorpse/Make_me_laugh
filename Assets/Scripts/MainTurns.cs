using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTurns : MonoBehaviour
{
    // private Player playerInstance;
    private Enemy enemyInstance;
    public static MainTurns Instance;

    private void Awake()
    {
        Instance = this;
        // playerInstance = Player.Instance;
        enemyInstance = Enemy.Instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //random add card
    }

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
                Player.Instance.UseCard(card,isAll);
                Player.Instance.TakeDamage(card.cardInfo.EffectValue);
                break;
            case 9:
                Player.Instance.UseCard(card,isAll);
                if(Player.Instance.GetCardListLength()==0){
                    Player.Instance.TakeDamage(card.cardInfo.EffectValue);    
                }
                
                break;
            case 10:
                Player.Instance.UseCard(card,isAll);
                Player.Instance.GetCardFromIndex(0).isActive= false;
                Player.Instance.Heal(card.cardInfo.EffectValue);
                break;



        }
    }
}
