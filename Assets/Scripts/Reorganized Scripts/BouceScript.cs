using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BouceScript : MonoBehaviour
{

    public Ease ease = Ease.OutBack;
    public Ease ease2 = Ease.OutBack;
    
public virtual void Bounce(Transform target, Vector3 endScale, float duration)
    {
        if (target == null)
        {
            Debug.LogError("Target transform is not assigned.");
            return;
        }
        target.DOScale(endScale,duration);
    } 

public virtual void BouceYoyo(Transform target, float scaleBounce, float duration){

    if (target == null)
        {
            Debug.LogError("Target transform is not assigned.");
            return;
        }
        target.DOScale(scaleBounce,duration).SetEase(ease).SetLoops(2, LoopType.Yoyo);
}



}
