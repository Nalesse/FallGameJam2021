using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    private PlayerController player;

    public enum ObjectElement
    {
        /// <summary>
        /// No ability equipped
        /// </summary>
        None,

        /// <summary>
        /// Burns obstacles
        /// </summary>
        Fire,

        /// <summary>
        /// To be Determined
        /// </summary>
        Wind,

        /// <summary>
        /// Freezes water
        /// </summary>
        Ice,

        /// <summary>
        /// Shoots platforms
        /// </summary>
        Earth
    }

    [field: SerializeField]
    public ObjectElement Element { get; set; }

    private void Awake()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") & player.gameObject.GetComponent<PlayerController>().CurrentElement == PlayerController.Elements.Fire)
        {
            Destroy(gameObject);
        }
    }*/

    void OnMouseDown()
    {
        if ((int)gameObject.GetComponent<InteractableObject>().Element != (int)player.gameObject.GetComponent<PlayerController>().CurrentElement)
        {
            print("Wrong element type");
        }


        if (Vector3.Distance(player.transform.position, transform.position) <= 4 & (int)gameObject.GetComponent<InteractableObject>().Element == (int)player.gameObject.GetComponent<PlayerController>().CurrentElement)
        {
            print("Success!");
            Destroy(gameObject);
        }
        else
        {
            if ((int)gameObject.GetComponent<InteractableObject>().Element == (int)player.gameObject.GetComponent<PlayerController>().CurrentElement)
            {
                print("Too far away");
            }   
        }
           
    }
}
