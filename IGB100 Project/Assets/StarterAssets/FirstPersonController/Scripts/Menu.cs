using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public string Animation;
    public string introduce;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene(Animation);
    }

    public void QuitGame()
    {
        Application.Quit();

    }
    public void Instruc()
    {
        SceneManager.LoadScene(introduce);
    }
}
