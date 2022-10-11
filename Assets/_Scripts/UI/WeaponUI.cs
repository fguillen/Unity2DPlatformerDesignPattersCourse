using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using WeaponSystem;

public class WeaponUI : MonoBehaviour
{
    public UnityEvent OnChange;
    Sprite noWeaponSprite;

    [SerializeField] Image image;

    void Awake()
    {
        NoWeapon();
    }

    public void SetWeapon(AWeaponData weapon)
    {
        SetWeaponSprite(weapon.sprite);
    }

    public void NoWeapon()
    {
        SetWeaponSprite(noWeaponSprite);
    }

    void SetWeaponSprite(Sprite sprite)
    {
        image.sprite = sprite;
        OnChange?.Invoke();
    }
}
