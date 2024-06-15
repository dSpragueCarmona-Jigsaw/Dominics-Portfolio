using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    //creates instance to access anywhere
    public static ScoreManager instance;

    //score
    public TMP_Text scoreText;
    public TMP_Text highscoreText;

    public int score = 0;
    public int highscore = 0;

    //creates an instance at start of game
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("", 0);
        scoreText.text = score.ToString() + "";
        highscoreText.text = highscore.ToString() + "";
    }

    //adds score
    public void AddResource()
    {
        score += 5;
        scoreText.text = score.ToString() + "";
        if (highscore < score)
            PlayerPrefs.SetInt("", score);
    }
}
