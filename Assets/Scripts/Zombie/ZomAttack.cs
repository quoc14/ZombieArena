using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    [Header("Attack Configuration")]
    public float attackDamage = 10f; // Sát thương mỗi lần tấn công
    public float attackRange = 1.5f; // Phạm vi tấn công
    public float attackCooldown = 1f; // Thời gian giữa các lần tấn công

    [Header("References")]
    public Transform playerTransform; // Tham chiếu đến người chơi
    private Animator animator; // Animator của zombie

    private float lastAttackTime; // Thời gian tấn công cuối

    private void Awake()
    {
        animator = GetComponent<Animator>(); // Lấy component Animator
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position); // Tính khoảng cách đến người chơi

        if (distanceToPlayer <= attackRange)
        {
            TryAttackPlayer(); // Kiểm tra và thực hiện tấn công
        }
    }

    private void TryAttackPlayer()
    {
        if (Time.time - lastAttackTime >= attackCooldown) // Kiểm tra cooldown
        {
            PerformAttack(); // Thực hiện tấn công
        }
    }

    private void PerformAttack()
    {
        animator.SetTrigger("Attack"); // Kích hoạt hoạt ảnh tấn công
        lastAttackTime = Time.time; // Cập nhật thời gian tấn công cuối
    }

    // Phương thức được gọi từ Animation Event
    public void DealDamageToPlayer()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position); // Tính khoảng cách đến người chơi

        if (distanceToPlayer <= attackRange)
        {
            // Gây sát thương cho người chơi (chưa có logic xử lý sức khỏe)
            Debug.Log("Zombie dealt " + attackDamage + " damage to player!");
        }
    }
}