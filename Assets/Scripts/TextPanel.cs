using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextPanel : MonoBehaviour
{
    public GameObject QuitPanel;
    public GameObject ShopPanel;
    public GameObject PausePanel;
    public GameObject Game;

    //when the panel already is active and you press the button again it goes to non active and other wise
    public void PauseButton()
    {
        if (PausePanel.activeInHierarchy == false)
        {
            PausePanel.SetActive(true);
            Game.SetActive(false);
        }else if (PausePanel.activeInHierarchy == true)
        {
            PausePanel.SetActive(false);
            Game.SetActive(true);
        }
    }

    public void RestartButton()
    {
        if (QuitPanel.activeInHierarchy == false)
        {
            QuitPanel.SetActive(true);
        } else if (QuitPanel.activeInHierarchy == true)
        {
            QuitPanel.SetActive(false);
        }
    }
    

    public void RestartYesButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void RestartNoButton()
    {
        QuitPanel.SetActive(false);
    }
}
