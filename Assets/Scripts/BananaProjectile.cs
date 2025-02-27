using UnityEngine;

public class BananaProjectile : MonoBehaviour
{
    public float speed = 15f;
    public Vector2 direction;
    private Rigidbody2D rb;
    private float spawnTime;
    [SerializeField] private float immunity = 1f;


    private void Start()
    {
        spawnTime = Time.time;
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Guard"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Player"))
        {
            if (Time.time - spawnTime >= immunity)
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}