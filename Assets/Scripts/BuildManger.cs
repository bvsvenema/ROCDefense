using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BuildManger : MonoBehaviour
{

    public delegate void TurretBuildDelegate(Turret turret);
    public static event TurretBuildDelegate TurretBuildEvent;

    public static BuildManger instance;
    private Camera cam;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Stop it there are 2 build managers");
            return;
        }
        instance = this;
    }

    private void Start()
    {
        cam = Camera.main;
    }

    //public Turret turret1;
    //public Turret turret2;
    //public Turret turret3;
    public List<Turret> allTurrets = new List<Turret>();
    public List<BuletMovement> allBullets = new List<BuletMovement>();

    private Turret turretToBuild;

    public Turret GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SetTurretToBuild(Turret turret)
    {
        //turretToBuild = turret;
        turretToBuild = allTurrets.Find(x => x.name == turret.name);

    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (turretToBuild == null)
                return;

            RaycastHit[] hits = Physics.RaycastAll(cam.ScreenPointToRay(Input.mousePosition));
            Node n = null;
            foreach (RaycastHit hit in hits)
            {
                n = hit.collider.gameObject.GetComponent<Node>();
                if (n != null)
                    break;
            }
            if(n != null && ScoreSystem.score > turretToBuild.turretCost)
            {
                n.BuildTurret(turretToBuild);
                TurretBuildEvent?.Invoke(turretToBuild);
                turretToBuild = null;
            }
        }
    }
}
