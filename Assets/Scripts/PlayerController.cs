using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Public Variables

    public enum Elements
    {
        Fire,
        Wind,
        Ice,
        Water,
        Earth
    }


    #endregion

    #region Privite Variables
    private Rigidbody2D playerRb;
    private bool isGrounded;
    #endregion

    #region Inspector Fields
    [SerializeField] private float jumpForce;
    [SerializeField] private float speed;
    [SerializeField] private Elements currentElement;
    #endregion



    private void Awake()
    {
        playerRb = transform.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        PlayerInput();
    }


    private void PlayerInput()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }

        if (!isGrounded)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            playerRb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        isGrounded = true;
    }
}
