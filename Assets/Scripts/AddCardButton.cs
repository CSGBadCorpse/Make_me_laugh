using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddCardButton : MonoBehaviour
{
    public List<CardInfo> cardInfoList;

    public List<CardInfo> cardInGroup;
    private void Awake()
    {
        cardInGroup = new List<CardInfo>();
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
    public void onClicked()
    {
        //Random add a card to cardHand
        int randomCardIndex = Random.Range(0, cardInGroup.Count);
        
        UIManager.Instance.playerCardHand.AddCard(cardInGroup[randomCardIndex]);
        cardInGroup.Remove(cardInGroup[randomCardIndex]);


    }
}