using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class AudioPlayerHelper : MonoBehaviour
{
    
    public KeyCode keycode = KeyCode.P;
    public AudioSource audioSource;
    
    public AudioSource ambience;
    
    private void Awake(){

        ambience.Play();
    
    }
    
    public void PlayRun(){
        audioSource.Play();
    }
    
    //public void PlayJump(){
        //audioSourceJump.Play();
    //}
}
