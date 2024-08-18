using UnityEngine;
using UnityEngine.SceneManagement;

public class tetikleyici2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("3.bölüm"); // 3. bölümün sahne adýný buraya yazýn
        }
    }
}
