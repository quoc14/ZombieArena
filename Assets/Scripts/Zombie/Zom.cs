using System.Collections;
using UnityEngine;

public class ZombieShooter : MonoBehaviour
{
    public GameObject bulletPrefab;      // Prefab của viên đạn
    public Transform player;            // Vị trí người chơi
    public float shootInterval = 5f;    // Khoảng thời gian giữa các lần bắn
    public float bulletSpeed = 10f;     // Tốc độ bay của viên đạn

    void Start()
    {
        StartCoroutine(ShootAtPlayer());
    }

    IEnumerator ShootAtPlayer()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootInterval); // Chờ 5 giây
            Shoot(); // Gọi hàm bắn đạn
        }
    }

    private void Shoot()
    {
        if (bulletPrefab != null && player != null)
        {
            // Tạo viên đạn tại vị trí của zombie
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            // Kiểm tra và gán Rigidbody2D cho viên đạn
            Rigidbody2D rb2d = bullet.GetComponent<Rigidbody2D>();
            if (rb2d != null)
            {
                // Tính toán hướng từ zombie đến người chơi
                Vector2 direction = (player.position - transform.position).normalized;

                // Áp dụng vận tốc để viên đạn bay về phía người chơi
                rb2d.velocity = direction * bulletSpeed;
            }
            else
            {
                Debug.LogError("Bullet prefab thiếu Rigidbody2D!");
            }
        }
        else
        {
            Debug.LogWarning("Chưa thiết lập bulletPrefab hoặc player!");
        }
    }
}
