using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{

    public GameObject wall;

    public void Open()
    {
        wall.gameObject.transform.Translate(0, -10, 0);
    }

}
