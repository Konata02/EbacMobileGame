using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    
    public float timeToReset = 5f;
    public Vector3 dir;
    public float side = 1;
    public int damageAmount = 1; 


    // Start is called before the first frame update
     public void StartProjectile()
    {
        Invoke(nameof(FinishUsage),timeToReset);        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * Time.deltaTime * side);
    }

    private void FinishUsage(){
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        var enemy = collision.transform.GetComponent<EnemyBase>();
        if (enemy != null){
            enemy.Damage(damageAmount);
            gameObject.SetActive(false);
        }
    }

}
