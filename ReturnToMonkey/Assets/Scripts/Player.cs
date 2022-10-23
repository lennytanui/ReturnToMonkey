using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    private CharacterController2D characterController2D;
    public float speed = 0;
    private bool isClimbing = false;
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
    // Update is called once per frame
    void FixedUpdate()
    {

        if(isClimbing){
            // working on climbing
        }

        if(Input.GetKey(KeyCode.D)){
            characterController2D.Move(speed * Time.deltaTime, false, false);
        }

        if(Input.GetKey(KeyCode.A)){
            characterController2D.Move(-1 * speed * Time.deltaTime, false, false);
        }

        if(Input.GetKey(KeyCode.Space)){
            characterController2D.Move(0, false, true);
        }
    }
}
