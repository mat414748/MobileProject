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
        actualMonster = spawner.ChangeEnemy(deathCounter);
        deathCounter = 1;
        stageCounter = 1;
        killReward = 10;
        tapDamage = 10;
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
            //PlayerPrefs.SetInt
            //PlayerPrefs.GetInt
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
