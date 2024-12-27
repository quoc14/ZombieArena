//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnemiesPath : MonoBehaviour
//{
//    [SerializeField] private float moveSpeed = 2f;

//    private Rigidbody2D rb;
//    private Vector2 moveDir;

//    private void Awake()
//    {
//        rb = GetComponent<Rigidbody2D>();
//    }

//    private void FixedUpdate()
//    {
//        rb.MovePosition(rb.position + moveDir * (moveSpeed * Time.fixedDeltaTime));
//    }

//    public void MoveTo(Vector2 targetPosition)
//    {
//        moveDir = targetPosition;
//    }
//}

//using UnityEngine;

//public class EnemiesPath : MonoBehaviour
//{
//    [SerializeField] private float moveSpeed = 2f;
//    [SerializeField] private LayerMask obstacleLayer;
//    [SerializeField] private float obstacleAvoidanceDistance = 1f;

//    private Rigidbody2D rb;
//    private Vector2 moveDir;

//    private void Awake()
//    {
//        rb = GetComponent<Rigidbody2D>();
//    }

//    private void FixedUpdate()
//    {
//        Vector2 adjustedMoveDir = AvoidObstacles(moveDir);
//        rb.MovePosition(rb.position + adjustedMoveDir * (moveSpeed * Time.fixedDeltaTime));
//    }

//    public void MoveTo(Vector2 targetDirection)
//    {
//        moveDir = targetDirection;
//    }

//    private Vector2 AvoidObstacles(Vector2 direction)
//    {
//        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, obstacleAvoidanceDistance, obstacleLayer);

//        if (hit.collider != null)
//        {
//            // Tìm hướng mới để tránh vật cản
//            Vector2 avoidanceDirection = Vector2.Perpendicular(hit.normal).normalized;
//            return avoidanceDirection * moveSpeed;
//        }

//        return direction;
//    }
//}


//using UnityEngine;

//public class EnemiesPath : MonoBehaviour
//{
//    [SerializeField] private float moveSpeed = 2f;  // Tốc độ di chuyển của zombie

//    private Rigidbody2D rb;
//    private Vector2 moveDir;

//    private void Awake()
//    {
//        rb = GetComponent<Rigidbody2D>();
//    }

//    private void FixedUpdate()
//    {
//        rb.MovePosition(rb.position + moveDir * (moveSpeed * Time.fixedDeltaTime));  // Di chuyển zombie
//    }

//    public void MoveTo(Vector2 targetDirection)
//    {
//        moveDir = targetDirection;  // Cập nhật hướng di chuyển
//    }
//}
using UnityEngine;

public class EnemiesPath : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float obstacleAvoidanceRadius = 1f;
    [SerializeField] private LayerMask obstacleLayer;

    private Rigidbody2D rb;
    private Vector2 moveDir;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 finalMoveDir = CalculateObstacleAvoidance(moveDir);
        rb.MovePosition(rb.position + finalMoveDir * (moveSpeed * Time.fixedDeltaTime));
    }

    public void MoveTo(Vector2 targetDirection)
    {
        moveDir = targetDirection.normalized;
    }

    private Vector2 CalculateObstacleAvoidance(Vector2 originalDirection)
    {
        // Kiểm tra vật cản xung quanh
        Collider2D[] obstacles = Physics2D.OverlapCircleAll(rb.position, obstacleAvoidanceRadius, obstacleLayer);

        if (obstacles.Length > 0)
        {
            Vector2 avoidanceVector = Vector2.zero;

            foreach (Collider2D obstacle in obstacles)
            {
                Vector2 awayFromObstacle = (rb.position - (Vector2)obstacle.transform.position).normalized;
                avoidanceVector += awayFromObstacle;
            }

            avoidanceVector = avoidanceVector.normalized;
            return Vector2.Lerp(originalDirection, avoidanceVector, 0.5f);
        }

        return originalDirection;
    }

    // Debug visualization
    private void OnDrawGizmosSelected()
    {
        if (rb != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(rb.position, obstacleAvoidanceRadius);
        }
    }
}