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

    // public List<Card> cardList = new List<Card>();//敌人手里的牌
    [SerializeField] private GameObject card;
    [SerializeField] private Transform enemyHandTransform;

    
    float time;
    private int index;

    [Header("PlayerInfo")]
    [SerializeField] private int hpMax = 100;
    public int hpCur;
    // public CardHand cardHand;
    
    public UnityEvent<int,int> onHealthChanged;
    public CardHand cardHand;

    public static Enemy Instance{get;private set;}
    
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        cardHand = UIManager.Instance.enemyCardHand;
        // hpCur = hpMax;
        time = Random.Range(3f,10f);
   
        InitCardGroupList();
        for (int i = 0; i < 4; i++)
        {
            DrawCard();
        }
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
            if (cardHand.GetCardListLength() >= 1)
            {
                index = Random.Range(0, cardHand.GetCardListLength() - 1);
                MainTurns.Instance.ProcessEffect(cardHand.GetCardFromIndex(index));    
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
            if(hpCur > hpMax)
            {
                UIManager.Instance.GameWin();
                hpCur = hpMax;
            }

            onHealthChanged?.Invoke(hpCur,hpMax);
        }
    }
    public void UseCard(Card card,bool isAll = false)
    {
        if (!isAll)
        {
            TakeDamage(card.cardInfo.CardCost);
        }
        Debug.Log("Enemy UseCard");
        cardHand.UseCard(card,true);
        UIManager.Instance.wordBox.SetNewWord("失业者：" + card.cardInfo.CardFunnyWords);
        // if (cardList.Contains(card))
        // {
        //     cardList.Remove(card);
        // }
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
                    count = 10;
                    break;
                case 9:
                    count =10;
                    break;
                case 10:
                    count = 10;
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

        // Debug.Log("randomCardIndex:"+randomCardIndex);
        UIManager.Instance.enemyCardHand.AddCard(cardInGroup[randomCardIndex],false);
        
        
        cardInGroup.Remove(cardInGroup[randomCardIndex]);

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
}
