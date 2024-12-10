using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 2f;

    void Start()
    {
        // Tự động hủy viên đạn sau một khoảng thời gian
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Kiểm tra va chạm với người chơi
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hit Player!");
            Destroy(gameObject); // Hủy viên đạn
        }
    }
}
