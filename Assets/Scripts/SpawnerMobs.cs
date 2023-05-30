using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnerMobs : MonoBehaviour
{
    public GameObject[] mobs;
    public GameObject skeleton;
    public GameObject mushroom;
    public GameObject goblin;
    public GameObject bat;
    public TMP_Text previoslyStage;
    public TMP_Text actualStage;
    public TMP_Text nextStage;
    // Start is called before the first frame update
    void Start()
    {
        mobs = new GameObject[4];
        mobs[0] = skeleton;
        mobs[1] = mushroom;
        mobs[2] = goblin;
        mobs[3] = bat;
    }
    public int ChangeEnemy()
    {
        int random = Random.Range(0, mobs.Length);
        mobs[random].SetActive(true);
        return random;
    }
    public void DestroyEnemy(int deadMonster)
    {
        mobs[deadMonster].SetActive(false);
    }
    public void SwapStage(int stage) 
    {
        previoslyStage.text = $"S{stage - 1}";
        actualStage.text = $"S{stage}";
        nextStage.text = $"S{stage + 1}";
    }
}
