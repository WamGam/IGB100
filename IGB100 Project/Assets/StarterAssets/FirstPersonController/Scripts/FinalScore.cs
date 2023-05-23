using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FinalScore : MonoBehaviour
{
    public TMP_Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + StartTimer.timeLeft.ToString("f0");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
