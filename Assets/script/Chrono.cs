using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class Chrono : MonoBehaviour
{
    bool stopwatchActive = false;
    public TMP_Text currentTimeText;

    public ChronoData chronoData;

    // Start is called before the first frame update
    void Start()
    {
        chronoData.currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            stopwatchActive = true;
        }

        if (stopwatchActive == true)
        {
            chronoData.currentTime = chronoData.currentTime + Time.deltaTime;
         
        }
        TimeSpan time = TimeSpan.FromSeconds(chronoData.currentTime);

        currentTimeText.text = time.ToString(@"mm\:ss\:ff");
        
    }
    public void StartChrono()
    {
        stopwatchActive = true;
    }
    public void StopChrono()
    {
        stopwatchActive = false;
    }
}
