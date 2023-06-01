using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradesMenu : MonoBehaviour
{
    public GameObject heroUpgradeMenu;
    public GameObject charaktersUpgradeMenu;
    public GameObject mainUI;
    public GameObject messageField;
    public TMP_Text messageFieldText;
    public TMP_Text damage;
    public TMP_Text passiveDamage;
    public MainMenu mainMenu;
    public Abilitys abilitys;
    public Charakters charakters;
    //Hero Upgrades
    public TMP_Text heroUpText;
    public TMP_Text heroLevelText;
    public float heroUpgradeCost;
    public int heroUpgradeLevel;
    //Heavy Strike Upgrades
    public TMP_Text heavyUpText;
    public TMP_Text heavyLevelText;
    public float heavyUpgradeCost;
    public int heavyUpgradeLevel;
    //Enhancement Upgrades
    public TMP_Text enhUpText;
    public TMP_Text enhLevelText;
    public float enhUpgradeCost;
    public int enhUpgradeLevel;
    //War cry Upgrades
    public TMP_Text warUpText;
    public TMP_Text warLevelText;
    public float warUpgradeCost;
    public int warUpgradeLevel;
    //First Char Upgrade
    public TMP_Text jabaUpText;
    public TMP_Text jabaLevelText;
    public float jabaUpgradeCost;
    public int jabaUpgradeLevel;
    //Second Char Upgrade
    public TMP_Text hokkyUpText;
    public TMP_Text hokkyLevelText;
    public float hokkyUpgradeCost;
    public int hokkyUpgradeLevel;
    //Trith Char Upgrade
    public TMP_Text arnoldUpText;
    public TMP_Text arnoldLevelText;
    public float arnoldUpgradeCost;
    public int arnoldUpgradeLevel;
    // Start is called before the first frame update
    void Start()
    {
        //Start Hero variables
        heroUpgradeLevel = 1;
        heroUpgradeCost = 10;
        heavyUpgradeLevel = 1;
        heavyUpgradeCost = 30;
        enhUpgradeLevel = 1;
        enhUpgradeCost = 50;
        warUpgradeLevel = 1;
        warUpgradeCost = 70;
        //Start Charakters variables
        jabaUpgradeLevel = 1;
        jabaUpgradeCost = 20;
        hokkyUpgradeLevel = 1;
        hokkyUpgradeCost = 50;
        arnoldUpgradeLevel = 1;
        arnoldUpgradeCost = 100;
    }

    // Update is called once per frame
    void Update()
    {
        damage.text = $"DMG:{mainMenu.tapDamage}";
        passiveDamage.text = $"DMG:{charakters.passiveDmg}";
    }
    //HERO MENU
    public void OpenHeroUpgradeMenu ()
    {
        if (!heroUpgradeMenu.activeSelf)
        {
            heroUpgradeMenu.SetActive(true);
        }
        else
        {   
            heroUpgradeMenu.SetActive(false);
        }
        if (charaktersUpgradeMenu.activeSelf)
        {
            charaktersUpgradeMenu.SetActive(false);
        }
        heroUpText.text = $"UP:{(int)heroUpgradeCost}";
        heavyUpText.text = $"UP:{(int)heavyUpgradeCost}";
        enhUpText.text = $"UP:{(int)enhUpgradeCost}";
        warUpText.text = $"UP:{(int)warUpgradeCost}";
    }
    public void UpgradeHero()
    {
        if (mainMenu.money < (int)heroUpgradeCost)
        {
            messageField.SetActive(true);
            messageFieldText.text = $"You don't have enough money";
        } else
        {
            mainMenu.money -= (int)heroUpgradeCost;
            mainMenu.tapDamage += 5;
            heroUpgradeLevel += 1;
            heroUpgradeCost *= 1.2f;
            heroUpText.text = $"UP:{(int)heroUpgradeCost}";
            heroLevelText.text = $"Hero LV.{heroUpgradeLevel}";
        }  
    }
    public void UpgradeHeavyStrike()
    {
        if (mainMenu.money < (int)heavyUpgradeCost)
        {
            messageField.SetActive(true);
            messageFieldText.text = $"You don't have enough money";
        }
        else
        {
            mainMenu.money -= (int)heavyUpgradeCost;
            abilitys.heavyStrikeMultiplikator += 1;
            heavyUpgradeLevel += 1;
            heavyUpgradeCost *= 1.2f;
            heavyUpText.text = $"UP:{(int)heavyUpgradeCost}";
            heavyLevelText.text = $"Heavy strike LV.{heavyUpgradeLevel}";
        }
    }
    public void UpgradeEnhancement()
    {
        if (mainMenu.money < (int)enhUpgradeCost)
        {
            messageField.SetActive(true);
            messageFieldText.text = $"You don't have enough money";
        }
        else
        {
            mainMenu.money -= (int)enhUpgradeCost;
            abilitys.enhancementMultiplikator += 1;
            enhUpgradeLevel += 1;
            enhUpgradeCost *= 1.2f;
            enhUpText.text = $"UP:{(int)enhUpgradeCost}";
            enhLevelText.text = $"Enhancement LV.{enhUpgradeLevel}";
        }
    }
    public void UpgradeWarCry()
    {
        if (mainMenu.money < (int)warUpgradeCost)
        {
            messageField.SetActive(true);
            messageFieldText.text = $"You don't have enough money";
        }
        else
        {
            mainMenu.money -= (int)warUpgradeCost;
            abilitys.warMultiplikator += 1;
            warUpgradeLevel += 1;
            warUpgradeCost *= 1.2f;
            warUpText.text = $"UP:{(int)warUpgradeCost}";
            warLevelText.text = $"War Cry LV.{warUpgradeLevel}";
        }
    }
    //CHARAKTERS MENU
    public void OpenCharaktersUpgradeMenu()
    {
        if (!charaktersUpgradeMenu.activeSelf)
        {
            charaktersUpgradeMenu.SetActive(true);
        }
        else
        {
            charaktersUpgradeMenu.SetActive(false);
        }
        if (heroUpgradeMenu.activeSelf)
        {
            heroUpgradeMenu.SetActive(false);
        }
        jabaUpText.text = $"UP:{(int)jabaUpgradeCost}";
        hokkyUpText.text = $"UP:{(int)hokkyUpgradeCost}";
        arnoldUpText.text = $"UP:{(int)arnoldUpgradeCost}";
    }
    public void UpgradeJaba()
    {
        if (mainMenu.money < (int)jabaUpgradeCost)
        {
            messageField.SetActive(true);
            messageFieldText.text = $"You don't have enough money";
        }
        else
        {
            mainMenu.money -= (int)jabaUpgradeCost;
            charakters.passiveDmg += 3;
            jabaUpgradeLevel += 1;
            jabaUpgradeCost *= 1.2f;
            jabaUpText.text = $"UP:{(int)jabaUpgradeCost}";
            jabaLevelText.text = $"Jaba LV.{jabaUpgradeLevel}";
        }
    }

    public void UpgradeHokky()
    {
        if (mainMenu.money < (int)hokkyUpgradeCost)
        {
            messageField.SetActive(true);
            messageFieldText.text = $"You don't have enough money";
        }
        else
        {
            mainMenu.money -= (int)hokkyUpgradeCost;
            charakters.passiveDmg += 5;
            hokkyUpgradeLevel += 1;
            hokkyUpgradeCost *= 1.2f;
            hokkyUpText.text = $"UP:{(int)hokkyUpgradeCost}";
            hokkyLevelText.text = $"Hokky LV.{hokkyUpgradeLevel}";
        }
    }
    public void UpgradeArnold()
    {
        if (mainMenu.money < (int)arnoldUpgradeCost)
        {
            messageField.SetActive(true);
            messageFieldText.text = $"You don't have enough money";
        }
        else
        {
            mainMenu.money -= (int)arnoldUpgradeCost;
            charakters.passiveDmg += 10;
            arnoldUpgradeLevel += 1;
            arnoldUpgradeCost *= 1.2f;
            arnoldUpText.text = $"UP:{(int)arnoldUpgradeCost}";
            arnoldLevelText.text = $"Arnold LV.{arnoldUpgradeLevel}";
        }
    }
    public void CloseMessageField()
    {
        messageField.SetActive(false);
    }
}
