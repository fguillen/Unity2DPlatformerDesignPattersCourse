using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    List<HealthImageUI> healthImages;

    [SerializeField] Sprite healthFull;
    [SerializeField] Sprite healthEmpty;
    [SerializeField] HealthImageUI healthImagePrefab;

    public void Initialize(int health)
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        healthImages = new List<HealthImageUI>();
        for (int i = 0; i < health; i++)
        {
            var healthImage = Instantiate(healthImagePrefab);
            healthImage.transform.SetParent(transform, false);
            healthImages.Add(healthImage);
        }
    }

    public void SetHealth(int health)
    {
        Debug.Log($"HealthUI.SetHealth({health})");

        for (int i = 0; i < healthImages.Count; i++)
        {
            if(i < health)
                healthImages[i].SetSprite(healthFull);
            else
                healthImages[i].SetSprite(healthEmpty);
        }
    }
}
