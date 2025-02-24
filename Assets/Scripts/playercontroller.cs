using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.10f;
    public float gravityIntensity = 2.0f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityIntensity;
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal") * speed;
        transform.position += new Vector3(move, 0, 0);

        // Inversion de la gravité
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.gravityScale *= -1;
        }
    }
}
