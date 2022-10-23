using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    private CharacterController2D characterController2D;
    public float runSpeed = 0;
    bool jump = false;
    private bool isClimbing = false;
    float horizontalMove = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        characterController2D = this.GetComponent<CharacterController2D>();
    }
    
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("ladder")){
            Debug.Log("Colliding with ladder");
            isClimbing = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("ladder")){
            Debug.Log("Player Exited the Ladder");
            isClimbing = false;
        }
    }
    void LadderMovement(){
        
    }

    void Update(){
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if(Input.GetButtonDown("Jump")){
            jump = true;
        }
    }
    void FixedUpdate()
    {

        if(isClimbing){
            // working on climbing
        }

        characterController2D.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
