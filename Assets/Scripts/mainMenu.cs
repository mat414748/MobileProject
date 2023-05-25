using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class mainMenu : MonoBehaviour
{
    int money;
    public TMP_Text moneyText;
    public void ButtonClick()
    { 
        money++;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = $"Money: {money.ToString()}";
    }
}
