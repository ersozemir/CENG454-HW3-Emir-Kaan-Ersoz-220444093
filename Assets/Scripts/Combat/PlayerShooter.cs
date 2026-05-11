using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private float fireRate = 0.3f; // Ateş hızı
    private float _nextFireTime;

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= _nextFireTime)
        {
            _nextFireTime = Time.time + fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Bullet exit point
            // If the core is at (0,0,0) and the gun is slightly above it, we can set the fire point accordingly
            Vector3 firePoint = new Vector3(0, 0.2f, 0);

            // Calculate direction from fire point to hit point
            Vector3 direction = (hit.point - firePoint).normalized;
            direction.y = 0; // Bullet should only move horizontally

            // Shoot the projectile towards the hit point
            // Quaternion.LookRotation turns the projectile to face the direction it will be moving
            ObjectPool.Instance.GetFromPool(firePoint, Quaternion.LookRotation(direction));
        }
    }
}