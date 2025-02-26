using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikesDangerous : MonoBehaviour
{
    private GameObject GameManager;
    private SceneController sceneController;
    GameObject player;
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        sceneController = GameManager.GetComponent<SceneController>();
        player = GameObject.FindGameObjectWithTag("Player");

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(player);

            sceneController.ReloadLevel();
        }
    }

}
