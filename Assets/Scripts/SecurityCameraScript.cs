using System;
using UnityEngine;

public class SecurityCameraScript : MonoBehaviour
{
    
    private LineRenderer lineRenderer;
    private PolygonCollider2D polyCollider;
    public GameObject GuardPrefab;
    public GameObject Player;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Vector3 parentPosition = transform.parent.position; 

            Vector3 newPosition = parentPosition + new Vector3(UnityEngine.Random.Range(20f, 40f), 0, 0);

            Instantiate(GuardPrefab, newPosition, Quaternion.identity);
            
            

        }
    }
    
    
    
}
