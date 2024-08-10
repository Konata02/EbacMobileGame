using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ebac.Singleton {

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
   public static T Instance;
   protected bool x1;

   protected virtual void Awake(){
    if (Instance == null){
        Instance = GetComponent<T>();
    }
    else {
        Destroy(gameObject);
    }
}

}

}




