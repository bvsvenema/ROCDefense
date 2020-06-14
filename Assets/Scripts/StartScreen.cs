using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    //public enum DifficultyEnum { Easy, Medium, Hard };
    //public DifficultyEnum difficulty;

    public GameManager gameManager;

    //Panels
    public GameObject StartPanel;
    public GameObject levelsPanel;
    public GameObject difficulyPanel;
    public GameObject selectPanel;
    public GameObject QuitPanel;
    public GameObject Game;
    public GameObject startCanvas;

    //SELECT PANAL BUTTONS
    public void LevelsButton()
    {
        StartPanel.SetActive(false);
        levelsPanel.SetActive(true);
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
    }
     
    public void MediumButton()
    {
        Game.SetActive(true);
        startCanvas.SetActive(false);
    }

    public void HardButton()
    {
        Game.SetActive(true);
        startCanvas.SetActive(false);
    }
}
