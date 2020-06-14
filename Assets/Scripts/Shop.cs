using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManger buildManager;
    public int Scores;

    private void Start()
    {
        buildManager = BuildManger.instance;
    }

    private void OnEnable()
    {
        BuildManger.TurretBuildEvent += TurretBuild;
    }

    private void OnDisable()
    {
        BuildManger.TurretBuildEvent -= TurretBuild;
    }

    private void TurretBuild(Turret turret)
    {
        ScoreSystem.score -= turret.turretCost;
    }

    public void SetsTurret(Turret turretToSet)
    {
        if (ScoreSystem.score >= turretToSet.turretCost)
        {
            Debug.Log("You can build");
            buildManager.SetTurretToBuild(turretToSet);
        }
        else
        {
            Debug.Log("You have no money");
        }

        //public void Turret1()
        //{
        //    if (ScoreSystem.score >= 200)
        //    {
        //        Debug.Log("You can build");
        //        buildManager.SetTurretToBuild(buildManager.turret1);
        //        ScoreSystem.score -= 200;
        //    } else
        //    {
        //        Debug.Log("You have no money");
        //    }
        //}

        //public void Turret2()
        //{
        //    if (ScoreSystem.score >= 400)
        //    {
        //        Debug.Log("You can build");
        //        buildManager.SetTurretToBuild(buildManager.turret2);
        //        ScoreSystem.score -= 400;
        //    }
        //    else
        //    {
        //        Debug.Log("You have no money ");
        //    }
        //}

        //public void Turret3()
        //{
        //    if (ScoreSystem.score >= 300)
        //    {
        //        Debug.Log("You can build");
        //        buildManager.SetTurretToBuild(buildManager.turret3);
        //        ScoreSystem.score -= 300;
        //    }
        //    else
        //    {
        //        Debug.Log("You have no money");
        //    }
        //}
    }
}
