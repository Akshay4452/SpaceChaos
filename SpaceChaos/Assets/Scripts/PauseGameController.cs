using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseGameController : MonoBehaviour
{
    [SerializeField] private Button pauseButton;
    [SerializeField] private Canvas pauseCanvas;
    [SerializeField] private TMP_Text scoreText;

    private void Start()
    {
        pauseButton.onClick.AddListener(PauseGame);
        pauseCanvas.gameObject.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        // Make Pause Button Disappear
        pauseButton.gameObject.SetActive(false);
        pauseCanvas.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        // Make Pause Button Reappear
        pauseButton.gameObject.SetActive(true);
        pauseCanvas.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
    }
}
