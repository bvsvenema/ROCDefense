using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Turret turret;
    public Color hoverColor;
    public Vector3 positionTurret;

    private Color startColor;
    private Renderer rend;

    BuildManger buildManager;


    private void Start()
    {
        positionTurret = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);

        buildManager = BuildManger.instance;

        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        if (buildManager.GetTurretToBuild() == null)
            return;

        if(turret != null)
        {
            Debug.Log("there is a turret there fool");
            return;

        }
        Turret turretToBuild = buildManager.GetTurretToBuild();
        turret = Instantiate(turretToBuild, positionTurret, transform.rotation);
    }

    public void BuildTurret(Turret turret)
    {
        if (this.turret != null)
            return;
        this.turret = Instantiate(turret, positionTurret, transform.rotation);
    }

    public void OnMouseEnter()
    {
        if (buildManager.GetTurretToBuild() == null)
            return;
        rend.material.color = hoverColor;
    }

    public void OnMouseExit()
    {
        rend.material.color = startColor;
    }

}
