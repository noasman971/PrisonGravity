using System;
using UnityEngine;

public class MatraqueScript : MonoBehaviour
{
    
    public GameObject player;
    private PlayerScript playerScript;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            Destroy(player);
            Destroy(gameObject);
        }
    }
    
}
