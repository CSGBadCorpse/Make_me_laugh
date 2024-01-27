using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTurns : MonoBehaviour
{
    public Player player;
    public Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ProcessEffect(int id)
    {
        Card card = player.GetCardFromId(id);
        
        switch (id)
        {
            
            case 1:
                
                if (player.GetCardListLength() == 0)
                {
                    card.canUsed = false;
                }

                if (!card.CanUse())
                {
                    return;
                }
                player.UseCard(card);
                enemy.Heal( card.cardInfo.EffectValue);
                
                
                break;
            case 2:
                player.UseCard(card);
                enemy.Heal(card.cardInfo.EffectValue);
                break;
            case 3:
                player.UseCard(card);
                card.usedCount++;
                enemy.Heal(card.cardInfo.EffectValue+card.usedCount);
                break;
            case 4:
                player.UseCard(card);
                for (int i =0;i<player.GetCardListLength();i++)
                {
                    ProcessEffect(player.GetCardFromIndex(i).cardInfo.CardID);
                }
                break;
            case 5:
                player.UseCard(card);
                player.Heal(card.cardInfo.EffectValue);
                break;
            case 6:
                break;
            case 7:
                player.UseCard(card);
                player.Heal(card.cardInfo.EffectValue);
                break;
            case 8:
                enemy.UseCard(card);
                player.TakeDamage(card.cardInfo.EffectValue);
                break;
            case 9:
                enemy.UseCard(card);
                if(player.GetCardListLength()==0){
                    player.TakeDamage(card.cardInfo.EffectValue);    
                }
                
                break;
            case 10:
                enemy.UseCard(card);
                player.GetCardFromIndex(0).isActive= false;
                enemy.Heal(card.cardInfo.EffectValue);
                break;



        }
    }
}
