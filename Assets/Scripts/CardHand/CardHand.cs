using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHand : MonoBehaviour
{
    [Header("CardHandProperty")]
    [SerializeField]private int MaxCardCount = 10;
    [Header("CardInHandPresenting")]
    [SerializeField]private GameObject card;
    [SerializeField]private float CardXSpacing = 300;
    [SerializeField]private float CardYPosition = 100;
    [SerializeField]private float YDifferentHeight = 10;
    [SerializeField]private float CardDifferentAngle = 10;
    [SerializeField]private float updateSpeed = 4;
    private List<GameObject> cardList = new List<GameObject>();
    
    [HideInInspector]public GameObject HoveredCard = null;

    public void AddCard(CardInfo cardInfo)
    {
        if(cardList.Count>=MaxCardCount)
        {
            Debug.Log("手牌已满");
            return;
        }
        var new_card = CreateCard(cardInfo);
        cardList.Add(new_card);
        // new_card.GetComponent<Card>().OnUse.AddListener((card)=>{UseCard(card);});
        new_card.GetComponent<Card>().OnUse.AddListener(UseCard);;
        new_card.GetComponent<Card>().OnUse.AddListener((card)=>{UIManager.Instance.wordBox.GivenCardUsed(card);});
        UpdatePosition();
    }

    public Card GetCardFromId(int i)
    {
        return cardList.Find(x=>x.GetComponent<Card>().cardInfo.CardID==i).GetComponent<Card>();
    }

    public Card GetCardFromIndex(int index)
    {
        return cardList[index].GetComponent<Card>();
    }
    
    public void UseCard(Card card)
    {
        if(cardList.Contains(card.gameObject))
        {
            cardList.Remove(card.gameObject);
            UpdatePosition();
        }
    }

    public int GetCardListLength()
    {
        return cardList.Count;
    }

    private GameObject CreateCard(CardInfo cardInfo)
    {
        GameObject cardObj = Instantiate(card,Vector3.zero,Quaternion.identity);
        // cardObj.transform.SetParent(UIManager.Instance.canvas.transform);
        cardObj.transform.SetParent(transform);
        RectTransform rectTransform = cardObj.GetComponent<RectTransform>();
        rectTransform.localPosition = CalcCardPosition(cardList.Count-1);
        rectTransform.localRotation = Quaternion.Euler(0, 0, -1*(GetAngle(cardList.Count-1)));
        cardObj.GetComponent<Card>().cardInfo = cardInfo;
        cardObj.GetComponent<Card>().ShowCard();
        return cardObj;
    }

    public void UpdatePosition()
    {
        List<Vector3> LocationDestination = new List<Vector3>();
        List<Quaternion> RotationDestination = new List<Quaternion>();
        for (int i = 0; i < cardList.Count; i++)
        {
            RectTransform rectTransform = cardList[i].GetComponent<RectTransform>();
            LocationDestination.Add(CalcCardPosition(i));
            RotationDestination.Add(Quaternion.Euler(0, 0, -1*(GetAngle(i))));
        }
        StartCoroutine(CoroutineUpdatePosition(LocationDestination,RotationDestination));
    }

    IEnumerator CoroutineUpdatePosition(List<Vector3> DestinationList,List<Quaternion> RotationDestination)
    {
        bool isFinished=false;

        if (isFinished)
        {
            yield break;
        }

        float lerpTimer = 0;
        while(lerpTimer<=1)
        {
            for (int i = 0; i < cardList.Count&& i < DestinationList.Count; i++)
            {
                if (cardList[i] == HoveredCard)
                {
                    continue;
                }
                RectTransform rectTransform = cardList[i].GetComponent<RectTransform>();
                rectTransform.localPosition = Vector3.Lerp(rectTransform.localPosition,DestinationList[i],lerpTimer);
                rectTransform.localRotation = Quaternion.Lerp(rectTransform.localRotation,RotationDestination[i],lerpTimer);
            }
            lerpTimer+=Time.deltaTime * updateSpeed;
            yield return null;
        }
        isFinished = true;
    }

    private Vector3 CalcCardPosition(int index)
    {
        return new Vector3(GetXPosition(index), GetYPosition(index), 0);
    }

    private float GetXPosition(int index)
    {
        int cardCount = cardList.Count;
        index -= cardCount / 2;
        return index * CardXSpacing;
    }
    private float GetYPosition(int index)
    {
        return CardYPosition - Math.Abs(GetCardFloatIndexFromCenter(index)) * YDifferentHeight;
        // return CardYPosition + ((index % 2 == 0) ? YDifferentHeight : 0);
    }
    private float GetAngle(int index)
    {
        float cardIndexFromCenter = GetCardFloatIndexFromCenter(index);
        return CardDifferentAngle*cardIndexFromCenter;
        // return CardAngle * UnityEngine.Random.Range(-1, 1);
        // return 0;
    }

    private float GetCardFloatIndexFromCenter(int index)
    {
        int cardCount = cardList.Count;
        return (float)index - ((float)cardCount-1f) / 2f;
    }

    public List<GameObject> getCardList()
    {

        return cardList;
    } 
}
