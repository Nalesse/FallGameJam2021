using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private PlayerController player;

    [SerializeField] private PlayerController.Elements powerUpType;

    private void Awake()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.CurrentElement = powerUpType;
            this.player.AllowedJumps = this.player.JumpCount;
            Destroy(gameObject);
        }
    }
}
