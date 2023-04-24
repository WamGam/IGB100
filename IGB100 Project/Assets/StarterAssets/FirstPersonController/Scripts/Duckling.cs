using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Duckling : MonoBehaviour
{
    public GameObject ducky;
    public void reset()
    {
        if (ducky.gameObject.tag == "Finder")
        {
            SceneManager.LoadScene("Programming");
        }
        else
        {
            return;
        }
    }
}
