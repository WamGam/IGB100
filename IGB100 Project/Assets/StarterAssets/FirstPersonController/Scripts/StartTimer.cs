using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StartTimer : MonoBehaviour
{
    public GameObject button;

    public static float timeLeft = 400.0f;
    public bool timerOn = true;

    public void Begin()
    {
        button.gameObject.GetComponent<Renderer>().enabled = false;
        timerOn = true;
    }

    void Start()
    {
        timerOn = true;
    }

    void Awake()
    {
        timerOn = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (timerOn)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                timeLeft = 0;
                timerOn = false;
            }
        }
    }
}
