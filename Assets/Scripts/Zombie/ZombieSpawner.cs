using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab; // Prefab của zombie
    public float spawnInterval = 5f; // Thời gian giữa các lần spawn
    public int maxZombies = 10; // Số lượng zombie tối đa trong scene

    private int currentZombieCount = 0; // Số lượng zombie hiện tại

    private void Start()
    {
        // Bắt đầu coroutine để spawn zombie
        StartCoroutine(SpawnZombies());
    }

    private System.Collections.IEnumerator SpawnZombies()
    {
        while (true)
        {
            // Kiểm tra số lượng zombie hiện tại
            if (currentZombieCount < maxZombies)
            {
                SpawnZombie();
            }

            // Chờ một khoảng thời gian trước khi spawn tiếp
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnZombie()
    {
        // Tạo zombie tại vị trí của spawner
        Instantiate(zombiePrefab, transform.position, transform.rotation);
        currentZombieCount++; // Tăng số lượng zombie hiện tại
    }

    // Phương thức để giảm số lượng zombie khi một zombie chết
    public void OnZombieDeath()
    {
        currentZombieCount--;
    }
}