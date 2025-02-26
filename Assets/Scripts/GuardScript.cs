using System;
using UnityEngine;
using System.Linq;

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
        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        var closestWaypoints = waypoints
            .OrderBy(w => Vector3.Distance(transform.position, w.transform.position))
            .Take(2)
            .ToArray();

        addWaypoint(closestWaypoints[0]);
        addWaypoint(closestWaypoints[1]);
        if (closestWaypoints.Length > 0) Debug.Log("Waypoint le plus proche : " + closestWaypoints[0]);
        if (closestWaypoints.Length > 1) Debug.Log("Deuxième waypoint le plus proche : " + closestWaypoints[1]);
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, detectionRadius, playerLayer);

        
        if (hit != null)
        {
            target = hit.transform;
            Debug.Log(target.name);
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


    void addWaypoint(GameObject waypoint)
    {
        int oldSize = waypoints.Length;
        System.Array.Resize(ref waypoints, oldSize + 1);
        waypoints[oldSize] = waypoint.transform;
    }


    void GuardPath()
    {
        if (currentWaypoint <= waypoints.Length - 1)
        {
            Vector2 targetPosition = new Vector2(waypoints[currentWaypoint].transform.position.x, transform.position.y);
        
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        
            FlipTowardsTarget(waypoints[currentWaypoint].transform.position);

            if (Mathf.Approximately(transform.position.x, targetPosition.x))
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
