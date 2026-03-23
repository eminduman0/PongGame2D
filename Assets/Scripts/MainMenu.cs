using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject settingsPanel;
    public GameObject modeSelectPanel;

    
    public void PlayGame()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonClick);
        mainMenuPanel.SetActive(false);
        modeSelectPanel.SetActive(true);
        
    }
    public void StartTwoPlayers()
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
        if (modeSelectPanel) modeSelectPanel.SetActive(false);
        if (settingsPanel) settingsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

}
