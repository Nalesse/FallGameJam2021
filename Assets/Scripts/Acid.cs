using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Acid : MonoBehaviour
{
    public bool KillPlayer { get; set;}

    private void Start()
    {
        KillPlayer = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (KillPlayer)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }
}
