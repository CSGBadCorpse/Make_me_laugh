using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedBar : MonoBehaviour
{
    private float timer = 0f;
    [SerializeField,Range(1,100)]public float drawCardTime = 7f;


    public void SubDrawTime(float value)
    {
        if (timer < value) timer = 1f; // cannot be 0
        else
        timer -= value;
    }
    public void AddDrawTime(float value)
    {
        timer += value;
    }


    private Image speedBarImage;
    // Start is called before the first frame update
    void Awake()
    {
        speedBarImage = transform.Find("SpeedBar").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        timer+=Time.deltaTime;
        speedBarImage.fillAmount = timer / drawCardTime;
        if(timer >= drawCardTime)
        {
            timer = 0f;
            speedBarImage.fillAmount = 0f;
            Player.Instance.DrawCard();
        }
    }
}
