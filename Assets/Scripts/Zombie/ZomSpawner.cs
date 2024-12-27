using System.Collections;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab; // Prefab của zombie
    public Transform[] spawnPoints; // Các điểm spawn zombie
    public int initialWaveSize = 5; // Số lượng zombie ở đợt đầu tiên
    public float timeBetweenWaves = 10f; // Thời gian giữa các đợt
    public float spawnInterval = 0.5f; // Thời gian giữa mỗi lần spawn zombie

    private int currentWave = 0; // Số thứ tự đợt hiện tại

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        while (true) // Lặp vô hạn (hoặc bạn có thể thêm điều kiện dừng)
        {
            currentWave++; // Tăng số thứ tự đợt
            int zombiesToSpawn = initialWaveSize + (currentWave - 1) * 5; // Tăng số lượng zombie mỗi đợt

            Debug.Log($"Wave {currentWave} - Spawning {zombiesToSpawn} zombies!");

            // Sinh zombie của đợt hiện tại
            for (int i = 0; i < zombiesToSpawn; i++)
            {
                Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)]; // Chọn ngẫu nhiên điểm spawn
                Instantiate(zombiePrefab, spawnPoint.position, spawnPoint.rotation); // Sinh zombie

                yield return new WaitForSeconds(spawnInterval); // Đợi trước khi sinh zombie tiếp theo
            }

            // Chờ trước khi bắt đầu đợt mới
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }
}
