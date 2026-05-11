using UnityEngine;

public class LinearMoveStrategy : IEnemyStrategy
{
    public void ExecuteStrategy(Transform enemyTransform, Vector3 targetPosition, float speed)
    {
        enemyTransform.position = Vector3.MoveTowards(
            enemyTransform.position, 
            targetPosition, 
            speed * Time.deltaTime
        );
        
        // To look at the target while moving
        enemyTransform.LookAt(targetPosition);
    }
}