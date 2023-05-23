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
    private AudioSource[] audioDuck = new AudioSource[10];
    private AudioSource audioDuck2;
    System.Random rnd = new System.Random();
    public int[] realDucks = new int[5];
    private int[] intArray = new int[14];
    float lastTime;
    
    // Start is called before the first frame update
    void Start()
    {
        lastTime = Time.time;
        preObjs = GameObject.FindGameObjectsWithTag("PreFind");
        for (int i = 0; i < 14; i++)
        {
            intArray[i] = i;
        }
        Shuffle(intArray);
       
        for (int i = 0; i < preObjs.Length; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (i == intArray[j])
                {
                    preObjs[i].gameObject.tag = "Finder";
                }
            }
        }
        objs = GameObject.FindGameObjectsWithTag("Finder");
         for (int i = 0; i < 10; i++)
        {
            audioDuck[i] = objs[i].GetComponent<AudioSource>();
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
            for (int i = 0; i < objs.Length; i++)
            {
                if (Vector3.Distance(player.transform.position, objs[i].transform.position) < 80 && Time.time - lastTime > 1.0f)
                {
                    if (objs[i].activeSelf == true)
                    {
                        audioDuck[i].Play();
                        objs[i].transform.Translate(Vector3.up * 10.0f * Time.deltaTime);
                        lastTime = Time.time;
                    }
                }
            }
        }
    }

    static bool Contains(int[] array, int value)
    {
        for (int i = 0; i <= array.Length; i++)
        {
            if (array[i] == value)
            {
                return true;
            }
        }
        return false;
    }

    public void Shuffle(int[] obj)
    {
        for (int i = 0; i < obj.Length; i++)
        {
            int temp = obj[i];
            int objIndex = UnityEngine.Random.Range(0, obj.Length);
            obj[i] = obj[objIndex];
            obj[objIndex] = temp;
        }
    }
}
