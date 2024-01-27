using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int hpMax = 100;
    public int hpCur;

    public UnityEvent<int,int> onHealthChanged;

    private CardHand cardHand;

    private void Awake()
    {
        hpCur = hpMax;
    }

    public void TakeDamage(int damage)
    {
        if (hpCur > 0)
        {
            hpCur -= damage;
            onHealthChanged?.Invoke(hpCur,hpMax);
        }
    }

    public void Heal(int heal)
    {
        if (hpCur < hpMax)
        {
            hpCur += heal;
            onHealthChanged?.Invoke(hpCur,hpMax);
        }
    }

    public void UseCard(Card card)
    {
        TakeDamage(card.GetComponent<CardInfo>().CardCost);
        cardHand.UseCard(card);
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
    
}
