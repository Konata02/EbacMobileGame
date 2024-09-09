using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PowerUpBase : CollectBase
{
   [Header("Power Up")]    
   public float duration;
   
   
    protected override void Collect()   {        
        base.OnCollected();
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        base.Invoke("DeactivateGameObject", duration);
        renderer.enabled = false;        
        StartPowerUp();    
        }    
    
    protected virtual void StartPowerUp()    {        
        Debug.Log("Start Power Up");        
        Invoke(nameof(EndPowerUp), duration);
        }    
        
        
    protected virtual void EndPowerUp()    {        
            Debug.Log("End Power Up");    
            }


    

}
