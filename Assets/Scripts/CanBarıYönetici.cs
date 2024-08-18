using UnityEngine;
using UnityEngine.UI;

public class CanBarıYönetici : MonoBehaviour
{
    public Image canBarıImage; // Can barı görselinin referansı

    private static Sprite kaydedilenCanBarıSprite; // Kaydedilen can barı sprite'ını tutan değişken

    // Awake metodu, sahne yüklenirken çağrılır
    private void Awake()
    {
        // Kaydedilen can barı sprite'ını yükle
        if (kaydedilenCanBarıSprite != null)
        {
            canBarıImage.sprite = kaydedilenCanBarıSprite;
        }
    }

    // OnDestroy metodu, sahne yıkılırken çağrılır
    private void OnDestroy()
    {
        // Son can barı sprite'ını kaydet
        kaydedilenCanBarıSprite = canBarıImage.sprite;
    }
}
