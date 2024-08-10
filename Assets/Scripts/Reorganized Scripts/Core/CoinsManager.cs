using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Singleton;
using TMPro;
using Unity.VisualScripting;

public class CoinsManager : Ebac.Singleton.Singleton<CoinsManager>
{
    public SOInt coins;
    //public TextMeshProUGUI textCoinsCounter;



    protected override void Awake(){
        base.Awake();
        Reset();
        
    }
    
    private void Reset(){
        
        coins.value = 0;
        //UpdateCoinsUI();
    }

    public void AddCoins(int amount = 1){
        
        coins.value  += amount;
        //UpdateCoinsUI();
    }

    /*private void UpdateCoinsUI()
    {
        
        if (textCoinsCounter != null)
        {
            
            textCoinsCounter.text = "X" + " " +  coins.ToString();
            
            
        }
        else
        {
            Debug.LogWarning("Text Coins Counter não atribuído em CoinsManager.");
        }
    }*/

    
    
}
