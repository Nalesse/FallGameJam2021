using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthPlatform : MonoBehaviour
{
    public bool Activated { get; set; }

    [SerializeField] private Vector2 endPosition;
    [SerializeField] private Vector2 startPosition;
    [SerializeField] private float moveSpeed;

    [SerializeField] private bool moveUp;

    public bool canMove;

    private PlayerController player;

    private void Awake()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    private void Update()
    {
        MovePlatform();
    }

    private void MovePlatform()
    {

        if (!canMove)
        {
            return;
        }

        // Using Math.Abs to avoid floating point comparison issues
        if (Math.Abs(transform.position.y - startPosition.y) < .01)
        {
            moveUp = true;
        }
        else if (Math.Abs(transform.position.y - endPosition.y) < .01)
        {
            moveUp = false;
        }

        if (moveUp)
        {
            transform.position = Vector2.MoveTowards(transform.position, endPosition, moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, startPosition, moveSpeed * Time.deltaTime);
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //canMove = true;
            other.transform.SetParent(transform);
            
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canMove = false;
            other.transform.SetParent(null);
        }
    }
}
