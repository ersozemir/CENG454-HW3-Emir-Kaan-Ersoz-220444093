using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform coreTarget;
    [SerializeField] private float spawnRate = 2f;
    [SerializeField] private float spawnDistance = 15f;

    private float _nextSpawnTime;

    void Update()
    {
        // If it's time to spawn a new enemy, do so and set the next spawn time
        if (Time.time >= _nextSpawnTime)
        {
            SpawnEnemy();
            _nextSpawnTime = Time.time + spawnRate;
        }
    }

    private void SpawnEnemy()
    {
        // Create a random position on a circle around the core target
        Vector3 spawnPos = Random.onUnitSphere * spawnDistance;
        spawnPos.y = 0; // To keep enemies on the ground

        GameObject newEnemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        Enemy enemyScript = newEnemy.GetComponent<Enemy>();

        if (enemyScript != null)
        {
            // Choose a strategy at random (%50 Linear, %50 ZigZag)
            IEnemyStrategy randomStrategy = Random.value > 0.5f 
                ? new LinearMoveStrategy() 
                : new ZigZagMoveStrategy();

            enemyScript.Initialize(coreTarget, randomStrategy);
        }
    }
}