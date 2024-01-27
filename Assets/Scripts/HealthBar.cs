using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player player;
    private Image healthBarImage;

    private void Awake()
    {
        healthBarImage = transform.Find("HealthBar").GetComponent<Image>();
        player.onHealthChanged.AddListener(UpdateFillAmount);
    }

    private void OnDestroy() {
        player.onHealthChanged.RemoveListener(UpdateFillAmount);
    }

    private void UpdateFillAmount(int hpCur, int hpMax)
    {
        healthBarImage.fillAmount = (float)hpCur / hpMax;
    }
}
