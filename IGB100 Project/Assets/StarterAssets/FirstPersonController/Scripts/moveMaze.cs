using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveMaze : MonoBehaviour
{
    public GameObject deleteWall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if  (this.gameObject.transform.GetComponent<BoxCollider>().enabled == false)
        {
            deleteWall.SetActive(false);
        }
    }
}
