using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class SOPlayerController : ScriptableObject
{
    public Vector2 friction = new Vector2(.1f,0);
    //public Animator ANIM_player;
    public float speed;
    public float speedRun; 
    public float forceJump = 2;
   
    public bool _isrunning = false;



 
}
