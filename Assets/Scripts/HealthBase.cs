using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    
    public int startLife = 10;
    private int _currentLife;
    public bool destroyOnKill = false;
    private bool _isDead = false;
    public Animator ANIM_Player;
    public string ani_death = "death";
    public float delayToKill = 0f;
    //public Action OnKill;
    
    private void Awake(){
        Init();

       /* if(healthBase != null){
            healthBase.OnKill += OnEnemyKill();
        }*/

    }

    private void OnEnemyKill(){

    }

    private void Init(){
        _isDead = false;
        _currentLife = startLife;
    }

    public void Damage(int damage){
        
        if (_isDead) return;

        _currentLife -= damage;

        if(_currentLife <=0){
            Kill();
        }
    }

    private void Kill(){
        _isDead = true;

        if(destroyOnKill){
        ANIM_Player.SetTrigger(ani_death);
         Destroy(gameObject,delayToKill);
        }
        //OnKill.Invoke();
    
    }

}
