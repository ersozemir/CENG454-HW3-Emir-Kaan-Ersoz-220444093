using UnityEngine;

public class ZigZagMoveStrategy : IEnemyStrategy
{
    private float frequency = 5f; 
    private float magnitude = 2f; 

    public void ExecuteStrategy(Transform enemyTransform, Vector3 targetPosition, float speed)
    {
        Vector3 direction = (targetPosition - enemyTransform.position).normalized;
        Vector3 right = Vector3.Cross(Vector3.up, direction);
        
        Vector3 nextPos = enemyTransform.position + direction * speed * Time.deltaTime;
        nextPos += right * Mathf.Sin(Time.time * frequency) * magnitude * Time.deltaTime;
        
        enemyTransform.position = nextPos;
        enemyTransform.LookAt(targetPosition);
    }
}