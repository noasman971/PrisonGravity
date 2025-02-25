using System;
using UnityEngine;

public class SecurityCameraScript : MonoBehaviour
{
    
    private LineRenderer lineRenderer;
    private PolygonCollider2D polyCollider;
    public float timer = 0;
    public float rotationTimer = 6;
    
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
            Debug.Log("Player entered");
        }
    }
    
    
    
}
