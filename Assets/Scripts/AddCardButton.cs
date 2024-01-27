using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddCardButton : MonoBehaviour
{
    public List<CardInfo> cardInfoList;
    private void Awake() {
    }
    public void onClicked()
    {
        //Random add a card to cardHand
        int randomCardIndex = Random.Range(0, cardInfoList.Count);
        UIManager.Instance.cardHand.AddCard(cardInfoList[randomCardIndex]);
    }
}