using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedBar : MonoBehaviour
{
    private float timer = 0f;
    public float drawCardTime = 7f;


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
            // Player.Instance.DrawCard();
        }
    }
}
