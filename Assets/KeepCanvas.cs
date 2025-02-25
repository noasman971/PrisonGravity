using System;
using UnityEngine;

public class KeepCanvas : MonoBehaviour
{
    private static KeepCanvas instance; // Utilisation d'une instance de la classe
    /*
     * KeyDown un bool en false
     * KeyUp un bool true
     * si false lanimation
     * si true lanimation s'arrete
     */
    bool isRunning = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isRunning = true;
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            isRunning = false;
            
        }

        if (isRunning)
        {
            // je lance lanimation
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
