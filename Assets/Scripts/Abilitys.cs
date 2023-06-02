using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilitys : MonoBehaviour
{
    public MainMenu mainMenu;
    public HealthManager healthManager;
    public Charakters charakters;
    public Image heavyStrike;
    public Image enhancement;
    public Image warCry;
    public int heavyStrikeMultiplikator;
    public int enhancementMultiplikator;
    public int warMultiplikator;
    bool heavyAvailable = true;
    public bool enhAvailable = true;
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
        //Enh multiplicator
        if (PlayerPrefs.GetInt("EnhMulti") == 0)
        {
            enhancementMultiplikator = 3;
        }
        else
        {
            enhancementMultiplikator = PlayerPrefs.GetInt("EnhMulti");
        }
        //War multiplicator
        if (PlayerPrefs.GetInt("WarMulti") == 0)
        {
            warMultiplikator = 3;
        }
        else
        {
            warMultiplikator = PlayerPrefs.GetInt("WarMulti");
        }
        //Heavy multiplicator
        if (PlayerPrefs.GetInt("HeavyMulti") == 0)
        {
            heavyStrikeMultiplikator = 10;
        }
        else
        {
            heavyStrikeMultiplikator = PlayerPrefs.GetInt("HeavyMulti");
        }
    }

    // Update is called once per frame
    void Update()
    {
        heavyStrike.fillAmount = actualHeavyCooldown / heavyCooldown;
        enhancement.fillAmount = actualEnhancementCooldown / enhancementCooldown;
        warCry.fillAmount = actualWarCryCooldown / warCryCooldown;
    }
    //Global cooldown timer
    IEnumerator EverySecond()
    {
        while (true)
        {
            charakters.DealPassiveDamage();
            if (actualHeavyCooldown > 0.0f)
            {
                actualHeavyCooldown -= 1.0f;
            }
            if (actualEnhancementCooldown > 0.0f)
            {
                actualEnhancementCooldown -= 1.0f;
            }
            if (actualWarCryCooldown > 0.0f)
            {
                actualWarCryCooldown -= 1.0f;
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
        if (warAvailable)
        {
            
            charakters.passiveDmg *= warMultiplikator;
            StartCoroutine(StartCooldown(warCryCooldown, 3));
        }
    }
    //Cooldown start
    public IEnumerator StartCooldown(float coolDown, int type)
    {
        int staticMultiplikator;
        int staticDamage;
        int difference;
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
                staticMultiplikator = enhancementMultiplikator;
                staticDamage = mainMenu.tapDamage;
                yield return new WaitForSeconds(20.0f);
                difference = mainMenu.tapDamage - staticDamage;
                staticDamage /= staticMultiplikator;
                mainMenu.tapDamage = staticDamage + difference;
                yield return new WaitForSeconds(coolDown-20.0f);
                enhAvailable = true;
                break;
            case 3:
                warAvailable = false;
                actualWarCryCooldown = coolDown;
                staticMultiplikator = warMultiplikator;
                staticDamage = charakters.passiveDmg;
                yield return new WaitForSeconds(20.0f);
                difference = charakters.passiveDmg - staticDamage;
                staticDamage /= staticMultiplikator;
                charakters.passiveDmg = staticDamage + difference;
                yield return new WaitForSeconds(coolDown-20.0f);
                warAvailable = true;
                break;
        }
        
    }
}
