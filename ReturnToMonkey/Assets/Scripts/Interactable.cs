using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    static public bool InRange;
    static public int form;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    // Start is called before the first frame update
    void Start()
    {
        form = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(InRange)
        {
            if(Input.GetKey(KeyCode.M))
            {
                form += 1;
                if(form == 2)
                {
                    form = 0;
                }
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"));
        InRange = true;
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"));
        InRange = false;
        
    }
}
