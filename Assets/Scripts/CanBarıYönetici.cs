using UnityEngine;
using UnityEngine.UI;

public class CanBar�Y�netici : MonoBehaviour
{
    public Image canBar�Image; // Can bar� g�rselinin referans�

    private static Sprite kaydedilenCanBar�Sprite; // Kaydedilen can bar� sprite'�n� tutan de�i�ken

    // Awake metodu, sahne y�klenirken �a�r�l�r
    private void Awake()
    {
        // Kaydedilen can bar� sprite'�n� y�kle
        if (kaydedilenCanBar�Sprite != null)
        {
            canBar�Image.sprite = kaydedilenCanBar�Sprite;
        }
    }

    // OnDestroy metodu, sahne y�k�l�rken �a�r�l�r
    private void OnDestroy()
    {
        // Son can bar� sprite'�n� kaydet
        kaydedilenCanBar�Sprite = canBar�Image.sprite;
    }
}
