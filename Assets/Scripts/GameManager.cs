using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static bool isGameStarted;
    public static bool isGameEnded;
    public static int LevelNumber = 0;

    public int Score;
    public int HighScore;

    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HighScoreText;
    public TextMeshProUGUI OnScreenScoreText;

    public GameObject LevelFailedPanel,ScorePanel;
    public List<GameObject> Levels = new List<GameObject>();
    [SerializeField] int LevelIndex = 0;

    int PointsCounted;
    int LastCounted;

    BirdJumper birdJumper;
    PipeMover[] pipeMover;
    BackgroundMover[] backgroundMover;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            CreateLevel();
        }
    }
    void Start()
    {
        HighScore = PlayerPrefs.GetInt("HighScore");
        birdJumper = FindObjectOfType<BirdJumper>();
        pipeMover = FindObjectsOfType<PipeMover>();
        backgroundMover = FindObjectsOfType<BackgroundMover>();
    }
    public void CreateLevel()
    {
        LevelIndex = PlayerPrefs.GetInt("LevelNo", 0);
        if (LevelIndex > Levels.Count - 1)
        {
            LevelIndex = 0;
            PlayerPrefs.GetInt("LevelNo", 0);
        }
        Instantiate(Levels[LevelIndex]);
        LevelNumber = LevelIndex + 1;
    }
    public void StartGame()
    {
        isGameStarted = true;
        isGameEnded = false;
        birdJumper.rb.useGravity = true;
        ScorePanel.SetActive(true);
        MoveBackground();
    }
    void MoveBackground()
    {
        for (int i = 0; i < pipeMover.Length; i++)
        {
            pipeMover[i].GetComponent<Rigidbody2D>().velocity = new Vector2(pipeMover[i].scrollspeed, 0);
        }
        for (int i = 0; i < backgroundMover.Length; i++)
        {
            backgroundMover[i].GetComponent<Rigidbody2D>().velocity = new Vector2(pipeMover[i].scrollspeed, 0);
        }
    }
    public void EndGame()
    {
        isGameEnded = true;
    }
    public void OnLevelFailed()
    {
        LevelFailedPanel.SetActive(true);
        ScorePanel.SetActive(false);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        isGameStarted = false;
    }
    public void PointCounter(int thisCount)
    {
        PointsCounted = LastCounted + thisCount;
        LastCounted = PointsCounted;
        ScoreText.text = LastCounted.ToString();
        OnScreenScoreText.text = LastCounted.ToString();
        HighScoreText.text = HighScore.ToString();
        if (LastCounted > HighScore)
        {
            HighScoreText.text = LastCounted.ToString();
        }
    }
}