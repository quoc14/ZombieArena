//using System.Collections;
//using UnityEngine;

//public class EnemiesAI : MonoBehaviour
//{
//    private enum State
//    {
//        Roaming,
//        Chase,
//        Attack
//    }

//    private State state;
//    private EnemiesPath enemyPathfinding;

//    public Transform Player;
//    public float chaseRange = 5f;
//    public float attackRange = 1.5f;

//    private void Awake()
//    {
//        enemyPathfinding = GetComponent<EnemiesPath>();
//        state = State.Roaming;
//    }

//    private void Update()
//    {
//        float distanceToPlayer = Vector2.Distance(transform.position, Player.position);

//        if (distanceToPlayer <= attackRange)
//        {
//            state = State.Attack;
//        }
//        else if (distanceToPlayer <= chaseRange)
//        {
//            state = State.Chase;
//        }
//        else
//        {
//            state = State.Roaming;
//        }
//    }

//    private void FixedUpdate()
//    {
//        if (state == State.Chase)
//        {
//            Vector2 direction = (Player.position - transform.position).normalized;
//            enemyPathfinding.MoveTo(direction);
//        }
//        else if (state == State.Roaming)
//        {
//            StartCoroutine(RoamingRoutine());
//        }
//    }

//    private IEnumerator RoamingRoutine()
//    {
//        while (state == State.Roaming)
//        {
//            Vector2 roamPosition = GetRoamingPosition();
//            enemyPathfinding.MoveTo(roamPosition);
//            yield return new WaitForSeconds(2f);
//        }
//    }

//    private Vector2 GetRoamingPosition()
//    {
//        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
//    }
//}


//using UnityEngine;

//public class EnemiesAI : MonoBehaviour
//{
//    public Transform Player; // Tham chiếu đến người chơi
//    public float attackRange = 1.5f; // Khoảng cách để tấn công
//    private EnemiesPath enemyPathfinding;

//    private void Awake()
//    {
//        enemyPathfinding = GetComponent<EnemiesPath>();
//    }

//    private void FixedUpdate()
//    {
//        if (Player == null) return;

//        float distanceToPlayer = Vector2.Distance(transform.position, Player.position);

//        if (distanceToPlayer <= attackRange)
//        {
//            HandleAttack();
//        }
//        else
//        {
//            HandleChase();
//        }
//    }

//    private void HandleChase()
//    {
//        // Di chuyển về phía người chơi
//        Vector2 direction = (Player.position - transform.position).normalized;
//        enemyPathfinding.MoveTo(direction);
//    }

//    private void HandleAttack()
//    {
//        // Dừng di chuyển và tấn công
//        enemyPathfinding.MoveTo(Vector2.zero);
//        Debug.Log("Zombie is attacking the player!");
//    }
//}


//using UnityEngine;

//public class EnemiesAI : MonoBehaviour
//{
//    public Transform Player;  // Tham chiếu đến người chơi
//    public float attackRange = 1.5f;  // Khoảng cách để tấn công
//    public float chaseRange = 5f;    // Khoảng cách để bắt đầu đuổi theo
//    public float moveSpeed = 2f;     // Tốc độ di chuyển của zombie
//    public float raycastLength = 1f; // Khoảng cách kiểm tra vật cản

//    private EnemiesPath enemyPathfinding;

//    private void Awake()
//    {
//        enemyPathfinding = GetComponent<EnemiesPath>();
//    }

//    private void Update()
//    {
//        if (Player == null) return;

//        float distanceToPlayer = Vector2.Distance(transform.position, Player.position);

//        if (distanceToPlayer <= attackRange)
//        {
//            HandleAttack();
//        }
//        else if (distanceToPlayer <= chaseRange)
//        {
//            HandleChase();
//        }
//    }

//    private void HandleChase()
//    {
//        Vector2 direction = (Player.position - transform.position).normalized;

//        // Kiểm tra vật cản phía trước
//        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, raycastLength);

//        if (hit.collider != null) // Nếu có vật cản
//        {
//            // Tính hướng tránh vật cản (dựa trên hướng vuông góc)
//            Vector2 avoidanceDirection = Vector2.Perpendicular(hit.normal).normalized;

//            // Di chuyển theo hướng tránh vật cản
//            enemyPathfinding.MoveTo(avoidanceDirection);
//        }
//        else
//        {
//            // Nếu không có vật cản, di chuyển về phía người chơi
//            enemyPathfinding.MoveTo(direction);
//        }
//    }

//    private void HandleAttack()
//    {
//        // Dừng di chuyển và tấn công
//        enemyPathfinding.MoveTo(Vector2.zero);
//        Debug.Log("Zombie is attacking the player!");
//    }
//}

using UnityEngine;

public class EnemiesAI : MonoBehaviour
{
    public Transform Player;
    public float attackRange = 1.5f;
    public float chaseRange = 5f;

    private EnemiesPath enemyPathfinding;
    private bool isBlocked = false;
    private float blockCheckInterval = 0.5f;
    private float lastBlockCheckTime;

    private void Awake()
    {
        enemyPathfinding = GetComponent<EnemiesPath>();
    }

    private void Update()
    {
        if (Player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, Player.position);

        if (distanceToPlayer <= attackRange)
        {
            HandleAttack();
        }
        else if (distanceToPlayer <= chaseRange)
        {
            HandleChase();
        }
    }

    private void HandleChase()
    {
        Vector2 direction = (Player.position - transform.position).normalized;
        enemyPathfinding.MoveTo(direction);
    }

    private void HandleAttack()
    {
        enemyPathfinding.MoveTo(Vector2.zero);
        Debug.Log("Zombie is attacking the player!");
    }
}