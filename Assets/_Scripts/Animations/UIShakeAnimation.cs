using UnityEngine;
using DG.Tweening;

public class UIShakeAnimation : AAnimation
{
    [SerializeField] float duration = 2f;
    [SerializeField] float strength = 0.2f;
    [SerializeField] int vibrato = 2;
    [SerializeField] float randomness = 0.2f;
    [SerializeField] bool fadeOut = true;

    [SerializeField] int numLoops = -1;
    [SerializeField] float pauseDuration = 0f;

    [SerializeField] RectTransform rectTransform;

    ShakeRandomnessMode randomnessMode = ShakeRandomnessMode.Harmonic;
    Quaternion originalRotation;

    void Awake()
    {
        if(rectTransform == null)
            rectTransform = GetComponent<RectTransform>();

        originalRotation = rectTransform.localRotation;
    }

    protected override void Animate()
    {
        sequence = DOTween.Sequence();
        sequence.Append(rectTransform.DOShakeRotation(duration, strength, vibrato, randomness, fadeOut, randomnessMode));
        sequence.AppendInterval(pauseDuration);
        sequence.SetLoops(numLoops);
        sequence.Play();
    }

    protected override void Reset()
    {
        rectTransform.localRotation = originalRotation;
    }
}
