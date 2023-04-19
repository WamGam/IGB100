using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class FindObject : MonoBehaviour
{
    public GameObject player;
    public GameObject[] objs;
    public GameObject[] preObjs;
    private AudioSource audioDuck;
    private AudioSource audioDuck2;
    System.Random rnd = new System.Random();
    
    // Start is called before the first frame update
    void Start()
    {
        preObjs = GameObject.FindGameObjectsWithTag("PreFind");
        int selection = rnd.Next(0, preObjs.Length - 1);
        for (int i = 0; i < preObjs.Length; i++)
        {
            if (i == selection)
            {
                preObjs[i].gameObject.tag = "Finder";
                break;
            }
        }
        objs = GameObject.FindGameObjectsWithTag("Finder");
         for (int i = 0; i< objs.Length; i++)
        {
            if (i == 0)
            {
                audioDuck = objs[i].GetComponent<AudioSource>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        findDuck();
    }

    public void findDuck()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (Vector3.Distance(player.transform.position, objs[0].transform.position) < 50)
            {
                UnityEngine.Debug.Log(objs[0].transform.position);
                audioDuck.Play();
            }
        }
    }
}
