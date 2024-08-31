using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour
{
   public void Load(int i){
        SceneManager.LoadScene(i);
   }

   public void Load(string i){
        SceneManager.LoadScene(i);
   }


}
