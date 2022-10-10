using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HooverAnimation : MonoBehaviour
{
    [SerializeField] float distance = 0.2f;
    [SerializeField] float duration = 0.2f;
    [SerializeField] Ease ease;

    Vector2 originalPosition;

    void Awake()
    {
        originalPosition = transform.localPosition;
    }

    void Start()
    {
        transform
            .DOLocalMoveY(originalPosition.y + distance, duration)
            .SetEase(ease)
            .SetLoops(-1, LoopType.Yoyo);
    }

    void OnDisable()
    {
        DOTween.Kill(transform);
    }
}
