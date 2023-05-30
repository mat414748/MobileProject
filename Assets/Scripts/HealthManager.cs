using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 50;
    public float maxHealthAmount;

    // Start is called before the first frame update
    void Start()
    {
        maxHealthAmount = healthAmount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / maxHealthAmount;
    }
    public void RecoveryHealth() 
    {
        healthAmount = maxHealthAmount;
        healthBar.fillAmount = healthAmount / maxHealthAmount;
    }
}
