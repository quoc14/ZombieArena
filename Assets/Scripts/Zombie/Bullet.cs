using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 2f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Hit Player!");
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
