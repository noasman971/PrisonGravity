using System;
using UnityEngine;

public class GuardScript : MonoBehaviour
{
    public float matraqueSpeed = 300;
    public float matraqueRotationSpeed = 100f;
    public GameObject matraque;
    public GameObject parent;
    public GameObject player;
    private Vector3 direction;
    public float attackRate = 3;
    public float timer = 0;
    public GameObject matraquePrefab;
    public bool hasAttacked = false;
    public float detectionRadius = 10f;
    public LayerMask playerLayer;
    private Transform target;

    [SerializeField]
    private Transform[] waypoints;

    [SerializeField]
    private float moveSpeed = 2f;
    
    private int currentWaypoint = 0;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log("ALALLALALALA: " + GameObject.FindGameObjectWithTag("Player"));
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, detectionRadius, playerLayer);
        Debug.Log(hit);
        Debug.Log("ALALLALALALA: " + player);

        if (hit != null)
        {
            target = hit.transform;
            Debug.Log("Joueur détecté !");
            FlipTowardsTarget(player);
            
            if (timer > attackRate && !hasAttacked)
            {
                timer = 0;
                throwAttack();
                hasAttacked = true;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
        else
        {
            GuardPath();
        }
    }
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
    
    private void FixedUpdate()
    {
        
    }

    void throwAttack()
    {
        if (!hasAttacked)
        {
            direction = (player.transform.position - matraque.transform.position).normalized;
            matraque.SetActive(false);
            Rigidbody2D rb = Instantiate(matraquePrefab, matraque.transform.position, matraque.transform.rotation, transform.parent)
                .GetComponent<Rigidbody2D>();

            rb.AddForce(direction * matraqueSpeed);
            rb.AddTorque(matraqueRotationSpeed); // Rotation de la matraque lancée


            
        }
    }

    public void setActiveMatraque()
    {
        matraque.SetActive(true);
    }
    
     void FlipTowardsTarget(Transform target)
    {
        FlipTowardsTarget(target.position);
    }

     void FlipTowardsTarget(GameObject target)
    {
        FlipTowardsTarget(target.transform.position);
    }

    void FlipTowardsTarget(Vector3 targetPosition)
    {
        float halfWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2f;
    
        float rightEdge = transform.position.x + halfWidth;
        float leftEdge = transform.position.x - halfWidth;

        if (targetPosition.x > rightEdge)
            transform.rotation = Quaternion.Euler(0, 0, 0); // Regarde à droite
        else if (targetPosition.x < leftEdge)
            transform.rotation = Quaternion.Euler(0, 180, 0); // Regarde à gauche
    }




    void GuardPath()
    {
        if (currentWaypoint <= waypoints.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, 
                waypoints[currentWaypoint].transform.position, 
                moveSpeed * Time.deltaTime);
            
            FlipTowardsTarget(waypoints[currentWaypoint]);

            if (transform.position == waypoints[currentWaypoint].transform.position)
            {
                currentWaypoint++;
            }
        }
        else
        {
            currentWaypoint = 0;
        }
    }
}
