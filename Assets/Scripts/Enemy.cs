using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int hpMax = 100;
    public int hpCur;
    public CardHand cardHand;
    
    public UnityEvent<int,int> onHealthChanged;
    public static Enemy Instance{get;private set;}
    
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        // hpCur = hpMax;
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
    public void UseCard(Card card)
    {
        TakeDamage(card.GetComponent<CardInfo>().CardCost);
        // cardHand.UseCard(card);
        card.Use();
    }
}
