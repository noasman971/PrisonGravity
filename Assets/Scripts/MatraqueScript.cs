using System;
using System.Linq;
using UnityEngine;

public class MatraqueScript : MonoBehaviour
{
    
    public GameObject player;
    private PlayerScript playerScript;
    private GuardScript guardScript;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        guardScript = transform.parent != null ? 
            transform.parent.GetComponentsInChildren<GuardScript>().FirstOrDefault(g => g.CompareTag("Guard")) : 
            null;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        
        else if (collision.gameObject.tag == "Player")
        {
            Destroy(player);
            Destroy(gameObject);
        }
        guardScript.hasAttacked = false;
        guardScript.setActiveMatraque();
        guardScript.timer = 0;
    }
    
}
