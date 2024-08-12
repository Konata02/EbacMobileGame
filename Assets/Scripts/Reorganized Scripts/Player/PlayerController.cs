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
    private bool _canRun;
    public GameObject RestartScene;
    public bool invencible = false;
    public Vector3  _startPosition;
    public GameObject coinCollector;

   
    // Update is called once per frame



    
    void Start(){
        _canRun = true;
        RestartScene.SetActive(false);
        _startPosition = transform.position;
        ResetSpeed();
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

    private void OnCollisionEnter (Collision collision){
        
        if(collision.transform.CompareTag(tagToCheckEnemy)){
        
        if(!invencible){
            _canRun = false;
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
