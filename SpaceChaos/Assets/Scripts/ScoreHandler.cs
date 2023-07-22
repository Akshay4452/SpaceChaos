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
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    [SerializeField] private TMP_Text scoreText;
    private int score;
    
    // Start is called before the first frame update
    void Start()
    {
        score = 0; // score initialization
        scoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
    }

    public void UpdateScore(int value)
    {
        score += value;
        scoreText.text = score.ToString(); // Update the score in UI
    }

    public int GetScore { get { return score; } }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "GameScene")
        {
            if (scoreText == null)
            {
                scoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
                score = 0;
                scoreText.text = score.ToString();  // Make the score to 0 again
            }
        }  
    }
}
