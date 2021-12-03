using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WaveManager : MonoBehaviour
{
    public enum spawnState { SPAWNING, WAITING, COUNTING, WAVESPAWNED };

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform[] enemy;
        public int enemyCount;
        public float spawnEnemyRate;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5.0f;
    public float waveCountDown = 0.0f;

    private float searchCountDown = 1f;

    public spawnState state = spawnState.COUNTING;

    public static bool levelCompleted = false;

    private void Awake()
    {
        levelCompleted = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        waveCountDown = timeBetweenWaves;

        if (spawnPoints.Length == 0)
        {
            Debug.Log("No spawnpoints");
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (state == spawnState.WAITING)
        {
            //if (!enemyIsAlive())
            //{
            //    waveCompleted();
            //}
            //else
            //{
            //    return;
            //}

            waveCompleted();
        }
        if (waveCountDown <= 0)
        {
            if (state != spawnState.SPAWNING && state != spawnState.WAVESPAWNED)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountDown -= Time.deltaTime;
        }

        if (state == spawnState.WAVESPAWNED && !enemyIsAlive())
        {
            levelCompleted = true;
        }
    }

    void waveCompleted()
    {
        Debug.Log("Wave Completed");

        state = spawnState.COUNTING;
        waveCountDown = timeBetweenWaves;

        if (nextWave + 1 >= waves.Length - 1 && !enemyIsAlive())
        {
            Debug.Log("You won");
            return;
        } else if (nextWave + 1 <= waves.Length - 1)
        {
            nextWave++;
        } else
        {
            Debug.Log("what");

            state = spawnState.WAVESPAWNED;
            return;
        }

    }

    bool enemyIsAlive()
    {
        searchCountDown -= Time.deltaTime;

        if (searchCountDown <= 0.0f)
        {

            searchCountDown = 1.0f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("spawingWave");
        state = spawnState.SPAWNING;

        for (int i = 0; i < _wave.enemyCount; i++)
        {
            for (int j = 0; j < _wave.enemy.Length; j++)
            {
                //SpawnEnemy(_wave.enemy[j]);
                Transform _spawnPoints = spawnPoints[j];

                Instantiate(_wave.enemy[j], _spawnPoints.position, Quaternion.identity);
            }
            // SpawnEnemy(_wave.enemy[Random.Range(0, _wave.enemy.Length)]);
            // yield return new WaitForSeconds(1f / _wave.spawnEnemyRate);
            yield return new WaitForSeconds(_wave.spawnEnemyRate);
        }

        state = spawnState.WAITING;

        yield break;
    }

    //void SpawnEnemy(Transform _enemy)
    //{
    //    print("spawning");

    //    Transform _spawnPoints = spawnPoints[Random.Range(0, spawnPoints.Length)];

    //    Instantiate(_enemy, _spawnPoints.position, _spawnPoints.rotation);
    //}
}

//public class WaveManager : MonoBehaviour
//{
//    public enum spawnState { SPAWNING, WAITING, COUNTING };

//    public Wave[] waves;
//    private int nextWave = 0;

//    public float timeBetweenWaves = 5.0f;
//    public float waveCountDown = 0.0f;

//    private float searchCountDown = 1f;

//    public spawnState state = spawnState.COUNTING;

//    private void Start()
//    {
//        waveCountDown = timeBetweenWaves;
//    }

//    private void Update()
//    {
//        if (state == spawnState.WAITING) // Waiting state
//        {
//            // If there are no enemies spawn
//            if (!IsEnemyAlive())
//            {
//                // Wave completed --> do next wave
//                WaveCompleted();
//            }
//        }

//        if (waveCountDown <= 0)
//        {
//            if (state != spawnState.SPAWNING && state == spawnState.COUNTING) // If wave countdown has finished and it is not spawning state
//            {
//                // Spawn
//                StartCoroutine(SpawnWave(waves[nextWave]));
//            }

//        } else
//        {
//            waveCountDown -= Time.deltaTime; // If not do countdown
//        }
//    }

//    IEnumerator SpawnWave(Wave _wave)
//    {
//        print("Spawning");
//        state = spawnState.SPAWNING;

//        for (int i = 0; i < _wave.properties[i].quantity - 1; i++)
//        {
//            // Instantiate enemies
//            for (int j = 0; j < _wave.properties[i].enemies.Length - 1; j++)
//            {
//                // Transform _spawns = _wave.properties[i].spawns[j]; // Select spawn correspoinding to the enemy that is going to be instantiated
//                // Enemy 1 --> spawns in -- Spawn1...

//                // Instantiate enemy
//                Instantiate(_wave.properties[i].enemies[j], _wave.properties[i].spawns[j].transform.position, Quaternion.identity);
//            }

//            // Delay between group of enemies instatiated
//            // yield return new WaitForSeconds(_wave.properties[i].delay);
//            new WaitForSeconds(_wave.properties[i].delay);
//        }

//        state = spawnState.WAITING; // Spawned all enemies --> state changed to wating
//        yield break;
//    }

//    private void InstantiateEnemies()
//    {

//    }

//    bool IsEnemyAlive()
//    {
//        searchCountDown -= Time.deltaTime; // Countdown to do not overload the search enemy

//        if (searchCountDown >=0)
//        {
//            searchCountDown = 1f;
//            if (GameObject.FindGameObjectWithTag("Enemy") == null)
//            {
//                return false; // Enemy is dead
//            } else
//            {
//                return true;
//            }
//        }
//        return true; // Enemy is alive
//    }

//    private void WaveCompleted()
//    {
//        print("Wave completed");

//        state = spawnState.COUNTING; // Started counting (Time between waves)
//        waveCountDown = timeBetweenWaves;

//        if (nextWave + 1 > waves.Length - 1)
//        {
//            print("You won, game ended");
//            return;
//        } else
//        {
//            nextWave++; // Do next wave
//        }

//    }

//}

//[System.Serializable]
//public class Wave
//{
//    public string waveName;

//    [System.Serializable]
//    public class WaveProperties
//    {
//        public int quantity;
//        public Transform[] enemies;
//        public Transform[] spawns;
//        public float delay;
//    }

//    public WaveProperties[] properties;
//}