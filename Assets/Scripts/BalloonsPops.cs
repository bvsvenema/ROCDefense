using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BalloonsPops : MonoBehaviour
{

    public static TextMeshProUGUI text;

    public static int BalloonsPop;
    public static int balloonsPop
    {
        get { return BalloonsPop; }
        set
        {
            BalloonsPop = value;
            UpdatePops();
        }

    }

    void Start()
    {
        text = this.GetComponent<TextMeshProUGUI>();
    }

    private static void UpdatePops()
    {
        if (GameObject.FindWithTag("GameUI"))
        {
            text.text = "BalloonsPops: " + BalloonsPop;
        }
        else if (GameObject.FindWithTag("End"))
        {
            text.text = "You popt " + BalloonsPop + " balloons!";
        }
    }



}
