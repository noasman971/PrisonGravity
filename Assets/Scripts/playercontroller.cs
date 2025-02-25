using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip GravityDown;
    public AudioClip GravityUp;
    
    
    public float speed = 0.10f;
    public float gravityIntensity = 2.0f;
    public float cooldownTime = 0.5f;
    public CameraTr cameraShake;
    public bool up = false;

    private Rigidbody2D rb;
    private float nextGravityChangeTime = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityIntensity;
    }

    void Update()
    {

        float move = Input.GetAxis("Horizontal") * speed;
        transform.position += new Vector3(move, 0, 0);


        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextGravityChangeTime)
        {
            rb.gravityScale *= -1;
            nextGravityChangeTime = Time.time + cooldownTime;
            if (up)
            {
                audioSource.clip = GravityUp;
                audioSource.Play();
                up = false;
            }
            else
            {
                audioSource.clip = GravityDown;
                audioSource.Play();
                up = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Ceiling"))
        {
            //cameraShake.TriggerShake();
        }
    }
}
