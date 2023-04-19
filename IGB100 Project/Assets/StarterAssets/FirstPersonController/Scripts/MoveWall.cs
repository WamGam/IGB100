using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{

    public GameObject wall;
    public GameObject key;

    public void Open()
    {
        wall.gameObject.transform.Translate(0, -10, 0);
        key.gameObject.SetActive(false);
    }

}
