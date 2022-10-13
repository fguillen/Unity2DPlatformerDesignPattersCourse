using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public abstract class AAnimation : MonoBehaviour
{
    [SerializeField] protected bool onAwake = false;

    protected Sequence sequence;
    protected bool playing = false;

    void Start()
    {
        if(onAwake)
            Play();
    }

    public void Play()
    {
        KillSequence();
        Reset();

        Animate();

        playing = true;
    }

    protected abstract void Animate();

    void KillSequence()
    {
        sequence?.Kill();
    }

    protected abstract void Reset();

    void OnDestroy()
    {
        KillSequence();
    }

    void OnValidate()
    {
        if(playing)
            Play();
    }
}
