using UnityEngine;
using UnityEngine.SceneManagement;

public class tetikleyici1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("2.bölüm"); // 2. bölümün sahne adýný buraya yazýn
        }
    }
}
