using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject spawnPoint;

    public EnemieMovement redEnemy;

    public EnemieMovement blueEnemy;

    public GameObject vicotryCanvas;

    public bool oneTime = false;




    public enum SpawnState
    {
        SPAWNING, WAITING, COUTING
    };



    void OnEnable()
    {
        EnemieMovement.OnEnemyDeath += RegisterEnemyDeath;
    }

    void OnDisable()
    {
        EnemieMovement.OnEnemyDeath -= RegisterEnemyDeath;
    }

    public void RegisterEnemyDeath(EnemieMovement incomingEnemy)
    {
        if (incomingEnemy.enemyColor == EnemieMovement.BaloonColor.Blue)
        {
            Debug.Log("Wavespawner saw a blue balloon pop: SPAWNING RED ONE!");
            SpawnRedEnemy(incomingEnemy);  //incomingEnemy wordt hier NIET gespawened maar moet wel worden gepassed.
        }
        if(incomingEnemy.enemyColor == EnemieMovement.BaloonColor.Green)
        {

            SpawnBlueEnemy(incomingEnemy);
        }
    }

    [System.Serializable]
    public class Wave
    {
        //public Transform enemy;
        //public Transform enemy2;
        public List<EnemieMovement> allEnemies = new List<EnemieMovement>();
        public string name;
        //public int count;
        public float timeBetween;
        public int minRandomCount;
        public int maxRandomCount;


    }
    public List<Wave> waves = new List<Wave>();
    private int nextWave;

    public float timeBetweenWaves = 5f;
    private float waveCountDown = 5f;

    private float searchCountDown = 1f;

    private SpawnState state = SpawnState.COUTING;


    public void Start()
    {
        waveCountDown = timeBetweenWaves;
    }


    private void Update()
    {

        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleded();
            }
            else
            {
                return;
            }
        }
        if (GameManager.gameOver == false)
        {
            if (waveCountDown <= 0)
            {
                if (state != SpawnState.SPAWNING)
                {
                    StartCoroutine(SpawnWave(waves[nextWave]));
                }
            }
            else
            {
                waveCountDown -= Time.deltaTime;
            }
        }
        else
        {
            if (!oneTime)
            {
                Debug.Log("GameOver");
                oneTime = true;
            }
        }


    }

    void WaveCompleded()
    {
        Debug.Log("Wave Completed");

        state = SpawnState.COUTING;
        waveCountDown = timeBetweenWaves;

        if (nextWave + 1 > waves.Count - 1)
        {
            vicotryCanvas.SetActive(true);

            Debug.Log("You Done it you completed all the waves");
            state = SpawnState.SPAWNING;
        }
        else
        {
            GameObject[] foundObjects = GameObject.FindGameObjectsWithTag("EG");

            if (foundObjects.Length < 10)
            {

                foreach (GameObject go in foundObjects)
                {
                    Destroy(go);
                }
            }
            nextWave++;
        }

    }

    bool EnemyIsAlive()
    {
        searchCountDown -= Time.deltaTime;
        if (searchCountDown <= 0f)
        {
            searchCountDown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawing Wave " + _wave.name);
        state = SpawnState.SPAWNING;

        //for (int i = 0; i < _wave.count; i++)
        //for (int i = 0; i < _wave.allEnemies.Count; i++)
        //{
        yield return new WaitForSeconds(1f * _wave.timeBetween);

        EnemieMovement enemyBlue = _wave.allEnemies.Find(x => x.enemyColor == EnemieMovement.BaloonColor.Blue);
        if(enemyBlue != null)
        {
            SpawnEnemy(enemyBlue);
        }

        EnemieMovement enemygreen = _wave.allEnemies.Find(x => x.enemyColor == EnemieMovement.BaloonColor.Green);
        if (enemygreen != null)
        {
            SpawnEnemy(enemygreen);
        }
        yield return new WaitForSeconds(1f * _wave.timeBetween);

        int tempCounter = 0;
        if(_wave.minRandomCount > _wave.maxRandomCount)
        {
            _wave.minRandomCount = _wave.maxRandomCount - 1;
        }

        while (!GameManager.gameOver && tempCounter < Random.Range(_wave.minRandomCount, _wave.maxRandomCount))
        {
            tempCounter++;
            SpawnEnemy(_wave.allEnemies[Random.Range(0, _wave.allEnemies.Count)]);
            //SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f * _wave.timeBetween);
            //SpawnEnemy(_wave.enemy2);
            //yield return new WaitForSeconds(1f / _wave.rate);
            //}

            state = SpawnState.WAITING;
        }
            

        //yield break;
    }

    void SpawnEnemy(EnemieMovement _enemy)
    {
        Instantiate(_enemy, spawnPoint.transform.position, transform.rotation * Quaternion.Euler(-90, 0, 0));
    }

    void SpawnRedEnemy(EnemieMovement incomingEnemy)
    {
         //EnemieMovement tempEnemy = waves[nextWave].allEnemies.Find(x => x.enemyColor == EnemieMovement.BaloonColor.Red);
         if (redEnemy != null)
         {
         EnemieMovement enemyClone = Instantiate(redEnemy, incomingEnemy.transform.position, transform.rotation * Quaternion.Euler(-90, 0, 0));
            //enemyClone.target = incomingEnemy.target;
            //Debug.Log("WUTZ THA MAZZAPAKKING INDEX: " + incomingEnemy.wavePointIndex);
            enemyClone.SetNextWaypoint(incomingEnemy.wavePointIndex);
         }
    }

    void SpawnBlueEnemy(EnemieMovement incomingEnemy)
    {
        if (blueEnemy != null)
        {
            EnemieMovement enemyClone = Instantiate(blueEnemy, incomingEnemy.transform.position, transform.rotation * Quaternion.Euler(-90, 0, 0));
            enemyClone.SetNextWaypoint(incomingEnemy.wavePointIndex);

        }
    }

}