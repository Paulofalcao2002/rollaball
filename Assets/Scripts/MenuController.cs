using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using TMPro;

public class MenuController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI maxScoreText;

    public void OnPlayButton ()
    {
        SceneManager.LoadScene("Scenes/Minigame");
        FindObjectOfType<AudioManager>().Play("Start");
    }

    void Start()
    {
        int score = PlayerPrefs.GetInt("Score", 0);
        int maxScore = PlayerPrefs.GetInt("MaxScore", 0);

        if (scoreText) 
        {
            scoreText.text = "Score: " + score.ToString();
        }

        if (maxScoreText) 
        {
            maxScoreText.text = "Max score: " + maxScore.ToString();
        }
    }
}
