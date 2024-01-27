using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTurns : MonoBehaviour
{
    private Player playerInstance;
    private Enemy enemyInstance;
    public static MainTurns Instance;

    private void Awake()
    {
        Instance = this;
        playerInstance = Player.Instance;
        enemyInstance = Enemy.Instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ProcessEffect(Card card)
    {
        int id = card.cardInfo.CardID;
        
        switch (id)
        {
            
            case 1:
                
                if (playerInstance.GetCardListLength() > 1 )
                {
                    Debug.Log("不能使用");
                    card.canUsed = false;
                }

                if (!card.CanUse())
                {
                    return;
                }
                playerInstance.UseCard(card);
                playerInstance.Heal( card.cardInfo.EffectValue);
                
                
                break;
            case 2:
                playerInstance.UseCard(card);
                playerInstance.Heal(card.cardInfo.EffectValue);
                break;
            case 3:
                playerInstance.UseCard(card);
                card.usedCount++;
                playerInstance.Heal(card.cardInfo.EffectValue+card.usedCount);
                break;
            case 4:
                playerInstance.UseCard(card);
                for (int i =0;i<playerInstance.GetCardListLength();i++)
                {
                    ProcessEffect(playerInstance.GetCardFromIndex(i));
                }
                break;
            case 5:
                playerInstance.UseCard(card);
                playerInstance.Heal(card.cardInfo.EffectValue);
                break;
            case 6:
                break;
            case 7:
                playerInstance.UseCard(card);
                playerInstance.Heal(card.cardInfo.EffectValue);
                break;
            case 8:
                playerInstance.UseCard(card);
                playerInstance.TakeDamage(card.cardInfo.EffectValue);
                break;
            case 9:
                playerInstance.UseCard(card);
                if(playerInstance.GetCardListLength()==0){
                    playerInstance.TakeDamage(card.cardInfo.EffectValue);    
                }
                
                break;
            case 10:
                playerInstance.UseCard(card);
                playerInstance.GetCardFromIndex(0).isActive= false;
                playerInstance.Heal(card.cardInfo.EffectValue);
                break;



        }
    }
}
