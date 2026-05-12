using UnityEngine;

public class SpeedDecorator : EnemyDecorator
{
    private float _speedMultiplier;

    public SpeedDecorator(IEnemyStrategy strategy, float multiplier) : base(strategy)
    {
        _speedMultiplier = multiplier;
    }

    public override void ExecuteStrategy(Transform transform, Vector3 target, float speed)
    {
        // Multiply the base speed by the speed multiplier to enhance the enemy's movement speed
        float enhancedSpeed = speed * _speedMultiplier;
        base.ExecuteStrategy(transform, target, enhancedSpeed);
    }
}