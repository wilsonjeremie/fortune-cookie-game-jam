using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour {

    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject statsScreen;
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
}