using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WordBox : MonoBehaviour
{
    private TextMeshProUGUI wordBox;
    private string text
    {
        get => currentShowingText;
        set
        {
            currentShowingText = value;
            wordBox.text = currentShowingText;
        }
    }
    private string currentShowingText;
    
    private void Awake()
    {
        wordBox = transform.Find("Word Box").GetComponent<TextMeshProUGUI>();
    }
    private void Start() {
        text = "hahaha\n";
    }


    public void GivenCardUsed(Card card)
    {
        SetNewWord(card.cardInfo.CardFunnyWords);
    }
    public void ClearWord()
    {
        text = "";
    }
    public void SetNewWord(string word)
    {
        text += word + "\n";
    }
}
