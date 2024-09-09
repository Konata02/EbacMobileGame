using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBase : MonoBehaviour
{
    public string compareTag = "Player";
    public ParticleSystem collectParticleSystem;

    //[Header("Sounds")]
    //public AudioSource audioSource;

  
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        Debug.Log("Moeda Coletada");
        OnCollected();
        Invoke("DeactivateGameObject", 0.5f);
        
       
    }

    protected virtual void OnCollected()
    {
        if(collectParticleSystem != null) { 
            collectParticleSystem.Play();
        }
        //if(audioSource != null){
        //    audioSource.Play();
        //}
               
    }

    void DeactivateGameObject()
    {
        Destroy(gameObject);
    }

}

