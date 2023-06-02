using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charakters : MonoBehaviour
{
    public int passiveDmg;
    public HealthManager healthManager;
    public Abilitys abilitys;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("PassDmg") == 0)
        {
            passiveDmg = 0;
        }
        else
        {
            passiveDmg = PlayerPrefs.GetInt("PassDmg");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DealPassiveDamage()
    { 
        healthManager.TakeDamage(passiveDmg);
    }
    
}
