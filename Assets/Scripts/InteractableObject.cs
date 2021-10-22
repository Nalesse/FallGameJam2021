using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    private PlayerController player;
    private BoxCollider2D objectCollider;
    private SpriteRenderer objectSprite;
    private EarthPlatform earthPlatform;
    private Acid acid;


    [SerializeField] private PlayerController.Elements objectElement;

    private void Awake()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        objectCollider = this.gameObject.GetComponent<BoxCollider2D>();
        objectSprite = this.gameObject.GetComponent<SpriteRenderer>();
        earthPlatform = GameObject.FindObjectOfType<EarthPlatform>();
        acid = GameObject.FindObjectOfType<Acid>();
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

            switch (player.CurrentElement)
            {
                case PlayerController.Elements.Ice:
                    acid.KillPlayer = false;
                    Debug.Log("Froze water");
                    break;
                case PlayerController.Elements.Earth:
                    this.earthPlatform.canMove = true;
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
