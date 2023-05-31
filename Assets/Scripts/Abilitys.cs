using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilitys : MonoBehaviour
{
    public MainMenu mainMenu;
    public HealthManager healthManager;
    public Image heavyStrike;
    public Image enhancement;
    public float heavyStrikeMultiplikator;
    public int enhancementMultiplikator;
    public int warMultiplikator;
    bool heavyAvailable = true;
    bool enhAvailable = true;
    bool warAvailable = true;
    //Heavy strike cooldowns
    float heavyCooldown = 10.0f;
    float actualHeavyCooldown = 0.0f;
    //Enhancement cooldown
    float enhancementCooldown = 60.0f;
    float actualEnhancementCooldown = 0.0f;
    //War Cry cooldown
    float warCryCooldown = 60.0f;
    float actualWarCryCooldown = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EverySecond());
        enhancementMultiplikator = 3;
        heavyStrikeMultiplikator = 10;
    }

    // Update is called once per frame
    void Update()
    {
        heavyStrike.fillAmount = actualHeavyCooldown / heavyCooldown;
        enhancement.fillAmount = actualEnhancementCooldown / enhancementCooldown;
    }
    //Global cooldown timer
    IEnumerator EverySecond()
    {
        while (true)
        {
            Debug.Log(actualHeavyCooldown);
            if (actualHeavyCooldown > 0.0f)
            {
                actualHeavyCooldown -= 1.0f;
            }
            if (actualEnhancementCooldown > 0.0f)
            {
                actualEnhancementCooldown -= 1.0f;
            }
            yield return new WaitForSeconds(1);
        }
    }
    //Heavy strike function
    public void HeavyStrike ()
    {
        if (heavyAvailable)
        {
            healthManager.TakeDamage(mainMenu.tapDamage * heavyStrikeMultiplikator);
            StartCoroutine(StartCooldown(heavyCooldown, 1));
        }
    }
    //Enhancement function
    public void Enhancement()
    {
        if (enhAvailable)
        {
            mainMenu.tapDamage *= enhancementMultiplikator;
            StartCoroutine(StartCooldown(enhancementCooldown, 2));
        }
    }

    public void WarCry ()
    {

    }
    //Cooldown start
    public IEnumerator StartCooldown(float coolDown, int type)
    {
        switch (type)
        {
            case 1:
                heavyAvailable = false;
                actualHeavyCooldown = coolDown;
                yield return new WaitForSeconds(coolDown);
                heavyAvailable = true;
                break;
            case 2:
                enhAvailable = false;
                actualEnhancementCooldown = coolDown;
                yield return new WaitForSeconds(coolDown);
                mainMenu.tapDamage /= enhancementMultiplikator;
                enhAvailable = true;
                break;
            case 3:
                actualWarCryCooldown = coolDown;
                break;
        }
        
    }
}
