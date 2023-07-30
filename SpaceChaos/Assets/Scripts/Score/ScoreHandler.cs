using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreHandler : MonoBehaviour
{
    private static ScoreHandler instance;
    public static ScoreHandler Instance { get { return instance; } }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            // DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField] private TMP_Text scoreText;
    private int score;

    void Start()
    {
        score = 0;
    }

    public void UpdateScore(int value)
    {
        score += value;
        scoreText.text = score.ToString(); // Update the score in UI
    }

    public int GetScore { get { return score; } }
}
