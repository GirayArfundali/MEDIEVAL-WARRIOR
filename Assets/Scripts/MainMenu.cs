using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private bool isSettingsPanelOpen = false;
    private bool isCharacterMovementAllowed = true;

    public GameObject settingsPanel; // Reference to the settings panel game object
    public GameObject ayarlarButton; // Reference to the "Ayarlar" button game object

    public hareket movementScript; // Reference to the Movement script

    private void Update()
    {
        // Check if the settings panel is open and prevent character movement if true
        if (isSettingsPanelOpen && isCharacterMovementAllowed)
        {
            return; // Exit the Update() method early to prevent character movement
        }

        // Allow character movement
        movementScript.enabled = isCharacterMovementAllowed;
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("1.bölüm");
        ResumeGame(); // Resume the game after loading the scene
    }

    public void creative()
    {
        SceneManager.LoadScene("creative");
    }

    public void QuitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void AnaMenuyeDon()
    {
        SceneManager.LoadScene("Ana Menü");
    }

    public void OynanisButton()
    {
        SceneManager.LoadScene("Oynanýþ");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ResumeGame(); // Resume the game after reloading the scene
    }

    public void OpenSettingsPanel()
    {
        settingsPanel.SetActive(true); // Activate the settings panel game object
        PauseGame(); // Pause the game
        ayarlarButton.SetActive(false); // Deactivate the "Ayarlar" button
        isSettingsPanelOpen = true; // Set the flag to indicate that the settings panel is open
        isCharacterMovementAllowed = false; // Disable character movement
    }

    public void CloseSettingsPanel()
    {
        settingsPanel.SetActive(false); // Deactivate the settings panel game object
        ayarlarButton.SetActive(true); // Activate the "Ayarlar" button
        isSettingsPanelOpen = false; // Set the flag to indicate that the settings panel is closed
        isCharacterMovementAllowed = true; // Enable character movement
    }

    public void ToggleSettingsPanel()
    {
        bool isActive = !settingsPanel.activeSelf;
        settingsPanel.SetActive(isActive); // Toggle the active state of the settings panel
        ayarlarButton.SetActive(!isActive); // Toggle the active state of the "Ayarlar" button
        if (isActive)
        {
            PauseGame();
            isSettingsPanelOpen = true; // Set the flag to indicate that the settings panel is open
            isCharacterMovementAllowed = false; // Disable character movement
        }
        else
        {
            ResumeGame();
            isSettingsPanelOpen = false; // Set the flag to indicate that the settings panel is closed
            isCharacterMovementAllowed = true; // Enable character movement
        }
    }

    public void ContinueButton()
    {
        ResumeGame(); // Resume the game
        CloseSettingsPanel(); // Close the settings panel
    }

    private void PauseGame()
    {
        Time.timeScale = 0f; // Pause the game
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f; // Resume the game
    }
}
