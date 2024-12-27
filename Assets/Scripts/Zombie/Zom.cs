using System.Collections;
using UnityEngine;

public class ZombieShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform player;
    public float shootInterval = 3f;
    public float bulletSpeed = 10f;
    public float attackRange = 5f;

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange)
        {
            StopAllCoroutines();
            StartCoroutine(ShootAtPlayer());
        }
    }

    private IEnumerator ShootAtPlayer()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootInterval);
            Shoot();
        }
    }

    private void Shoot()
    {
        if (bulletPrefab != null && player != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb2d = bullet.GetComponent<Rigidbody2D>();
            if (rb2d != null)
            {
                Vector2 direction = (player.position - transform.position).normalized;
                rb2d.velocity = direction * bulletSpeed;
            }
            else
            {
                Debug.LogError("Bullet prefab thiếu Rigidbody2D!");
            }
        }
    }
}
