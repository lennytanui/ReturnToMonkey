using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth{get; private set;}
    private Animator anim;
    private bool dead;
    private void Awake()
    {
        dead = false;
        currentHealth = startingHealth;
        anim = this.GetComponent<Animator>();
    }
    
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage,0,startingHealth);
        
        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            //iframes
        }
        else
        {
            if(!dead)
            {
                anim.SetTrigger("die");
                GetComponent<Player>().enabled = false;
                dead = true;
            }
            
        }

    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }
    }

    

   
}
