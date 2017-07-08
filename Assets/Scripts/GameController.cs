using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public Digit[] scoreDigits;
    public Digit[] distanceTravelledDigits;
    public Digit[] previousHighScoreDigits;
    public GameObject EndGameDisplay;
    public GameObject PauseMenu;
    public GameObject SubPauseMenu1;
    public GameObject SubPauseMenu2;
    Player player;
    float distance;
    public static bool GamePaused { get; private set; }

    void OnEnable()
    {
        player = FindObjectOfType<Player>();
        player.PlayerDied += OnPlayerDied;
    }

    void OnDisable()
    {
        player.PlayerDied -= OnPlayerDied;
    }

	void Start () {
        GamePaused = false;
        EndGameDisplay.SetActive(false);
        PauseMenu.SetActive(false);
        distance = 0f;
	}

    void FixedUpdate()
    {
        if (Time.timeScale < 2f)
            Time.timeScale += 0.01f * Time.deltaTime;
    }
	
	void Update () {
        UpdateDistance();

        if (CustomInput.PauseButtonDown() && !player.Dead)
        {
            if (!GamePaused)
            {
                Time.timeScale = 0f;
                PauseMenu.SetActive(true);
                SubPauseMenu1.SetActive(true);
                SubPauseMenu2.SetActive(false);
            }
            else
            {
                Time.timeScale = 1f;
                PauseMenu.SetActive(false);
            }
            GamePaused = !GamePaused;
        }
	}

    void UpdateDistance()
    {
        distance += player.Speed * Time.deltaTime;

        int distInt = (int)distance;

        scoreDigits[0].Number = (distInt / 100000000);
        scoreDigits[1].Number = (distInt / 10000000) % 10;
        scoreDigits[2].Number = (distInt / 1000000) % 10;
        scoreDigits[3].Number = (distInt / 100000) % 10;
        scoreDigits[4].Number = (distInt / 10000) % 10;
        scoreDigits[5].Number = (distInt / 1000) % 10;
        scoreDigits[6].Number = (distInt / 100) % 10;
        scoreDigits[7].Number = (distInt / 10) % 10;
        scoreDigits[8].Number = (distInt) % 10;
    }

    void OnPlayerDied()
    {
        EndGameDisplay.SetActive(true);
        UpdateDistanceTravelled();
        UpdatePreviousHighScore();
    }

    public void UpdateDistanceTravelled()
    {
        int distInt = (int)distance;

        distanceTravelledDigits[0].Number = (distInt / 100000000);
        distanceTravelledDigits[1].Number = (distInt / 10000000) % 10;
        distanceTravelledDigits[2].Number = (distInt / 1000000) % 10;
        distanceTravelledDigits[3].Number = (distInt / 100000) % 10;
        distanceTravelledDigits[4].Number = (distInt / 10000) % 10;
        distanceTravelledDigits[5].Number = (distInt / 1000) % 10;
        distanceTravelledDigits[6].Number = (distInt / 100) % 10;
        distanceTravelledDigits[7].Number = (distInt / 10) % 10;
        distanceTravelledDigits[8].Number = (distInt) % 10;
    }

    public void UpdatePreviousHighScore()
    {
        if (distance > HighScoreManager.HighScore)
        {
            HighScoreManager.HighScore = (int)distance;
            HighScoreManager.SaveHighScore();
        }
        int prevHighScore = HighScoreManager.HighScore;

        previousHighScoreDigits[0].Number = (prevHighScore / 100000000);
        previousHighScoreDigits[1].Number = (prevHighScore / 10000000) % 10;
        previousHighScoreDigits[2].Number = (prevHighScore / 1000000) % 10;
        previousHighScoreDigits[3].Number = (prevHighScore / 100000) % 10;
        previousHighScoreDigits[4].Number = (prevHighScore / 10000) % 10;
        previousHighScoreDigits[5].Number = (prevHighScore / 1000) % 10;
        previousHighScoreDigits[6].Number = (prevHighScore / 100) % 10;
        previousHighScoreDigits[7].Number = (prevHighScore / 10) % 10;
        previousHighScoreDigits[8].Number = (prevHighScore) % 10;
    }

    public void RunAgainButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Title");
    }

    public void TryToQuit()
    {
        SubPauseMenu1.SetActive(false);
        SubPauseMenu2.SetActive(true);
    }

    public void CancelQuit()
    {
        SubPauseMenu1.SetActive(true);
        SubPauseMenu2.SetActive(false);
    }
}
