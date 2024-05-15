using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionFinNiveau : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        { 
            Destroy(collision.gameObject);
        }
            
    }
}
