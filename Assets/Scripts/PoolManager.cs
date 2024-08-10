using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
   public GameObject prefab;
   public List<GameObject> objectlist;
   public int amount = 20;


    private void Awake(){

        StartPool();
    }

   private void StartPool(){
    objectlist = new List<GameObject>();

    for (int i =0; i<amount; i++){
        var obj = Instantiate(prefab, transform);
        obj.SetActive(false);
        objectlist.Add(obj);
    }
   }

   public GameObject GetPooledObject(){

    for (int i =0; i<amount; i++){
        if (!objectlist[i].activeInHierarchy){
            return objectlist[i];
        }
    }

    return null;
    
   }

}
