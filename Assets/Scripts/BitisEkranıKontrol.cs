using UnityEngine;
using UnityEngine.SceneManagement;

public class BitisEkranıKontrol : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Tetikleyiciyle sadece "Player" etiketine sahip nesnelerin temasını kontrol ediyoruz.
        {
            SceneManager.LoadScene("BitisEkranı"); // Bitiş ekranı sahnesini yükleyerek oyunu bitiriyoruz.
        }
    }
}
