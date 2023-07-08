using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    [Header("The Main Buttons")]
    [SerializeField] Button startButton; //The "Start Simulation" button
    [SerializeField] Button endButton; //The "End Simulation" button
    [SerializeField] Button HS_Button; //The "High Scores" menu
    [SerializeField] Dropdown dif;

    [Space]

    [Header("Audio Clips")]
    [SerializeField] AudioSource[] audioClips = new AudioSource[1]; //The sounds the buttons make

    [Space]

    [Header("References")]
    [SerializeField] RawImage background;

    public string _highscoreKey = "VALUE_HIGHSCORE"; //Highscore key
    [HideInInspector] public string selectedOption;

    public enum Difficulty{
        F,
        FP,
        C,
        CP,
        N
    }

    public Difficulty m_DifState;

    void Start(){
        if(!PlayerPrefs.HasKey(_highscoreKey)) PlayerPrefs.SetInt(_highscoreKey, 0);
        
        Button start = startButton.GetComponent<Button>(); //The start button
        Button hs = HS_Button.GetComponent<Button>(); // The high score button

        start.onClick.AddListener(StartGame);
        hs.onClick.AddListener(DispHighScores);
    }

    void LateUpdate(){
        ChangeDifficulty();
    }

    void StartGame(){
        SceneManager.LoadScene(1);
    }

    void ChangeDifficulty(){
        int selectedIndex = dif.value;
        selectedOption = dif.options[selectedIndex].text;
        Debug.Log(selectedOption);
        switch(selectedOption){
            case "Function":
                m_DifState = Difficulty.F;
                break;
            case "Function+":
                m_DifState = Difficulty.FP;
                break;
            case "Class":
                m_DifState = Difficulty.C;
                break;
            case "Class+":
                m_DifState = Difficulty.CP;
                break;
            case "Namespace":
                m_DifState = Difficulty.N;
                break;
            default:
                Debug.Log("An Error has Occurred");
                break;
        }
    }

    void DispHighScores(){
        Vector3 randomChance = new Vector3(Random.value, Random.value, Random.value);
        if(randomChance.x == randomChance.y && randomChance.y == randomChance.z) {
            EasterEgg();
        }
    }

    void EasterEgg(){
        //Attaches a video player to the main camera
        GameObject camera = GameObject.Find("Main Camera");

        //VideoPlayer automatically targets the camera backplane when it is added to a camera object
        var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();

        //Play on awake - false
        videoPlayer.playOnAwake = false;
    }
}
