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
    public Animator animator;

    private Rigidbody2D rb;
    private float nextGravityChangeTime = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityIntensity;
        animator = GetComponent<Animator>();
    }

    void Update()
    {


        float move = Input.GetAxis("Horizontal") * speed;
        transform.position += new Vector3(move, 0, 0);
        if(move == 0){
            animator.SetBool("Idle", true);
            animator.SetBool("Move", false);
        } else {
            animator.SetBool("Idle", false);
            animator.SetBool("Move", true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextGravityChangeTime)
        {
            rb.gravityScale *= -1;
            nextGravityChangeTime = Time.time + cooldownTime;

            if (up)
            {
                audioSource.clip = GravityUp;
                audioSource.Play();
                transform.eulerAngles = new Vector3(0, 0, 0);
                up = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 180);
                audioSource.clip = GravityDown;
                audioSource.Play();
                up = true;
            }
        }


        Vector3 scale = transform.localScale;
        float originalX = Mathf.Abs(scale.x);

        if (move > 0)
        {
            scale.x = up ? -originalX : originalX;
        }
        else if (move < 0)
        {

            scale.x = up ? originalX : -originalX;
        }

        transform.localScale = scale;
    }
}