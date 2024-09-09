using UnityEngine;
using DG.Tweening; 

public class PulsatingEffect : MonoBehaviour
{
    public float duration = 1f;
    public float scaleFactor = 0.5f; 

    void Start()
    {
        
        Pulsate();
    }

    void Pulsate()
    {
        // Obtemos o tamanho original do objeto
        Vector3 originalScale = transform.localScale;

        // Cria uma sequência de animações
        Sequence pulseSequence = DOTween.Sequence();

        // Adiciona uma animação de escala para diminuir
        pulseSequence.Append(transform.DOScale(originalScale * scaleFactor, duration)
            .SetEase(Ease.InOutSine));

        // Adiciona uma animação de escala para crescer novamente
        pulseSequence.Append(transform.DOScale(originalScale, duration).SetEase(Ease.InOutSine));

        // Define o loop infinito
        pulseSequence.SetLoops(-1, LoopType.Yoyo);
    }
}