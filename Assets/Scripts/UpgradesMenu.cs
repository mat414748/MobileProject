using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradesMenu : MonoBehaviour
{
    public GameObject heroUpgradeMenu;
    public GameObject mainUI;
    public GameObject messageField;
    public TMP_Text messageFieldText;
    public MainMenu mainMenu;
    public Abilitys abilitys;
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
    // Start is called before the first frame update
    void Start()
    {
        heroUpgradeLevel = 1;
        heroUpgradeCost = 10;
        heavyUpgradeLevel = 1;
        heavyUpgradeCost = 30;
        enhUpgradeLevel = 1;
        enhUpgradeCost = 50;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
        heroUpText.text = $"UP:{(int)heroUpgradeCost}";
        heavyUpText.text = $"UP:{(int)heavyUpgradeCost}";
        enhUpText.text = $"UP:{(int)enhUpgradeCost}";
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
            enhLevelText.text = $"Heavy strike LV.{enhUpgradeLevel}";
        }
    }
    public void CloseMessageField()
    {
        messageField.SetActive(false);
    }
}
