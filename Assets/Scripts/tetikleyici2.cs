using UnityEngine;
using UnityEngine.SceneManagement;

public class tetikleyici2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("3.b�l�m"); // 3. b�l�m�n sahne ad�n� buraya yaz�n
        }
    }
}
