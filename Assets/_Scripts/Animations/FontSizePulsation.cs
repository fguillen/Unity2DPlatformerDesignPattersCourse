using UnityEngine;
using DG.Tweening;
using TMPro;

public class FontSizePulsation : MonoBehaviour
{
    [SerializeField] float finalSize = 2f;
    [SerializeField] float duration = 0.2f;
    [SerializeField] int numLoops = -1;
    [SerializeField] bool onAwake = false;
    [SerializeField] TextMeshProUGUI text;

    float originalSize;
    Sequence sequence;

    void Awake()
    {
        if(text == null)
            text = GetComponent<TextMeshProUGUI>();

        originalSize = text.fontSize;
    }

    void Start()
    {
        if(onAwake)
            Play();
    }

    public void Play()
    {
        KillSequence();
        ResetSize();

        sequence = DOTween.Sequence();
        sequence.Append(DOTween.To(() => originalSize, SetSize, finalSize, duration));
        sequence.Append(DOTween.To(() => finalSize, SetSize, originalSize, duration));
        sequence.SetLoops(numLoops);
        sequence.Play();
    }

    void SetSize(float size)
    {
        text.fontSize = size;
    }

    void KillSequence()
    {
        sequence?.Kill();
    }

    void ResetSize()
    {
        text.fontSize = originalSize;
    }

    void OnDestroy()
    {
        KillSequence();
    }
}
