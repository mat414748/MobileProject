using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Unity.Mathematics;

public class MainMenu : MonoBehaviour
{
    public TMP_Text moneyText;
    public TMP_Text deathCounterText;
    public Animator animator;
    public SpawnerMobs spawner;
    public HealthManager healthManager; 
    public UpgradesMenu upgradesMenu;
    public Abilitys abilitys;
    public Charakters charakters;
    public float normTime;
    public int money;
    public int tapDamage;
    public int actualMonster;
    public int deathCounter;
    public int stageCounter;
    public int killReward;
    AnimatorStateInfo animStateInfo;
    public void ButtonClick()
    {
        healthManager.TakeDamage(tapDamage);
        animator.SetBool("Tap", false);
        animator.SetBool("Tap", true);
    }
    // Start is called before the first frame update
    void Start()
    {
        //Get kills
        if (PlayerPrefs.GetInt("Kills") == 0)
        {
            deathCounter = 1;
        }
        else
        {
            deathCounter = PlayerPrefs.GetInt("Kills");
            deathCounterText.text = $"Monster {deathCounter}/10";
        }
        //Get stage
        if (PlayerPrefs.GetInt("Stage") == 0)
        {
            stageCounter = 1;
        }
        else
        {
            stageCounter = PlayerPrefs.GetInt("Stage");
            spawner.SwapStage(stageCounter);
        }
        //Get saved reward
        if (PlayerPrefs.GetInt("Reward") == 0)
        {
            killReward = 10;
        }
        else
        {
            killReward = PlayerPrefs.GetInt("Reward");
        }
        //Get saved Damage
        if (PlayerPrefs.GetInt("TapDamage") == 0)
        {
            tapDamage = 10;
        }
        else
        {
            tapDamage = PlayerPrefs.GetInt("TapDamage");
        }
         
        money = PlayerPrefs.GetInt("Money");      
    }

    // Update is called once per frame
    void Update()
    {
        if (healthManager.healthAmount <= 0)
        {
            spawner.DestroyEnemy(actualMonster);
            healthManager.RecoveryHealth();
            actualMonster = spawner.ChangeEnemy(deathCounter);
            if (deathCounter == 9) healthManager.UpHealth(true);
            if (deathCounter == 10)
            {
                healthManager.healthAmount /= 3;
                money += killReward * 10;
            } 
            else
            {
                money += killReward;
            }
            deathCounter++;
            deathCounterText.text = $"Monster {deathCounter}/10";
            PlayerPrefs.SetInt("Money", money);
            PlayerPrefs.SetInt("TapDamage", upgradesMenu.heroUpgradeLevel * 5 + 10);
            PlayerPrefs.SetInt("Reward", killReward);
            PlayerPrefs.SetInt("Kills", deathCounter);
            PlayerPrefs.SetInt("Stage", stageCounter);
            PlayerPrefs.SetInt("HeroLevel", upgradesMenu.heroUpgradeLevel);
            PlayerPrefs.SetFloat("HeroUp", upgradesMenu.heroUpgradeCost);
            PlayerPrefs.SetInt("HeavyLevel", upgradesMenu.heavyUpgradeLevel);
            PlayerPrefs.SetFloat("HeavyUp", upgradesMenu.heavyUpgradeCost);
            PlayerPrefs.SetInt("EnhLevel", upgradesMenu.enhUpgradeLevel);
            PlayerPrefs.SetFloat("EnhUp", upgradesMenu.enhUpgradeCost);
            PlayerPrefs.SetInt("WarLevel", upgradesMenu.warUpgradeLevel);
            PlayerPrefs.SetFloat("WarUp", upgradesMenu.warUpgradeCost);
            PlayerPrefs.SetInt("JabaLevel", upgradesMenu.jabaUpgradeLevel);
            PlayerPrefs.SetFloat("JabaUp", upgradesMenu.jabaUpgradeCost);
            PlayerPrefs.SetInt("HokkyLevel", upgradesMenu.hokkyUpgradeLevel);
            PlayerPrefs.SetFloat("HokkyUp", upgradesMenu.hokkyUpgradeCost);
            PlayerPrefs.SetInt("ArnoldLevel", upgradesMenu.arnoldUpgradeLevel);
            PlayerPrefs.SetFloat("ArnoldUp", upgradesMenu.arnoldUpgradeCost);
            PlayerPrefs.SetInt("EnhMulti", abilitys.enhancementMultiplikator);
            PlayerPrefs.SetInt("WarMulti", abilitys.warMultiplikator);
            PlayerPrefs.SetInt("HeavyMulti", abilitys.heavyStrikeMultiplikator);
            PlayerPrefs.SetInt("PassDmg", charakters.passiveDmg);
        }
        animStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (animStateInfo.IsName("Attack"))
        {
            animator.SetBool("Tap", false);
        }
        moneyText.text = $"Money: {money.ToString()}";
        if (deathCounter == 11)
        {
            Debug.Log("Skip");
            stageCounter++;
            spawner.SwapStage(stageCounter);
            deathCounter = 1;
            deathCounterText.text = $"Monster {deathCounter}/10";
            killReward += 5;
            healthManager.UpHealth(false);
        }
        
    }
}
