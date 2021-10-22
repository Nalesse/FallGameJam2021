using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class PlayerController : MonoBehaviour
{
    #region Public Variables

    public enum Elements
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
    public Elements CurrentElement { get; set; }

    public int JumpCount { get; set; }

    #endregion

    #region Privite Variables
    private Rigidbody2D playerRb;
    private bool canJump;

    private int allowedJumps;
    #endregion

    #region Inspector Fields
    [SerializeField] private float jumpForce;
    [SerializeField] private float speed;
    #endregion



    private void Awake()
    {
        playerRb = transform.GetComponent<Rigidbody2D>();
        JumpCount = 1;
        allowedJumps = JumpCount;

    }

    // Update is called once per frame
    private void Update()
    {
        PlayerInput();
        JumpCount = CurrentElement == Elements.Wind ? 2 : 1;
        
    }

    private void FixedUpdate()
    {
        // Jump action is separated so that it gets handled by FixedUpdate and not Update which is more performant
        Jump();
    }

    #region Player Movement

    private void PlayerInput()
    {
        // Moves the player left or right based off of the horizontal input
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * Time.deltaTime * speed * horizontalInput);


        // Activates the jump function if the player presses "space" or "W".  
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            
            if (allowedJumps > 0)
            {
                canJump = true;
                allowedJumps -= 1;
            }
            else
            {
                canJump = false;
            }

            if (allowedJumps < 0)
            {
                allowedJumps = 0;
            }

        }

    }

    private void Jump()
    {
        // if canJump is false then the rest of the code does not get executed 
        if (!canJump)
        {
            return;
        }

        playerRb.AddForce(this.transform.up * this.jumpForce, ForceMode2D.Impulse);
        canJump = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        allowedJumps = JumpCount;
    }
    


    #endregion
}
