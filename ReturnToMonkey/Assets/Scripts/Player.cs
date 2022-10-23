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
    bool jump = false;
    private bool isClimbing = false;
    private bool isOnLadder = false;
    float horizontalMove = 0.0f;
    float verticalMove = 0.0f;
    float defaultGravityScale = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        defaultGravityScale = rigidbody2D.gravityScale;
        characterController2D = this.GetComponent<CharacterController2D>();
    }
    
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("ladder")){
            Debug.Log("Colliding with ladder");
            isOnLadder = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("ladder")){
            Debug.Log("Player Exited the Ladder");
            isClimbing = false;
            isOnLadder = false;
        }
    }
    void LadderMovement(){
        
    }

    void Update(){
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        verticalMove = Input.GetAxisRaw("Vertical");

        if(isOnLadder == true && Mathf.Abs(verticalMove) > 0){
            isClimbing = true;
        }

        if(Input.GetButtonDown("Jump")){
            jump = true;
        }

    }
    void FixedUpdate()
    {

        if(isClimbing){
            // working on climbing
            rigidbody2D.gravityScale = 0f;
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, verticalMove * climbingSpeed);
        }else{
            rigidbody2D.gravityScale = defaultGravityScale;
        }

        characterController2D.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
