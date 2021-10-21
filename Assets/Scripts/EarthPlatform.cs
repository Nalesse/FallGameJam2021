using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthPlatform : MonoBehaviour
{
    [SerializeField] private Vector2 endPosition;
    [SerializeField] private Vector2 startPosition;
    [SerializeField] private float moveSpeed;

    [SerializeField] private bool moveUp;

    private bool canMove;

    // Update is called once per frame
    private void Update()
    {
        this.MovePlatform();
    }

    private void MovePlatform()
    {

        if (!this.canMove)
        {
            return;
        }

        // Using Math.Abs to avoid floating point comparison issues
        if (Math.Abs(this.transform.position.y - this.startPosition.y) < .01)
        {
            this.moveUp = true;
        }
        else if (Math.Abs(this.transform.position.y - this.endPosition.y) < .01)
        {
            this.moveUp = false;
        }

        if (moveUp)
        {
            transform.position = Vector2.MoveTowards(transform.position, endPosition, this.moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, startPosition, this.moveSpeed * Time.deltaTime);
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
            canMove = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canMove = false;
        }
    }
}
