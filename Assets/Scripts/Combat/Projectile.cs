using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifeTime = 3f;
    private float _timer;

    void OnEnable()
    {
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
            
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddScore(); // Increase score when an enemy is hit
            }

            Destroy(other.gameObject); 
            ObjectPool.Instance.ReturnToPool(gameObject);
        }
    }
}