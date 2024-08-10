using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Singleton;
using DG.Tweening;

public class GameManager : Singleton<GameManager>
{
   [Header("Player")]
   public GameObject player;

   [Header("Enemies")]
   public List<GameObject> enemies;

   //[Header("References")]
   
   //public Transform startPoint;
   //private GameObject _currentPlayer;
   //public float duration = .2f;
   //public float delay = .05f;
   //public Ease ease = Ease.OutBack;

public void Start(){
    Init();
}

public void Init(){
    //SpawnPlayer();

}

/*private void SpawnPlayer(){

    
    _currentPlayer = Instantiate(player);
    _currentPlayer.transform.position = startPoint.transform.position;
    _currentPlayer.transform.DOScale(0, duration).SetEase(ease).From().SetDelay(delay);
}*/

}
