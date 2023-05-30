using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Unity.Mathematics;

public class MainMenu : MonoBehaviour
{
    int money;
    public TMP_Text moneyText;
    public Animator animator;
    public SpawnerMobs spawner;
    public HealthManager healthManager; 
    public float normTime;
    public int tapDamage;
    public int actualMonster;
    public int deathCounter;
    public int stageCounter;
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
        actualMonster = spawner.ChangeEnemy();
        stageCounter = 1;
        tapDamage = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthManager.healthAmount <= 0)
        {
            spawner.DestroyEnemy(actualMonster);
            healthManager.RecoveryHealth();
            actualMonster = spawner.ChangeEnemy();
            money += 10;
            deathCounter++;
        }
        animStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        normTime = animStateInfo.normalizedTime;
        if (animStateInfo.IsName("Attack"))
        {
            animator.SetBool("Tap", false);
        }
        moneyText.text = $"Money: {money.ToString()}";
        if (deathCounter == 10)
        {
            stageCounter++;
            spawner.SwapStage(stageCounter);
            deathCounter = 0;
        }
    }
}
