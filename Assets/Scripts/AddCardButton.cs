using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddCardButton : MonoBehaviour
{
    public List<CardInfo> cardInfoList;
    private CardHand cardHand;
    private void Awake() {
        cardHand = UIManager.Instance.cardHand;
    }
    public void onClicked()
    {
        //Random add a card to cardHand
        int randomCardIndex = Random.Range(0, cardInfoList.Count);
        cardHand.AddCard(cardInfoList[randomCardIndex]);
    }
}