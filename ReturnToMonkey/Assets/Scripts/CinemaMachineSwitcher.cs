using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemaMachineSwitcher : MonoBehaviour
{

    private Animator animator;
    

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {

    }

    internal void SwitchToEntranceState()
    {
        animator.Play("EntranceState");
    }
    internal void SwitchToCamState()
    {
        animator.Play("CamState");
    }

    public void SwitchToExitState()
    {
        animator.Play("ExitState");
    }

    void Update()
    {
        
    }
}
