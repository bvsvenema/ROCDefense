using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Optionsscript : MonoBehaviour
{

    public GameObject mainMenuPanel;


    public AudioMixer audioMixer;

    //set the volume of the mainmixer with i slide
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    //set the qualty setting with dropdown menu
    public void SetQualty(int qualtyIndex)
    {
        QualitySettings.SetQualityLevel(qualtyIndex);
    }

    public void MainMenuButton()
    {
        mainMenuPanel.SetActive(true);
    }

    public void MainMenuNoButton()
    {
        mainMenuPanel.SetActive(false);
    }

    public void MainMenuYesButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
