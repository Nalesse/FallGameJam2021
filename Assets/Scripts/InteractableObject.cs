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

            switch (this.player.CurrentElement)
            {
                case PlayerController.Elements.Ice:
                    this.GetComponent<BoxCollider2D>().isTrigger = false;
                    this.GetComponent<SpriteRenderer>().color = new Color32(130, 241, 248, 108);
                    Debug.Log("Froze water");
                    break;
                case PlayerController.Elements.Earth:
                    this.GetComponent<EarthPlatform>().enabled = true;
                    this.GetComponent<SpriteRenderer>().color = new Color32(9, 149, 41, 255);
                    Debug.Log("Move earth platform");
                    break;
                case PlayerController.Elements.Fire:
                    Destroy(this.gameObject);
                    Debug.Log("Object burned");
                    break;
            }
        }
    }
}
