using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

//Controls when the game ends
public class Gameover : MonoBehaviour
{
    public Text gameoverText;       //Gameover text
    public Text completeText;       //Complete Mission text
    public Text finalScoreText;     //Final score text
    public string sceneName = "Menu";       //Scene Name to Menu
    MoveForward _plane;      //Game Plane
    string _highscoreKey = "VALUE_HIGHSCORE";   //Stores the Highscore

    // Use this for initialization
    void Start()
    {
        _plane = FindObjectOfType<MoveForward>();
    }

    //If the player dies, stop them and end the game
    public void Dead()
    {
        _plane.speed = 0;
        gameoverText.enabled = true;
        finalScoreText.text = "SCORE: " + GameManager.Instance.score;
        finalScoreText.enabled = true;
        if (PlayerPrefs.GetInt(_highscoreKey) < GameManager.Instance.score)
        {
            PlayerPrefs.SetInt(_highscoreKey, GameManager.Instance.score);
        }
        Invoke("LoadMenu", 5.0f);
    }

    //If the player reaches the {insert time here} mark, stop them and end the game
    public void MissionComplete()
    {
        _plane.speed = 0;
        completeText.enabled = true;
        finalScoreText.enabled = true;
        finalScoreText.text = "SCORE: " + GameManager.Instance.score;
        if (PlayerPrefs.GetInt(_highscoreKey) < GameManager.Instance.score)
        {
            PlayerPrefs.SetInt(_highscoreKey, GameManager.Instance.score);
        }
        Invoke("LoadMenu", 5.0f);
    }

    //Load the menu scene when the game ends
    void LoadMenu()
    {
        SceneManager.LoadScene(sceneName);
    }

    // The collision detection for the ship at the end of the level
    public void OnTriggerEnter(Collider collision)
    {
        GameObject otherGO = collision.gameObject;
        if (otherGO.tag == "Player")
        {
            MissionComplete();
        }
    }
}