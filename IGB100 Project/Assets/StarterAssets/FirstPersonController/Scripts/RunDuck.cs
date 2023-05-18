using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System;
using UnityEngine;

public class RunDuck : MonoBehaviour
{
    public GameObject target;
    public GameObject[] tunnels;
    public GameObject[] tunnels2;
    public GameObject thisTunnel;
    public TunnelOn tunnelOn;

    public float DistanceFromLastTarget;
    public int MainTarget;

    public bool[] activeArray = { true, true, true, true, true, true, true, true, true, true };


    float moveSpeed = 1.0f;
    private float timeLeft = 2.0f;

    public class myTunnelSorter : IComparer
    {

        // Calls CaseInsensitiveComparer.Compare on the monster name string.
        int IComparer.Compare(System.Object x, System.Object y)
        {
            return ((new CaseInsensitiveComparer()).Compare(((GameObject)x).name, ((GameObject)y).name));
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        IComparer myComparer = new myTunnelSorter();
        tunnels = GameObject.FindGameObjectsWithTag("Tunnel");
        Array.Sort(tunnels, myComparer);
        
    }

    // Update is called once per frame
    void Update()
    {
        findTunnel();
        for (int i = 0; i < tunnels.Length; i++)
        {
            if (tunnels[i].gameObject.active)
            {
                run();
            }
        }

        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            for (int i = 0; i < activeArray.Length; i++)
            {
                activeArray[i] = true;
            }
            timeLeft = 2;
        }

    }

    public void run()
    {
        Vector3 dir = Vector3.forward;
        dir.y = 0.0f;
        //if (this.gameObject.transform.position.z < -56.0f)
        //{
            //dir.z = -18.0f;
        //}
        //if (this.gameObject.transform.position.z > -17.0f)
        //{
            //dir.z = -56.0f;
        //}
        //if (this.gameObject.transform.position.x > -37.0f)
        //{
            //dir.x = -47.0f;
        //}
        //if (this.gameObject.transform.position.x < -47.0f)
       //{
            //dir.z = -37.0f;
        //}
        transform.Translate(dir * moveSpeed * Time.deltaTime);
    }

    public void lookAt(GameObject target)
    {
        var rotation = Quaternion.LookRotation(target.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 3);
    }

    public void findTunnel()
    {
        for (int i=0; i<tunnels.Length; i++)
        {
            if (tunnels[i] != null)
            {
                float DistanceFromTarget = Vector3.Distance(tunnels[i].transform.position, transform.position);
                if (i > 0)
                {
                    DistanceFromLastTarget = Vector3.Distance(tunnels[i - 1].transform.position, transform.position);
                }
                else
                {
                    DistanceFromLastTarget = 0.0f;
                }
                if (DistanceFromTarget > DistanceFromLastTarget)
                {
                    if (activeArray[i] == true)
                    {
                        MainTarget = i;
                    }
                }
            }
        }
        lookAt(tunnels[MainTarget]);
    }

    void OnTriggerEnter(UnityEngine.Collider col)
    {
        if (col.gameObject.name == tunnels[0].gameObject.name && activeArray[0] == true)
        {
            UnityEngine.Debug.Log("yay");
            activeArray[0] = false; activeArray[1] = false;
            thisTunnel = tunnels[1];
            transform.position = thisTunnel.transform.position;
        }
        if (col.gameObject.name == tunnels[1].gameObject.name && activeArray[1] == true)
        {
            UnityEngine.Debug.Log("yay");
            activeArray[0] = false; activeArray[1] = false;
            thisTunnel = tunnels[0];
            transform.position = thisTunnel.transform.position;
        }
        if (col.gameObject.name == tunnels[2].gameObject.name && activeArray[2] == true)
        {
            UnityEngine.Debug.Log("yay");
            activeArray[2] = false; activeArray[3] = false;
            thisTunnel = tunnels[3];
            transform.position = thisTunnel.transform.position;
        }
        if (col.gameObject.name == tunnels[3].gameObject.name && activeArray[3] == true)
        {
            UnityEngine.Debug.Log("yay");
            activeArray[2] = false; activeArray[3] = false;
            thisTunnel = tunnels[2];
            transform.position = thisTunnel.transform.position;
        }
        if (col.gameObject.name == tunnels[4].gameObject.name && activeArray[4] == true)
        {
            UnityEngine.Debug.Log("yay");
            activeArray[4] = false; activeArray[5] = false;
            thisTunnel = tunnels[5];
            transform.position = thisTunnel.transform.position;
        }
        if (col.gameObject.name == tunnels[5].gameObject.name && activeArray[5] == true)
        {
            UnityEngine.Debug.Log("yay");
            activeArray[4] = false; activeArray[5] = false;
            thisTunnel = tunnels[4];
            transform.position = thisTunnel.transform.position;
        }
        if (col.gameObject.name == tunnels[6].gameObject.name && activeArray[6] == true)
        {
            UnityEngine.Debug.Log("yay");
            activeArray[6] = false; activeArray[7] = false;
            thisTunnel = tunnels[7];
            transform.position = thisTunnel.transform.position;
        }
        if (col.gameObject.name == tunnels[7].gameObject.name && activeArray[7] == true)
        {
            UnityEngine.Debug.Log("yay");
            activeArray[6] = false; activeArray[7] = false;
            thisTunnel = tunnels[6];
            transform.position = thisTunnel.transform.position;
        }
        if (col.gameObject.name == tunnels[8].gameObject.name && activeArray[8] == true)
        {
            UnityEngine.Debug.Log("yay");
            activeArray[8] = false; activeArray[9] = false;
            thisTunnel = tunnels[9];
            transform.position = thisTunnel.transform.position;
        }
        if (col.gameObject.name == tunnels[9].gameObject.name && activeArray[9] == true)
        {
            UnityEngine.Debug.Log("yay");
            activeArray[8] = false; activeArray[9] = false;
            thisTunnel = tunnels[8];
            transform.position = thisTunnel.transform.position;
        }
    }
}
