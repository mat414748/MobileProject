using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public TMP_Text healtText;
    public float healthAmount = 50;
    public float maxHealthAmount;

    // Start is called before the first frame update
    void Start()
    {
        maxHealthAmount = healthAmount;
        healtText.text = $"HP:{healthAmount}/{maxHealthAmount}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / maxHealthAmount;
        healtText.text = $"HP:{healthAmount}/{maxHealthAmount}";
    }
    public void RecoveryHealth() 
    {
        healthAmount = maxHealthAmount;
        healthBar.fillAmount = healthAmount / maxHealthAmount;
        healtText.text = $"HP:{healthAmount}/{maxHealthAmount}";
    }
    public void UpHealth(bool boss)
    {
        if (boss)
        {
            healthAmount *= 3;
        }
        else
        {
            healthAmount += 50;
        }
        maxHealthAmount = healthAmount;
        healtText.text = $"HP:{healthAmount}/{maxHealthAmount}";
    }
}
