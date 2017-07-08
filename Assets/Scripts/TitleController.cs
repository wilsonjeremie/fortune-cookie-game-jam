using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleController : MonoBehaviour {

    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject statsScreen;
    public Slider musicSlider;
    public Slider soundSlider;
    public Digit[] highScoreDigits;
    GameObject activeMenu;

    void Start()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        statsScreen.SetActive(false);
        activeMenu = mainMenu;

        HighScoreManager.CheckFile();
        HighScoreManager.GetHighScore();
    }

    void SetHighScore()
    {
        int prevHighScore = HighScoreManager.HighScore;

        highScoreDigits[0].Number = (prevHighScore / 100000000);
        highScoreDigits[1].Number = (prevHighScore / 10000000) % 10;
        highScoreDigits[2].Number = (prevHighScore / 1000000) % 10;
        highScoreDigits[3].Number = (prevHighScore / 100000) % 10;
        highScoreDigits[4].Number = (prevHighScore / 10000) % 10;
        highScoreDigits[5].Number = (prevHighScore / 1000) % 10;
        highScoreDigits[6].Number = (prevHighScore / 100) % 10;
        highScoreDigits[7].Number = (prevHighScore / 10) % 10;
        highScoreDigits[8].Number = (prevHighScore) % 10;
    }

    public void StartButton()
    {
        SceneManager.LoadScene("Main");
    }

    public void OptionsMenuButton()
    {
        optionsMenu.SetActive(true);
        activeMenu.SetActive(false);
        activeMenu = optionsMenu;
    }

    public void StatsScreenButton()
    {
        statsScreen.SetActive(true);
        activeMenu.SetActive(false);
        activeMenu = statsScreen;
        SetHighScore();
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void BackButton()
    {
        mainMenu.SetActive(true);
        activeMenu.SetActive(false);
        activeMenu = mainMenu;
    }

    public void SetMusicVolume()
    {
        SoundController.MusicVolume = musicSlider.value;
    }

    public void SetSoundVolume()
    {
        SoundController.SoundVolume = soundSlider.value;
    }
}