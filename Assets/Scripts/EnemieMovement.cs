using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieMovement : MonoBehaviour
{
    public enum BaloonColor { Blue,Red,Green, }
    public BaloonColor enemyColor;

    public delegate void EnemyDelegate(EnemieMovement diedEnemy);
    public static event EnemyDelegate OnEnemyDeath;

    public static bool isDead = false;

    public float speed = 10f;

    public Transform target;
    public int wavePointIndex = 0;

    public int health = 2;
    public int damage;
    

    public int scoreValue = 5;

    private void Start()
    {
        if(target == null)
        {
            target = WayPoints.points[0];
        }
        
    }

    private void Update()
    {
         
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
        if(health <= 0) {

            if(OnEnemyDeath != null)
            {
                OnEnemyDeath(this);
            }
            ScoreSystem.score += scoreValue;
            this.gameObject.SetActive(false);
        }
    }

    public void GetNextWaypoint()
    {
        if(wavePointIndex >= WayPoints.points.Length - 1)
        {
            GameManager.Instance.health -= damage;

            Destroy(gameObject);
            return;
        }
        wavePointIndex++;
        target = WayPoints.points[wavePointIndex];
    }

    public void SetNextWaypoint(int indexToGoTo)
    {
        Debug.Log(indexToGoTo);
        //if (wavePointIndex >= WayPoints.points.Length - 1)
        //{
        //    Destroy(gameObject);
        //    return;
        //}
        //wavePointIndex++;
        wavePointIndex = indexToGoTo;
        target = WayPoints.points[wavePointIndex];
    }

}
