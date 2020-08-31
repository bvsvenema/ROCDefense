using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deathscreen : MonoBehaviour
{
    public void BackToMenu()
        {
            SceneManager.LoadScene("SampleScene");
        }
}