using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using DG.Tweening;

public class Cloud : MonoBehaviour
{
    [SerializeField] List<Sprite> sprites;
    [SerializeField] float speedMin = 10f;
    [SerializeField] float speedMax = 20f;
    [SerializeField] float scaleMin = 0.1f;
    [SerializeField] float scaleMax = 3f;

    [SerializeField] BoxCollider2D respawnCollider;

    Image image;
    RectTransform imageRectTransform;
    float speed;
    float scale;

    void Awake()
    {
        image = GetComponentInChildren<Image>();
        imageRectTransform = image.GetComponent<RectTransform>();
        respawnCollider = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        image.sprite = sprites[Random.Range(0, sprites.Count)];
        speed = Random.Range(speedMin, speedMax);
        scale = Random.Range(scaleMin, scaleMax);

        imageRectTransform.localScale = Vector3.one * scale;
        imageRectTransform
            .DOMoveX(Screen.width + image.sprite.bounds.size.x, Screen.width / speed)
            .SetEase(Ease.Linear)
            .OnComplete(ReSpawn);
    }

    void ReSpawn()
    {
        DOTween.Kill(imageRectTransform);
        Vector2 position = RandomUtils.RandomPointInBox(respawnCollider);

        imageRectTransform.position = position;

        Initialize();
    }
}
