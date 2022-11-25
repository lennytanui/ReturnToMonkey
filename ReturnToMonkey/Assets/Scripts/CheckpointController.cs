using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool checkointReached;

    void OnTrigerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            checkointReached = true;
        }
    }

}
