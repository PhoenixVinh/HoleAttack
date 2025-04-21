using System;
using DG.Tweening;
using UnityEngine;

public class ZoomOutBtn : MonoBehaviour
{
    public float time = 0.5f;
    
    

    private void OnEnable()
    {
        AnimationGameObjectZoomOut();
    }

    private void AnimationGameObjectZoomOut()
    {
        var targetLocalScale = transform.localScale;
        transform.localScale = Vector3.zero;
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(targetLocalScale * 1.1f, time));
        sequence.Append(transform.DOScale(targetLocalScale, 0.1f));
        sequence.SetUpdate(true);
        sequence.Play();
       

    }

   
}