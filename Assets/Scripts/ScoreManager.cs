using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int player1Score = 0;
    public int player2Score = 0;

    public TMP_Text player1Text;
    public TMP_Text player2Text;

    public int maxScore = 10;
    public GameObject winPanel;
    public TMPro.TMP_Text winText;

    

    public void PlayAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void AddScorePlayer1()
    {
        player1Score++;
        
        player1Text.text = player1Score.ToString();

        if (player1Score >= maxScore)
        {
            GameWin("Player 1 Wins!");
        }
    }

    public void AddScorePlayer2()
    {
        player2Score++;
        
        player2Text.text = player2Score.ToString();

        if (player2Score >= maxScore)
        {
            GameWin("Player 2 Wins!");
        }
    }

    void GameWin(string winner)
    {
        winPanel.SetActive(true);
        winText.text = winner;
        Time.timeScale = 0f;
    }
}
