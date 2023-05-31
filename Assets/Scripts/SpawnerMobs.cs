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
    public int ChangeEnemy(int deathCounter)
    {
        int random = Random.Range(0, mobs.Length);
        if (deathCounter == 9)
        {
            mobs[random].transform.localPosition += new Vector3(0, 0.5f, 0);
            if (mobs[random].name == "Skeleton")
            {
                mobs[random].transform.localScale += new Vector3(1, 1, 1);
            }
            else
            {
                mobs[random].transform.localScale += new Vector3(2, 2, 1);
            }       
        }
        mobs[random].SetActive(true);
        return random;
    }
    public void DestroyEnemy(int deadMonster)
    {
        if (mobs[deadMonster].transform.localPosition.y > 0)
        {
            mobs[deadMonster].transform.localPosition -= new Vector3(0, 0.5f, 0);
        }
        if (mobs[deadMonster].name == "Skeleton")
        {
            mobs[deadMonster].transform.localScale = new Vector3(2.5f, 2.5f, 1);
        }
        else
        {
            mobs[deadMonster].transform.localScale = new Vector3(3, 3, 1);
        }
        mobs[deadMonster].SetActive(false);
    }
    public void SwapStage(int stage) 
    {
        previoslyStage.text = $"S{stage - 1}";
        actualStage.text = $"S{stage}";
        nextStage.text = $"S{stage + 1}";
    }
}
