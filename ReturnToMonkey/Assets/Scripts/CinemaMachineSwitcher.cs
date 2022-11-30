using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemaMachineSwitcher : MonoBehaviour
{


    //private InputAction action;

    public bool entrance;
    public bool exit;

    private Animator animator;
    

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        entrance = true;
        exit = false;
    }

    public void SwitchToExitState()
    {
        animator.Play("ExitState");
    }

    void Update()
    {
        
    }
}
