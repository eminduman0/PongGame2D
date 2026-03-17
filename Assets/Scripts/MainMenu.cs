using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject settingsPanel;

    
    public void PlayGame()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonClick);
        AudioManager.instance.PlayGame();
    }
    public void QuitGame()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonClick);
        Application.Quit();
    }

    public void OpenSettings()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonClick);
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonClick);
        settingsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    

}
