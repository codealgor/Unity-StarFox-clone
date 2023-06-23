using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//The game manager(also a singleton)
public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
    }

    public Text scoreText;      // Text object for Score
    public int score;     // Score value

    string _highscoreKey = "VALUE_HIGHSCORE";   //Stores the Highscore
    AudioSource _sound; //Reference to Score Sound

    void Start()
    {
        _sound = GetComponent<AudioSource>();
        score = 0;
        UpdateScore();
    }

    // Update the scoreboard
    void UpdateScore()
    {
        scoreText.text = score.ToString();
    }

    //Add points to the score
    public void AddScore(int points)
    {
        _sound.Play();
        score += points;
        UpdateScore();
    }

    //Update the high score
    public void UpdateHighscore()
    {
        if (PlayerPrefs.GetInt(_highscoreKey) < score)
        {
            PlayerPrefs.SetInt(_highscoreKey, score);
        }
    }
}