using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float maxHealth; // Máu tối đa
    protected float currentHealth; // Máu hiện tại

    protected virtual void Start()
    {
        currentHealth = maxHealth; // Khởi tạo máu hiện tại
    }

    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage; // Trừ máu
        Debug.Log($"{gameObject.name} took {damage} damage. Current health: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die(); // Gọi phương thức chết nếu máu <= 0
        }
    }

    protected virtual void Die()
    {
        Debug.Log($"{gameObject.name} died!");
        Destroy(gameObject); // Hủy đối tượng zombie
    }
}
public class MeleeZombie : Zombie
{
    protected override void Start() // Sử dụng override
    {
        maxHealth = 100f; // Máu tối đa cho zombie đánh gần
        base.Start(); // Gọi phương thức khởi tạo của lớp cơ sở
    }

    // Có thể thêm các phương thức riêng cho zombie đánh gần
}
public class RangedZombie : Zombie
{
    protected override void Start() // Sử dụng override
    {
        maxHealth = 80f; // Máu tối đa cho zombie đánh xa
        base.Start(); // Gọi phương thức khởi tạo của lớp cơ sở
    }

    // Có thể thêm các phương thức riêng cho zombie đánh xa
}
public class TankZombie : Zombie
{
    protected override void Start() // Sử dụng override
    {
        maxHealth = 150f; // Máu tối đa cho zombie đỡ đòn
        base.Start(); // Gọi phương thức khởi tạo của lớp cơ sở
    }
}