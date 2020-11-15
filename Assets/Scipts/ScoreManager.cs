using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    int score = 0;
    int strikes = 0;
    int highscore;

    public GameObject gameoverscreen;
    public Text scoreText;
    public Text highscoreText;

    public void IncreaseScore()
    {
        score++;
    }

    public void IncreaseStrikes()
    {
        strikes++;
    }

    private void Start()
    {
        highscore = PlayerPrefs.GetInt("Highscore", 0);
    }

    private void Update()
    {
        if (strikes >= 3)
        {
            Debug.Log("GameOver");
            Time.timeScale = 0;
            if(highscore < score)
            {
                highscore = score;
                PlayerPrefs.SetInt("Highscore", highscore);
            }
            //TODO
            //GameOver Screen Appears
            scoreText.text = score.ToString();
            highscoreText.text = highscore.ToString();
            gameoverscreen.SetActive(true);
        }
    }


}
