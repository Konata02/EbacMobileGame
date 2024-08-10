
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinsUIUpdate : MonoBehaviour
{
   public SOInt scriptableObject;
   public TextMeshProUGUI textCoinsCounter;

   private void Update()
    {
        
        if (textCoinsCounter != null)
        {
            
            textCoinsCounter.text = "X" + " " +  scriptableObject.value.ToString();
            
            
        }
        else
        {
            Debug.LogWarning("Text Coins Counter não atribuído em CoinsManager.");
        }
    }
}


