using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifeTime = 3f;
    private float _timer;

    void OnEnable()
    {
        // Reset state when activated
        _timer = lifeTime;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            ObjectPool.Instance.ReturnToPool(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Damage logic
            Destroy(other.gameObject); 
            // Send back to pool
            ObjectPool.Instance.ReturnToPool(gameObject);
        }
    }
}