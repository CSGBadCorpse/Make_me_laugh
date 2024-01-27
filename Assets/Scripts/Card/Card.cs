using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour
{
    public CardInfo cardInfo;

    public int usedCount;
    public UnityEvent<Card> OnUse;


    private TextMeshProUGUI cardName;
    private TextMeshProUGUI cardDescription;
    private TextMeshProUGUI cardCost;
    private TextMeshProUGUI cardFunnyWords;

    int cardID;
    public bool canUsed = true;
    public bool isActive = true;

    private void Awake() {
        cardName = transform.Find("CardFace/CardName").GetComponent<TextMeshProUGUI>();
        cardDescription = transform.Find("CardFace/CardDescription").GetComponent<TextMeshProUGUI>();
        cardCost = transform.Find("CardFace/CardCost").GetComponent<TextMeshProUGUI>();
        cardFunnyWords = transform.Find("CardFace/CardFunnyWords").GetComponent<TextMeshProUGUI>();
    }


    public void ShowCard()
    {
        cardID = cardInfo.CardID;
        cardName.text = cardInfo.CardName;
        cardDescription.text = cardInfo.CardDescription;
        cardFunnyWords.text = cardInfo.CardFunnyWords;
        cardCost.text = cardInfo.CardCost.ToString();
    }

    public bool CanUse()
    {
        return canUsed;
    }
    public bool Use()
    {
        if (CanUse())
        {
            Debug.Log("Use Card");
            OnUse?.Invoke(this);
            OnUse.RemoveAllListeners();
            UIManager.Instance.playerCardHand.HoveredCard = null;
            PreView.EnablePreview = true;
            Destroy(gameObject);
            
            return true;
        }
        return false;
    }
}
