using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToInstructionPage()
    {
        SceneManager.LoadScene(1);
    }

    public void BackToMainMenu()
    {
        if (!AudioManager.Instance.IsMusicPlaying)
        {
            AudioManager.Instance.PlayMusic("Theme");
        }
        SceneManager.LoadScene(0);
    }

    public void RestartGame()
    {
        if(!AudioManager.Instance.IsMusicPlaying)
        {
            AudioManager.Instance.PlayMusic("Theme");
        }
        SceneManager.LoadScene(2);
    }
}
