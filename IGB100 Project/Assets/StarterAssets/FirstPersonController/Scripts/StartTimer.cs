using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartTimer : MonoBehaviour
{
    public GameObject button;

    public float timeLeft;
    public bool timerOn = false;

    public TMP_Text timerTxt;

    public void Begin()
    {
        button.gameObject.GetComponent<Renderer>().enabled = false;
        timerOn = true;
    }

    void Start()
    {
        timerTxt.text = timeLeft.ToString();
        timerOn = true;
    }

    void Awake()
    {
        timerOn = true;
    }


    // Update is called once per frame
    void Update()
    {
        if(timerOn)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                timeLeft = 0;
                timerOn = false;
            }
            timerTxt.text = timeLeft.ToString("f1");
        }
    }
}
