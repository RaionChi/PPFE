using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetection : MonoBehaviour
{
    public ChronoData chronoData;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            chronoData.currentTime = chronoData.currentTime + 5.5f;
            
        }

    }
}
