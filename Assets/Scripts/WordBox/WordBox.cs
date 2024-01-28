using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WordBox : MonoBehaviour
{
    private TextMeshProUGUI wordBox;
    private Scrollbar scrollbar;
    private string text
    {
        get => currentShowingText;
        set
        {
            currentShowingText = value;
            wordBox.text = currentShowingText;
            StartCoroutine(ScrollToBottom());
        }
    }
    private string currentShowingText;
    
    private void Awake()
    {
        wordBox = transform.Find("Scroll View/Viewport/Word Box").GetComponent<TextMeshProUGUI>();
        scrollbar = transform.Find("Scroll View/Scrollbar Vertical").GetComponent<Scrollbar>();
    }
    private void Start() {
        text = "闲言碎语\n";
    }

    private IEnumerator ScrollToBottom()
    {
        bool isFinished = false;
        if (isFinished)
        {
            yield break;
        }

        float lerpTimer = 0;
        while(lerpTimer<=1)
        {
            scrollbar.value = Mathf.Lerp(scrollbar.value,0,lerpTimer);
            lerpTimer+=Time.deltaTime * 1;
            yield return null;
        }
        isFinished = true;
    }


    public void GivenCardUsed(Card card)
    {
        SetNewWord(card.cardInfo.CardFunnyWords == "" ? "Use card: "+card.cardInfo.CardName+" !" : card.cardInfo.CardFunnyWords);
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
