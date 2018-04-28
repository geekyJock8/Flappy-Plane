using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour {

    public float scrollSpeed = -1.5f;
    public bool gameOver = false;
    public bool isGamePlaying = false;
    public static GameLogic instance;
    int score = 0;
    int highScore;
    public Text scoreText;
    public Text highScoreText;
    public GameObject redPlane;
    public GameObject greenPlane;

	// Use this for initialization
	void Awake ()
    {
		if (instance == null)
        {
            instance = this;
            scoreText.text = "Score : " + score.ToString();

            if(Menu.plane == 0)
            {
                redPlane.SetActive(true);
                greenPlane.SetActive(false);
            }
            else if(Menu.plane == 1)
            {
                redPlane.SetActive(false);
                greenPlane.SetActive(true);
            }

            highScore = LoadHighScore();
            highScoreText.text = "Best : " + highScore.ToString();
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (gameOver == true)
        {
            SceneManager.LoadScene(1);
        }
	}

    public void PlaneCrashed()
    {
        if(score > highScore)
        {
            SaveHighScore(score);
        }
        gameOver = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ObstacleCleared()
    {
        score++;

        scoreText.text = "Score : " + score.ToString();
    }

    private void SaveHighScore(int score)
    {
        PlayerPrefs.SetInt("HighScore", score);
    }

    private int LoadHighScore()
    {
        int score = PlayerPrefs.GetInt("HighScore", 0);
        return score;
    }
}
