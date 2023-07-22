using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToInstructionPage()
    {
        SceneManager.LoadScene("InstructionScene");
    }

    public void BackToMainMenu()
    {
        if (!AudioManager.Instance.IsMusicPlaying)
        {
            AudioManager.Instance.PlayMusic("Theme");
        }
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartGame()
    {
        if(!AudioManager.Instance.IsMusicPlaying)
        {
            AudioManager.Instance.PlayMusic("Theme");
        }
        SceneManager.LoadScene("GameScene");
    }
}
