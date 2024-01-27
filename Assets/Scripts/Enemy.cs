using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int hpMax = 100;
    public int hpCur;
    private CardHand cardHand;
    // Start is called before the first frame update
    void Awake()
    {
        hpCur = hpMax;
    }
    
    public void TakeDamage(int damage)
    {
        if (hpCur > 0)
        {
            hpCur -= damage;
        }
    }

    public void Heal(int heal)
    {
        if (hpCur < hpMax)
        {
            hpCur += heal;
        }
    }
    public void UseCard(Card card)
    {
        TakeDamage(card.GetComponent<CardInfo>().CardCost);
        cardHand.UseCard(card);
    }
}
