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
        if (Time.time >= _nextSpawnTime)
        {
            SpawnEnemy();
            _nextSpawnTime = Time.time + spawnRate;
        }
    }

    private void SpawnEnemy()
    {
        // Random position on a circle around the core target
        Vector3 spawnPos = Random.onUnitSphere * spawnDistance;
        spawnPos.y = 0.5f; // Keep enemies on the ground level

        // Create the enemy and get its script component
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        Enemy enemyScript = newEnemy.GetComponent<Enemy>();

        if (enemyScript != null)
        {
            // 3. Choose base strategy randomly (Linear or ZigZag)
            IEnemyStrategy baseStrategy = Random.value > 0.5f 
                ? new LinearMoveStrategy() 
                : new ZigZagMoveStrategy();

            // Apply decorators with certain probabilities
            if (Random.value < 0.3f)
            {
                // put the current strategy inside a SpeedDecorator to enhance speed
                baseStrategy = new SpeedDecorator(baseStrategy, 2.0f);
                
                // Make yellow the enemies that are faster than normal
                var renderer = newEnemy.GetComponent<Renderer>();
                if (renderer != null) renderer.material.color = Color.yellow;
            }

            // create enemy with the chosen strategy and initialize it with the core target
            enemyScript.Initialize(coreTarget, baseStrategy);
        }
    }
}