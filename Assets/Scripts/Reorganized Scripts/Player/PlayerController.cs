using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2 pastPosition;
    public float velocity = 1f;
    public float velocityForward = 1f;
    public string tagToCheckEnemy = "Obstaculo";
    public string tagToEndGame = "EndGame";
    private bool _canRun;
    public GameObject RestartScene;
   
    // Update is called once per frame
    
    void Start(){
        _canRun = true;
        RestartScene.SetActive(false);
    }
    
    void Update()
    {
        
        if(!_canRun) return;

        transform.Translate(transform.forward * velocityForward * Time.deltaTime );
        
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
        _canRun = false;
        RestartScene.SetActive(true);
        } 

        if(collision.transform.CompareTag(tagToEndGame)){
            _canRun = false;
            RestartScene.SetActive(true);
        }
    }


    

}
