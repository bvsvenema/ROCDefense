using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{

    public static TextMeshProUGUI text;
    public static int Score;

    private void OnEnable()
    {
        GameManager.OnDifficultyChanged += UpdateScore;
    }

    private void OnDisable()
    {
        GameManager.OnDifficultyChanged -= UpdateScore;
    }
    public static int score
    {
        get { return Score; }
        set { Score = value;
            updateScore(); }
    }
    // Start is called before the first frame update
    void Start()
    {
        text = this.GetComponent<TextMeshProUGUI>();

        text.text = "Score: " + Score;
    }

    private static void updateScore()
    {
        text.text = "Score: " + Score;
    }

    public void UpdateScore(int scoreToSet)
    {
        Score = scoreToSet;
    }
}
