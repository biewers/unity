using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
    [Header("Gameflow Properties")]
    public float timeBetweenWaves = 5.0f;
    public float counter;
    public int wave = 0;
    public bool waveStarting;

    [Header("Game Objects")]
    public GameObject player;
    public GameObject enemyPrefab;

    [Header("UI Game Objects")]
    public Text waveNumberText;
    public Text waveCountdownText;

    [Header("Enemy Spawning Attributes")]
    public float spawnRadius;
    public GameObject spawner;

    [Header("Other")]
    public float pointsAwardedPerRound = 100.0f;
    public float pointMultiplierPerRound = 1.3f;

    private void Awake()
    {
        spawner = GameObject.FindGameObjectWithTag("Spawner");
    }

    private void Start()
    {
        waveNumberText.text = wave.ToString();
        StartCoroutine(NextRound());
    }

    private void Update()
    {
        if(waveStarting)
        {
            counter -= Time.deltaTime;

            int x = (int) Mathf.Floor(counter);
            x = (int) Mathf.Clamp(x, 0, counter);
            waveCountdownText.text = x.ToString();
        }
        else
        {
            if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                StartCoroutine(NextRound());
            }
         }
    }

    public void SpawnEnemy(Transform transform, Vector3 randomPos)
    {
        Instantiate(enemyPrefab, transform.position + randomPos, transform.rotation);
    }

    public IEnumerator NextRound()
    {
        if (wave != 0)
        {
            player.GetComponent<Player>().AddPoints(pointsAwardedPerRound);
            pointsAwardedPerRound *= pointMultiplierPerRound;
        }

        waveStarting = true;
        waveCountdownText.enabled = true;

        LightState ls = FindObjectOfType<LightState>();
        ls.SetNewRoundColor(ls.newRoundColorOne);
        ls.waveStarting = true;

        counter = timeBetweenWaves;
        yield return new WaitForSeconds(timeBetweenWaves);

        ls.waveStarting = false;
        ls.SetNewRoundColor(ls.currentRoundColor);

        wave++;
        for(int i = 0; i < wave; i++)
        {
            SpawnEnemy(spawner.transform, GetRandomPosition());
        }

        waveNumberText.text = wave.ToString();
        waveCountdownText.enabled = false;

        waveStarting = false;
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 pos = Vector3.zero;
        float rand = Random.Range(-1, 1);

        if(rand >= 0)
        {
            pos = new Vector3(spawnRadius, 1, Random.Range(-spawnRadius, spawnRadius));

        }
        else if(rand < 0)
        {
            pos = new Vector3(Random.Range(-spawnRadius, spawnRadius), 1, spawnRadius);
        }

        return pos;
    }
}
