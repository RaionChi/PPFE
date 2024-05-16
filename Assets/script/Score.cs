using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public ChronoData chronoData;
    public TMP_Text currentTimeText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimeSpan time = TimeSpan.FromSeconds(chronoData.currentTime);
        currentTimeText.text = time.ToString(@"mm\:ss\:ff");
    }
}
