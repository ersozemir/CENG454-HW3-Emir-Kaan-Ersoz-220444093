using UnityEngine;

public interface IEnemyStrategy
{
    void ExecuteStrategy(Transform enemyTransform, Vector3 targetPosition, float speed);
}