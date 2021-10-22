using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    private PlayerController player;

    [SerializeField] private PlayerController.Elements objectElement;
    private EarthPlatform earthPlatform;

    private void Awake()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        earthPlatform = GameObject.FindObjectOfType<EarthPlatform>();
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
                    earthPlatform.canMove = true;
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
