using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    //public enum DifficultyEnum { Easy, Medium, Hard };
    //public DifficultyEnum difficulty;

    //Panels
    public GameObject StartPanel;
    public GameObject levelsPanel;
    public GameObject difficulyPanel;
    public GameObject selectPanel;
    public GameObject QuitPanel;
    public GameObject Game;
    public GameObject startCanvas;
    public GameObject mainCanvas;
    public GameObject optionsPanel;

    //SELECT PANAL BUTTONS
    public void LevelsButton()
    {
        StartPanel.SetActive(false);
        levelsPanel.SetActive(true);
        optionsPanel.SetActive(false);
    }

    public void QuitButton()
    {
        QuitPanel.SetActive(true);
    }
    //Quit Button
    public void QuitYesButton()
    {
        Application.Quit();
    }
    public void QuitNoButton()
    {
        QuitPanel.SetActive(false);
    }

    public void OptionsButton()
    {
        levelsPanel.SetActive(false);
        StartPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }



    //LEVELS SELECT BUTTONS

    public void Level1Button()
    {
        levelsPanel.SetActive(false);
        difficulyPanel.SetActive(true);
    }

    //public void Level2Button()
    //{
    //    levelsPanel.SetActive(true);
    //    difficulyPanel.SetActive(false);
    //}

    //public void Level3Button()
    //{
    //    levelsPanel.SetActive(true);
    //    difficulyPanel.SetActive(false);
    //}

    //public void Level4Button()
    //{
    //    levelsPanel.SetActive(true);
    //    difficulyPanel.SetActive(false);
    //}

    // DIFFICULTY BUTTONS

    public void EasyButton()
    {
        Game.SetActive(true);
        startCanvas.SetActive(false);
        mainCanvas.SetActive(true);
    }
     
    public void MediumButton()
    {
        Game.SetActive(true);
        startCanvas.SetActive(false);
        mainCanvas.SetActive(true);
    }

    public void HardButton()
    {
        Game.SetActive(true);
        startCanvas.SetActive(false);
        mainCanvas.SetActive(true);
    }
}
