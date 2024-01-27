using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [Header("CardsInfo")]
    public List<CardInfo> cardInfoList;//需要使用的牌

    public List<CardInfo> cardInGroup;//卡组里的牌

    public List<Card> cardList = new List<Card>();//敌人手里的牌
    [SerializeField] private GameObject card;

    
    float time;
    private int index;

    [Header("PlayerInfo")]
    [SerializeField] private int hpMax = 100;
    public int hpCur;
    // public CardHand cardHand;
    
    public UnityEvent<int,int> onHealthChanged;
    public static Enemy Instance{get;private set;}
    
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        // hpCur = hpMax;
        time = Random.Range(3f,10f);
   
        InitCardGroupList();
    }


    private void Update()
    {
        if (cardInGroup.Count == 0)
        {
            RegenerateCard();
        }
        
        if (time > 0)
        {
            time -= Time.deltaTime;
        }

        if (time <= 0)
        {
            if (cardList.Count >= 1)
            {
                index = Random.Range(0, cardList.Count - 1);
                MainTurns.Instance.ProcessEffect(cardList[index]);    
            }
            
            time = Random.Range(3f,10f);

            
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
        // cardHand.UseCard(card);
        if (cardList.Contains(card))
        {
            cardList.Remove(card);
        }
    }

    public bool IsEnemyHappy()
    {
        if (hpCur == hpMax)
            return true;
        return false;
    }

    public void InitCardGroupList()
    {
        for (int i = 0; i < cardInfoList.Count; i++)
        {
            int count = 0;
            switch (cardInfoList[i].CardID)
            {
                case 8 :
                    count = 1;
                    break;
                case 9:
                    count =1;
                    break;
                case 10:
                    count = 1;
                    break;
            }

            for (int j = 0; j < count; j++)
            {
                cardInGroup.Add(cardInfoList[i]);
            }
        }
    }
    public void DrawCard()
    {
        int randomCardIndex = UnityEngine.Random.Range(0, cardInGroup.Count-1);

        Card cardIndex = Instantiate(card, Vector3.zero, Quaternion.identity).GetComponent<Card>();
        cardIndex.cardInfo = cardInGroup[randomCardIndex];
        cardIndex.ShowCard();
        
        
        cardList.Add(cardIndex);
        cardInGroup.Remove(cardInGroup[randomCardIndex]);
    }
    public void RegenerateCard()
    {
        InitCardGroupList();
        if (cardList.Count > 0)
        {
            foreach (var index in cardList)
            {
                cardInGroup.Remove(index.cardInfo);
            }
        }
    }
}
