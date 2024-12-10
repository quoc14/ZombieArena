using UnityEngine;
using System.Collections;

public class ZombieShooting : MonoBehaviour
{
    public GameObject bulletPrefab;  // Prefab viên đạn
    public Transform firePoint;      // Vị trí bắn đạn
    public Transform player;         // Người chơi
    public float bulletSpeed = 20f;  // Tốc độ viên đạn
    public float shootInterval = 5f; // Thời gian giữa các lần bắn

    private void Start()
    {
        StartCoroutine(ShootPeriodically());
    }

    IEnumerator ShootPeriodically()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootInterval); // Chờ 5 giây
            Shoot(); // Gọi hàm bắn
        }
    }

    private void Shoot()
    {
        if (bulletPrefab != null && firePoint != null && player != null)
        {
            // Tạo viên đạn tại vị trí FirePoint
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            // Gắn Rigidbody và thêm vận tốc
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 direction = (player.position - firePoint.position).normalized;
                rb.velocity = direction * bulletSpeed;
                Debug.Log("Viên đạn bắn theo hướng: " + direction);
            }
            else
            {
                Debug.LogWarning("Viên đạn không có Rigidbody!");
            }
        }
        else
        {
            Debug.LogWarning("Chưa thiết lập bulletPrefab, firePoint hoặc player!");
        }
    }
}
