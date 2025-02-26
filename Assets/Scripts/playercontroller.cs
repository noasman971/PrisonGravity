using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioSource footstepSource; 
    public AudioSource gravitySource;  
    public AudioClip GravityDown;
    public AudioClip GravityUp;
    public AudioClip footstepSound;  
    
    public float decceleration;
    public float velPower;
    public float acceleration;
    private float moveInput;
    public float speed = 0.10f;
    public float gravityIntensity = 2.0f;
    public float cooldownTime = 0.5f;

    public CameraTr cameraShake;
    public bool up = false;
    public Animator animator;

    private Rigidbody2D rb;
    private float nextGravityChangeTime = 0f;
    
    public ParticleSystem gravityChangeParticles;

    void Start()
    {
        if (footstepSource == null)
            footstepSource = GetComponent<AudioSource>(); 
        
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityIntensity;
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float targetSpeed = speed * moveInput;
        float speedDif = targetSpeed - rb.linearVelocity.x;
        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : decceleration;
        float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, velPower) * Mathf.Sign(speedDif);
        rb.AddForce(Vector2.right * movement);
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        if (moveInput == 0)
        {
            animator.SetBool("Idle", true);
            animator.SetBool("Move", false);
            if (footstepSource.isPlaying && footstepSource.clip == footstepSound)
            {
                footstepSource.Stop();
            }
        }
        else
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Move", true);
            if (!footstepSource.isPlaying)
            {
                footstepSource.clip = footstepSound;
                footstepSource.loop = true;
                footstepSource.Play();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextGravityChangeTime)
        {
            rb.gravityScale *= -1;
            nextGravityChangeTime = Time.time + cooldownTime;
            
            if (gravityChangeParticles != null)
            {
                gravityChangeParticles.Play();
            }

            if (up)
            {
                gravitySource.PlayOneShot(GravityUp);
                transform.eulerAngles = new Vector3(0, 0, 0);
                up = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 180);
                gravitySource.PlayOneShot(GravityDown);
                up = true;
            }
        }

        Vector3 scale = transform.localScale;
        float originalX = Mathf.Abs(scale.x);

        if (moveInput > 0)
        {
            scale.x = up ? -originalX : originalX;
        }
        else if (moveInput < 0)
        {
            scale.x = up ? originalX : -originalX;
        }
        transform.localScale = scale;
    }
}
