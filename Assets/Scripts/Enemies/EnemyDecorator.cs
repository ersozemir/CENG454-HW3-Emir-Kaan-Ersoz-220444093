using UnityEngine;

public abstract class EnemyDecorator : IEnemyStrategy
{
    protected IEnemyStrategy _decoratedStrategy;

    public EnemyDecorator(IEnemyStrategy strategy)
    {
        _decoratedStrategy = strategy;
    }

    // Use the base strategy's movement logic, and then add additional behavior in the derived decorators
    public virtual void ExecuteStrategy(Transform transform, Vector3 target, float speed)
    {
        _decoratedStrategy.ExecuteStrategy(transform, target, speed);
    }
}