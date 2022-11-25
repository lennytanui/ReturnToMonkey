using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_sideways : MonoBehaviour
{
    [SerializeField] private float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<health>().TakeDamage(damage);
            {
                Debug.Log("Player is being hit");
            }
        }
            
        
    }

    
}
