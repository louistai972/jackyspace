﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public Text timerText;
    private float startTime;
    private bool finnished = false;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if (finnished)
            return;
        float t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString ();
        string seconds = (t % 60).ToString ("00");
        timerText.text = minutes+" : "+seconds;
    }

    public void Finnish()
    {
        finnished = true;
        timerText.color = Color.green;
    }
}