using UnityEngine;
using DG.Tweening;

public class UIScalePulsation : MonoBehaviour
{
    [SerializeField] float finalScale = 2f;
    [SerializeField] float duration = 0.2f;
    [SerializeField] int numLoops = -1;
    [SerializeField] float pauseDuration = 0f;
    [SerializeField] bool onAwake = false;
    [SerializeField] RectTransform rectTransform;

    Vector3 originalScaleV;
    Vector3 finalScaleV;
    Sequence sequence;
    bool initialized = false;

    void Awake()
    {
        if(rectTransform == null)
            rectTransform = GetComponent<RectTransform>();

        originalScaleV = rectTransform.localScale;

        initialized = true;
    }

    void Start()
    {
        if(onAwake)
            Play();
    }

    public void Play()
    {
        KillSequence();
        ResetScale();

        finalScaleV = Vector3.one * finalScale;
        sequence = DOTween.Sequence();
        sequence.Append(rectTransform.DOScale(finalScaleV, duration));
        sequence.Append(rectTransform.DOScale(originalScaleV, duration));
        sequence.AppendInterval(pauseDuration);
        sequence.SetLoops(numLoops);
        sequence.Play();
    }

    void KillSequence()
    {
        sequence?.Kill();
    }

    void ResetScale()
    {
        rectTransform.localScale = originalScaleV;
    }

    void OnDestroy()
    {
        KillSequence();
    }

    void OnValidate()
    {
        if(initialized)
            Play();
    }
}
