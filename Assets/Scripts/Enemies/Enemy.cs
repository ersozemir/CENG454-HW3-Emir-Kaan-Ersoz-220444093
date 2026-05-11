using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float moveSpeed = 3f;
    
    private IEnemyStrategy _moveStrategy;
    private Transform _target;

    // When the enemy is initialized, we set its target and movement strategy
    public void Initialize(Transform target, IEnemyStrategy strategy)
    {
        _target = target;
        _moveStrategy = strategy;
    }

    void Update()
    {
        // When we have a target and a strategy, move towards the target
        if (_moveStrategy != null && _target != null)
        {
            _moveStrategy.ExecuteStrategy(transform, _target.position, moveSpeed);
        }
    }

    // Changing the strategy at runtime allows for dynamic behavior changes
    public void SetStrategy(IEnemyStrategy newStrategy)
    {
        _moveStrategy = newStrategy;
    }

    private void OnTriggerEnter(Collider other)
{
    // If the enemy collides with something that can take damage, apply damage and destroy itself
    IDamageable damageable = other.GetComponent<IDamageable>();

    if (damageable != null)
    {
        damageable.TakeDamage(10f); // Hit power is set to 10 for demonstration
        Destroy(gameObject);        // Destroy itself
    }
}
}