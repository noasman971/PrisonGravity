using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.10f;
    public float gravityIntensity = 2.0f;
    public float cooldownTime = 0.5f;

    private Rigidbody2D rb;
    private float gravityTime = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityIntensity;
    }

    void Update()
    {

        float move = Input.GetAxis("Horizontal") * speed;
        transform.position += new Vector3(move, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > gravityTime)
        {
            rb.gravityScale *= -1;
            transform.Translate(Vector3.up * 0.5f);
            gravityTime = Time.time + cooldownTime;
        }
    }
}
