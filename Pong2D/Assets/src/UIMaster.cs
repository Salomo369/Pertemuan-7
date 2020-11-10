using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

///////////////////////////////////////////////////////////////////
///                     UIMaster.cs
///         Logic for UI stuff and win condition.
/// Controls the UI elements to update stuffs and also handles
/// the score checking to be able to stop a game when max score
/// is reached.
/// also stores public method for buttons in the scene to have
/// functionality(reset & load scene).
///////////////////////////////////////////////////////////////////
public class UIMaster : MonoBehaviour
{
    public Text m_P1ScoreText, m_P2ScoreText;
    public GameObject m_GameOverPanel;
    public Text m_EndGameMSG;
    public string m_GameplaySceneName;
    public string m_MenuSceneName;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "arena")
        {
            m_GameOverPanel.SetActive(false);
        }
    }

    public void UpdateScoreHUD()
    {
        m_P1ScoreText.text = ScoreData.m_P1Score.ToString();
        m_P2ScoreText.text = ScoreData.m_P2Score.ToString();

        if (ScoreData.m_P1Score >= ScoreData.MaxScoreToWin)
        {
            m_GameOverPanel.SetActive(true);
            string msg = "Game over\nPlayer 1 wins!";
            m_EndGameMSG.text = msg;
        }
        if (ScoreData.m_P2Score >= ScoreData.MaxScoreToWin)
        {
            m_GameOverPanel.SetActive(true);
            string msg = "Game over\nPlayer 2 wins!";
            m_EndGameMSG.text = msg;
        }
    }

    // Public methods
    public void StartGame()
    {
        if (!string.IsNullOrWhiteSpace(m_GameplaySceneName))
        {
            SceneManager.LoadScene(m_GameplaySceneName);
            ScoreData.ResetData();
        }
        else Debug.Log("Unable to load: game scene name has not been set.");
    }
    public void LoadMainMenu()
    {
        if (!string.IsNullOrWhiteSpace(m_MenuSceneName))
        {
            SceneManager.LoadScene(m_MenuSceneName);
        } 
        else Debug.Log("Unable to load: menu scene name has not been set.");
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ScoreData.ResetData();
    }

    public void QuitApplication()
    {
        Debug.Log("Application.Quit() called . . .");
        Application.Quit();
    }
}
