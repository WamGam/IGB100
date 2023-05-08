using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelOn : MonoBehaviour
{
    public GameObject[] cubes;
    public GameObject closestTunnel;
    public GameObject goneObject;
    public GameObject otherObject;

    public float LastDistance;
    public int MainTarget;
    public float DistanceToTarget;
    public float DistanceFromTarget;
    float distance;
    float nearestDistance = 10000;

    public bool closeToBoy = true;
    // Start is called before the first frame update

    public class myTunnelSorter : IComparer
    {

        // Calls CaseInsensitiveComparer.Compare on the monster name string.
        int IComparer.Compare(System.Object x, System.Object y)
        {
            return ((new CaseInsensitiveComparer()).Compare(((GameObject)x).name, ((GameObject)y).name));
        }

    }

    void Start()
    {
        IComparer myComparer = new myTunnelSorter();
        cubes = GameObject.FindGameObjectsWithTag("Tunnel");
        Array.Sort(cubes, myComparer);
    }

    // Update is called once per frame
    void Update()
    {
        stopTunnel();
    }

    public void activeTunnel()
    {
       
        for (int i = 0; i < cubes.Length; i++)
        {
            distance = Vector3.Distance(this.transform.position, cubes[i].transform.position);
            if (distance < nearestDistance) 
            {
                closestTunnel = cubes[i];
                nearestDistance = distance;
            }
        }
    }

    public void stopTunnel()
    {
        DistanceFromTarget = Vector3.Distance(closestTunnel.transform.position, transform.position);

        if (nearestDistance < 2.0f)
        {
            for (int i = 0;i < cubes.Length; i++)
            {
                if (closestTunnel == cubes[i])
                {
                    if (closestTunnel.name.Contains("link"))
                    {
                        otherObject = cubes[i - 1];
                    }
                    else
                    {
                        otherObject = cubes[i + 1];
                    }
                }
            }

            goneObject = closestTunnel;
            closestTunnel.gameObject.SetActive(false);
            otherObject.gameObject.SetActive(false);
            nearestDistance = 10000;
            activeTunnel();
        }
        else
        {
            goneObject.gameObject.SetActive(true);
            otherObject.gameObject.SetActive(true);
            activeTunnel();
        }
    }
}
