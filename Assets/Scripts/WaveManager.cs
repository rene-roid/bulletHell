using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public enum waveState { SPAWNING, WAITING, COUNTING };

    public List<Wave> waves;
    public float timeBetweenWaves = 5f;
    public float waveCountDown;
    public waveState state = waveState.COUNTING;

    private int nextWave = 0;
    private float searchEnemyCount = 1f;

    private void Start()
    {
        waveCountDown = timeBetweenWaves;
    }

    private void Update()
    {
        if (state == waveState.WAITING)
        {
            // Check if enemies are still alive
            if (!EnemyIsAlive())
            {
                // Next wave
                print("Wave completed");
                return;
            }

        }

        if (waveCountDown <= 0)
        {
            if (state != waveState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            } else
            {
                waveCountDown -= Time.fixedDeltaTime;
            }
        }
    }
    IEnumerator SpawnWave(Wave _wave)
    {
        state = waveState.SPAWNING;
        print("Spawning");
        // Spawn
        for (int i = 0; i < _wave.wProperties[i].quantity; i++)
        { 
            EnemySpawner(_wave.wProperties[i].enemies[Random.Range(0, _wave.wProperties[i].enemies.Length)]);
            yield return new WaitForSeconds(_wave.wProperties[i].delay);
        }

        state = waveState.WAITING;

        yield break;
    }

    private void EnemySpawner(Transform _enemy)
    {
        // Spawn enemy
        print(_enemy.name);
    }

    bool EnemyIsAlive()
    {
        searchEnemyCount -= Time.deltaTime;

        if (searchEnemyCount <= 0f)
        {
            searchEnemyCount = 1f;
            if (GameObject.FindGameObjectsWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }
}

[System.Serializable]
public class Wave
{
    public string waveName;
    public float waitTime;

    [System.Serializable]
    public class WaveProperties
    {
        public int quantity;
        public Transform[] enemies;
        public Transform[] spawns;
        public float delay;
    }

    public WaveProperties[] wProperties;
}