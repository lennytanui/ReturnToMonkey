using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private health playerHealth;
    [SerializeField] private Image HealthBarTotal;
    [SerializeField] private Image HealthBarCurrent;
    // Start is called before the first frame update
    void Start()
    {
        HealthBarTotal.fillAmount = playerHealth.currentHealth / 10;
    }

    // Update is called once per frame
    private void Update()
    {
        HealthBarCurrent.fillAmount = (playerHealth.currentHealth) / 10;
    }

}
