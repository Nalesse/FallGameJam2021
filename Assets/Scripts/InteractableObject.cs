using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    private PlayerController player;

    [SerializeField] private PlayerController.Elements objectElement;

    private void Awake()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
    }

    private void OnMouseDown()
    {

        if (objectElement != player.CurrentElement)
        {
            Debug.Log("Wrong element type");
        }

        if (objectElement == player.CurrentElement)
        {
            if (!(Vector2.Distance(player.transform.position, transform.position) <= 6))
            {
                Debug.Log("Too far away");
                return;
            }

            if (player.CurrentElement == PlayerController.Elements.Ice)
            {
                this.GetComponent<BoxCollider2D>().isTrigger = false;
                this.GetComponent<SpriteRenderer>().color = new Color32(130, 241, 248, 108);
                Debug.Log("Froze water");
            }
            else if (player.CurrentElement == PlayerController.Elements.Earth)
            {
                this.GetComponent<EarthPlatform>().enabled = true;
                this.GetComponent<SpriteRenderer>().color = new Color32(9, 149, 41, 255);
                Debug.Log("Move earth platform");
            }
            else if (player.CurrentElement == PlayerController.Elements.Fire)
            {
                Destroy(this.gameObject);
                Debug.Log("Object burned");
            }
            else if (player.CurrentElement == PlayerController.Elements.Wind)
            {
                // double jump and higher jump force
            }
        }
    }
}
