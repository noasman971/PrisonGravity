using UnityEngine;

public class GuardScript : MonoBehaviour
{
    public float matraqueSpeed = 10;
    public GameObject matraque;
    public GameObject player;
    private Vector3 direction;
    public float attackRate = 3;
    private float timer = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            throwAttack();
        }
        
        
        if (timer < attackRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            throwAttack();
            timer = 0;
        }
    }
    
    private void FixedUpdate()
    {
        
    }

    void throwAttack()
    {
        direction = (player.transform.position - transform.position).normalized;
        Destroy(matraque.GetComponent<FixedJoint2D>());
        matraque.GetComponent<Rigidbody2D>().AddForce(direction * matraqueSpeed);
    }
}
