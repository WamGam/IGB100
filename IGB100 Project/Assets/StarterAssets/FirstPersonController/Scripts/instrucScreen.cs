using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class instrucScreen : MonoBehaviour
{

    public string MainMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(MainMenu);
    }
}
