using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HealthImageUI : MonoBehaviour
{
    Image image;
    public UnityEvent OnImageChanged;

    void Awake()
    {
        image = GetComponent<Image>();
    }

    public void SetSprite(Sprite sprite)
    {
        if(image.sprite != sprite)
        {
            image.sprite = sprite;
            OnImageChanged?.Invoke();
        }
    }
}
