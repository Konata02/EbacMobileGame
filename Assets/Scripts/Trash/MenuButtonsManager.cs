using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuButtonsManager : MonoBehaviour
{
    public List<GameObject> buttons;
    public float duration = .2f;
    public float delay = .05f;
    public Ease ease = Ease.OutBack;

    
    private void Awake(){
        HideAllButtons();
        ShowButtons();
    }    
    
    private void ShowButtons(){

         StartCoroutine(ShowButtonsWithDelay());

    }

    private void HideAllButtons(){
        foreach(var b in buttons){
        b.transform.localScale = Vector3.zero;
        b.SetActive(false);
        }
    }

    IEnumerator ShowButtonsWithDelay(){
        
        foreach(var b in buttons){

            b.SetActive(true);
            b.transform.DOScale(1, duration).SetDelay(buttons.IndexOf(b)*delay).SetEase(ease);
            yield return new WaitForSeconds(delay);
        }
    }
}
