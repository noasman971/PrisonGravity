using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatraqueScript : MonoBehaviour
{
    
    public GameObject player;
    private PlayerScript playerScript;
    private GuardScript guardScript;
    public GameObject SceneTransition;
    public SceneController sceneController;


    private void Awake()
    {
        SceneTransition = GameObject.Find("GameManager");
    }

    void Start()
    {
        guardScript = transform.parent != null ? 
            transform.parent.GetComponentsInChildren<GuardScript>().FirstOrDefault(g => g.CompareTag("Guard")) : 
            null;
        player = GameObject.FindGameObjectWithTag("Player");
        sceneController = SceneTransition.GetComponent<SceneController>();
        
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
            Destroy(collision.gameObject);
            sceneController.RestartLevelDeath();
            
            Destroy(gameObject);

            
            
        }
        guardScript.hasAttacked = false;
        guardScript.setActiveMatraque();
        guardScript.timer = 0;
    }
    
}
