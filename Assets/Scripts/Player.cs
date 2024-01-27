using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    
    public List<CardInfo> cardInfoList;

    public List<CardInfo> cardInGroup;
    
    
    [SerializeField] private int hpMax = 100;
    public int hpCur;
    
    public static Player Instance{get;private set;}

    public UnityEvent<int,int> onHealthChanged;

    private CardHand cardHand;

    private void Awake()
    {
        Instance = this;
        cardHand = UIManager.Instance.playerCardHand;
        hpCur = hpMax;
        
        
        
        cardInGroup = new List<CardInfo>();
        InitCardGroupList();
    }

    private void Update()
    {
        if (cardInGroup.Count == 0)
        {
            RegenerateCard();
        }
    }

    public void TakeDamage(int damage)
    {
        if (hpCur > 0)
        {
            hpCur -= damage;
            if(hpCur<0) hpCur = 0;

            onHealthChanged?.Invoke(hpCur,hpMax);
        }
    }

    public void Heal(int heal)
    {
        if (hpCur < hpMax)
        {
            hpCur += heal;
            if(hpCur > hpMax) hpCur = hpMax;
            onHealthChanged?.Invoke(hpCur,hpMax);
        }
    }

    public void UseCard(Card card,bool isAll = false)
    {
        if (!isAll)
        {
            TakeDamage(card.cardInfo.CardCost);
        }
        cardHand.UseCard(card);
        card.Use();
    }
    
    public Card GetCardFromId(int i)
    {
        return cardHand.GetCardFromId(i);
    }

    public Card GetCardFromIndex(int index)
    {
        return cardHand.GetCardFromIndex(index);

    }
    public int GetCardListLength()
    {
        return cardHand.GetCardListLength();
    }

    

    public void DrawCard()
    {
        //Random add a card to cardHand
        int randomCardIndex = UnityEngine.Random.Range(0, cardInGroup.Count);
        
        UIManager.Instance.playerCardHand.AddCard(cardInGroup[randomCardIndex]);
        cardInGroup.Remove(cardInGroup[randomCardIndex]);


    }

    public void InitCardGroupList()
    {
        for (int i = 0; i < cardInfoList.Count; i++)
        {
            int count = 0;
            switch (cardInfoList[i].CardID)
            {
                case 1 :
                    count = 1;
                    break;
                case 2:
                    count = 3;
                    break;
                case 3:
                    count = 3;
                    break;
                case 4:
                    count = 1;
                    break;
                case 5:
                    count = 3;
                    break;
                case 6:
                    count = 1;
                    break;
                case 7:
                    count = 1;
                    break;
                
            }

            for (int j = 0; j < count; j++)
            {
                cardInGroup.Add(cardInfoList[i]);
            }
        }
    }

    public void RegenerateCard()
    {
        InitCardGroupList();
        if (cardHand.GetCardListLength() > 0)
        {
            foreach (var index in cardHand.getCardList())
            {
                cardInGroup.Remove(index.GetComponent<Card>().cardInfo);
            }
        }
    }

    public bool IsPlayerSad()
    {
        if (hpCur == 0)
            return true;
        return false;
    }
    
}
