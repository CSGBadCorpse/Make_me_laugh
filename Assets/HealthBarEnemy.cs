using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarEnemy : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    private Image healthBarImage;

    private void Awake()
    {
        healthBarImage = transform.Find("HealthBar").GetComponent<Image>();
        enemy.onHealthChanged.AddListener(UpdateFillAmount);
    }

    private void OnDestroy() {
        enemy.onHealthChanged.RemoveListener(UpdateFillAmount);
    }

    private void UpdateFillAmount(int hpCur, int hpMax)
    {
        healthBarImage.fillAmount = (float)hpCur / hpMax;
    }
}
