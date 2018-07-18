using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveSpawner : MonoBehaviour {

    public Transform enemyPrefab;
    public Transform spawnLoc;

    public float timeBetweenWaves = 5.0f;
    public float timeBetweenEnemySpawn = 0.5f;

    public Text waveCountdownText;

    private float countdown = 2.0f;
    private int waveNum = 0;

    void Update()
    {
        if(countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        waveCountdownText.text = Mathf.Ceil (countdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        waveNum++;

        for (int i = 0; i < waveNum; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(timeBetweenEnemySpawn);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnLoc.position, spawnLoc.rotation);
    }
}
