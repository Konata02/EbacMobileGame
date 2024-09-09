using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Singleton;
using DG.Tweening;

public class PlayerController : Singleton<PlayerController>
{
    public Vector2 pastPosition;
    public float velocity = 1f;
    public float velocityForward = 1f;
    private float _currentSpeed;
    public string tagToCheckEnemy = "Obstaculo";
    public string tagToEndGame = "EndGame";
    public string compareTagCollect = "Coin";
    public string compareTagPowerUp = "PowerUp";
    private bool _canRun;
    public GameObject RestartScene;
    public GameObject StartGame;
    public bool invencible = false;
    public Vector3  _startPosition;
    public GameObject coinCollector;
    public AnimatorManager animatorManager;
    public BouceScript bounceScript;
    private Vector3 startScaleChar = new Vector3(0, 0, 0);
     // Update is called once per frame



    
    void Start (){
       _canRun = false;
       animatorManager.Play(AnimatorManager.AnimationType.IDLE); 
       if (bounceScript == null)  Debug.LogError("BounceScript is not assigned.");
       else { bounceScript.Bounce(transform , startScaleChar , 0); }
    }
    
    
    void Update()
    {
        
        if(!_canRun) return;

        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime );
        
        if (Input.GetMouseButton(0)){
            Move(Input.mousePosition.x - pastPosition.x);
        }

        pastPosition = Input.mousePosition;

    }

    public void Move(float speed){
        
        transform.position += Vector3.right * Time.deltaTime * speed * velocity;
    }

    public void StartGameNow(){
        StartGame.SetActive(false);
        _canRun = true;
        animatorManager.Play(AnimatorManager.AnimationType.RUN);
        RestartScene.SetActive(false);
        _startPosition = transform.position;
        bounceScript.Bounce(transform , new Vector3 (1,1,1) , 0.5f);
        ResetSpeed();
    }

    private void OnCollisionEnter (Collision collision){
        
        if(collision.transform.CompareTag(tagToCheckEnemy)){
        
        if(!invencible){
            _canRun = false;
            animatorManager.Play(AnimatorManager.AnimationType.DEAD);
            RestartScene.SetActive(true);
        }
        
        } 

        if(collision.transform.CompareTag(tagToEndGame)){
            _canRun = false;
            RestartScene.SetActive(true);
        }



/*  private void OnCollisionEnter(Collision collision)
    {
        if(other.transform.tag == tagToChecEndLine){
            if(!invencible) EndGame();
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == tagToChecEndLine){
            if(!invencible) EndGame();
        }
    }*/


    }

    private void OnTriggerEnter(Collider collider){
        
        if (collider.transform.CompareTag(compareTagCollect)){
             Debug.LogError("Collect tag.");
            bounceScript.BouceYoyo(transform , 1.2f , .05f);

        }

        

        if(_canRun == true) bounceScript.Bounce(transform , new Vector3 (1,1,1) , 0f);
    }

    
    public void ChangeHeight(float amount, float duration, float animationDuration, Ease ease)
    {
        var p = transform.position;
        p.y = _startPosition.y + amount;
        transform.position = p;
    }

    public void SetPowerUpText(string s)
    {
    //uiTextPowerUp.text = s;
    }
 
    public void PowerUpSpeedUp(float f)
    {
    _currentSpeed = f;
    }
 
    public void ResetSpeed()
    {
    _currentSpeed = velocityForward;
    }

    public void SetInvencible(){
        invencible = !invencible;
    }   

     public void ResetHeight()
    {
        var p = transform.position;
        p.y = _startPosition.y;
        transform.position = p;
    }

    public void ChangeCoinCollectorSize(float amount)
    {
        coinCollector.transform.localScale = Vector3.one * amount;
    }
    

}
