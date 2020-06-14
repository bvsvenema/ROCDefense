using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static GameObject deathCanvas;
    public TextMeshProUGUI Healthtext;
    public static bool gameOver = false;
    public static bool oneTimer = false;

    public delegate void GameManagerDelegate(int scoreToSet);
    public static GameManagerDelegate OnDifficultyChanged;

    public enum DifficultyEnum { Easy, Medium, Hard };
    private DifficultyEnum _difficulty;
    public  DifficultyEnum difficulty
    {
        get
        {
            return _difficulty;
        }

        set
        {
            _difficulty = value;
            if (OnDifficultyChanged != null)
            {
                switch (value)
                {
                    case DifficultyEnum.Easy:
                        OnDifficultyChanged(600);
                        Health = 10;
                        break;
                    case DifficultyEnum.Medium:
                        OnDifficultyChanged(500);
                        Health = 7;
                        break;
                    case DifficultyEnum.Hard:
                        OnDifficultyChanged(350);
                        Health = 5;
                        break;
                    default:
                        Debug.Log("WAIT WUT!?!?");
                        break;
                }
            }

            SetDifficulty();
            UpdateHealth();
        }
    }

    void Awake()
    {
        if(Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            //DontDestroyOnLoad(this.gameObject);
        }
    }

    private int Health;
    public int health
    {
        get { return Health; }
        set
        {
            Health = value;
            if(value <= 0)
            {
                GameOver();
                Debug.Log("death");
                gameOver = true;
            }
            
            Debug.Log(Health);
            UpdateHealth();
        }
    }

    private void Start()
    {
        //Healthtext = this.GetComponent<TextMeshProUGUI>();
        Debug.Log(Healthtext.gameObject.name);
    }




    public void UpdateHealth()
    {
        //Healthtext.text = "Health: " + Health;
        Healthtext.text = "Health: " + Health;
    }

    public static void GameOver()
    {
        if (!oneTimer)
        {
            Debug.Log("GameOver");
            //deathCanvas.SetActive(true);
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
                GameObject.Destroy(enemy);
            oneTimer = true;
        }
    }

    public void SetDifficulty()
    {
        switch (difficulty)
        {
            case DifficultyEnum.Easy:
                Health = 10;
                break;
            case DifficultyEnum.Medium:
                Health = 7;
                break;
            case DifficultyEnum.Hard:
                Health = 5;
                break;

            default:
                Debug.Log("Something went wrong");
                break;
        }

        //if (difficulty == StartScreen.DifficultyEnum.Easy)
        //{
        //    Health = 10;
        //}
        //else if (difficulty == StartScreen.DifficultyEnum.Medium)
        //{
        //    Health = 7;
        //}
        //else if (difficulty == StartScreen.DifficultyEnum.Hard)
        //{
        //    Health = 5;
        //}
        //else
        //{
        //    Debug.Log("There is a problem!!!! Quitting");
        //    Application.Quit();
        //}
        Debug.Log(Health);
        //Healthtext.SetText("Health: " + Health);
    }

    public void EasyButton()
    {
        difficulty = DifficultyEnum.Easy;
    }

    public void MediumButton()
    {
        difficulty = DifficultyEnum.Medium;
    }

    public void HardButton()
    {
        difficulty = DifficultyEnum.Hard;
    }
}
