using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    private CharacterController2D characterController2D;
    private Rigidbody2D rigidbody2D;
    public float runSpeed = 0;
    public float climbingSpeed = 0;
    public float vineClimbingSpeed = 0;
    bool jump = false;
    bool crouch = false;
    private bool isClimbing = false;
    private bool isClimbingVine = false;
    private bool isOnLadder = false;
    private bool isOnVine = false;
    float horizontalMove = 0.0f;
    float verticalMove = 0.0f;
    float defaultGravityScale = 0.0f;
    // Bool for states
    public bool moveRight;
    public Vector3 respawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        defaultGravityScale = rigidbody2D.gravityScale;
        characterController2D = this.GetComponent<CharacterController2D>();
        animator = this.GetComponent<Animator>();
    }
    
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("ladder")){
            isOnLadder = true;
        } else if (collision.CompareTag("vine")){
            isOnVine = true;
        }
        if(collision.tag == "FallDetector")
        {  
            transform.position = respawnPoint;
            GetComponent<health>().TakeDamage(1);
        }
        if(collision.tag == "Checkpoint")
        {
            respawnPoint = collision.transform.position; 
        }
    }

    void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("ladder")){
            isClimbing = false;
            isOnLadder = false;
        } else if (collision.CompareTag("vine")) {
            isClimbingVine = false;
            isOnVine = false;
        }
    }
    void LadderMovement(){
        
    }

    void Update()
    {
        if (!moveRight) NormalMove();
        else FixedMove();
    }


    private void NormalMove()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        verticalMove = Input.GetAxisRaw("Vertical");

        if (isOnLadder == true && Mathf.Abs(verticalMove) > 0)
        {
            isClimbing = true;
            isClimbingVine = false;
        } else if (isOnVine == true && (Mathf.Abs(verticalMove) > 0 || Mathf.Abs(horizontalMove) > 0)){
            isClimbingVine = true;
            isClimbing = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            crouch = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            crouch = false;
        }
    }

    private void FixedMove()
    {
        horizontalMove = runSpeed;
    }


    void FixedUpdate()
    {
        if(horizontalMove != 0){
            animator.SetFloat("Speed",Mathf.Abs(horizontalMove));
        }

        if(isClimbingVine){
            rigidbody2D.gravityScale = 0f;
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, verticalMove * vineClimbingSpeed * Time.fixedDeltaTime);
        }else if(isClimbing){
            // working on climbing
            rigidbody2D.gravityScale = 0f;
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, verticalMove * climbingSpeed * Time.fixedDeltaTime);
        }else{
            rigidbody2D.gravityScale = defaultGravityScale;
            animator.SetFloat("Speed",Mathf.Abs(horizontalMove));
        }
        if(jump){
            characterController2D.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
            animator.SetBool("Jump", true);
        }
        if(crouch){
            characterController2D.Move(horizontalMove * Time.fixedDeltaTime, true, jump);
            animator.SetBool("IsCrouching", true);

        }
        if(Interactable.form == 1)
        {
            animator.SetBool("IsFrog", true);
        }

        jump = false;
        if(Interactable.form == 0)
        {
            animator.SetBool("IsFrog", false);
        }

        characterController2D.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
    }
    public void OnLandEvent()
    {
        animator.SetBool("Jump", false);
    }
    public void OnCrouchEvent(bool IsCrouching)
    {
        animator.SetBool("IsCrouching", false);
    }


}
