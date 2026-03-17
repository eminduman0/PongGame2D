using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject settingsPanel;
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (settingsPanel.activeSelf)
            {
                CloseSettings();
            }
            else if (pausePanel.activeSelf)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonClick);
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonClick);
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonClick);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }

    public void OpenSettings()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonClick);
        pausePanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonClick);
        settingsPanel.SetActive(false);
        pausePanel.SetActive(true);
    }

    public void MainMenu()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonClick);
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        AudioManager.instance.PlayMusic(AudioManager.instance.mainMenuMusic);
    }

}