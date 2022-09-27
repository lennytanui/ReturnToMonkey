using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    private CharacterController2D characterController2D;
    public float speed = 0;
    // Start is called before the first frame update
    void Start()
    {
        characterController2D = this.GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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
