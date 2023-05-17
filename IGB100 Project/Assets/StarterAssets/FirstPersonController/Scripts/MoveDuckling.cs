using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDuckling : MonoBehaviour
{

    public GameObject ducky;

    private Vector3[] locations = new Vector3[] { new Vector3(222f, 24f, 197f), new Vector3(71f, 24f, 197f), new Vector3(104f, 23.3f, 182f), new Vector3(159f, 24.8f, 261f), new Vector3(187f, 23.5f, 63f) };

    private int place;

    // Start is called before the first frame update
    void Start()
    {
        int place = UnityEngine.Random.Range(0, 4);
        for (int i = 0; i < locations.Length; i++)
        {
            if (place == i)
            {
                ducky.transform.position = locations[i];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
