using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    public Camera mainCamera;
    public Camera gateCam;

    public GameObject wall;

    private float gateRotate;

    public void Open()
    {
        gateRotate = wall.transform.eulerAngles.y;
        //for (int i = 0; i < 5; i++)
        //{
            //mainCamera.gameObject.SetActive(false);
            //gateCam.gameObject.SetActive(true);
            //wall.transform.Rotate(0.0f, -10.0f, 0.0f);
        //}
        //while (gateRotate > 0)
        //{
            //gateRotate = wall.transform.eulerAngles.y;
            //mainCamera.gameObject.SetActive(false);
            //gateCam.gameObject.SetActive(true);
            //wall.transform.Rotate(0.0f, -10.0f, 0.0f);
        //}
        StartCoroutine(waiter() );
        //if (gateRotate < 0.0f)
        //{
            //StopCoroutine(waiter());
            //mainCamera.gameObject.SetActive(true);
            //gateCam.gameObject.SetActive(false);
        //}
        //mainCamera.gameObject.SetActive(true);
        //gateCam.gameObject.SetActive(false);
    }

    IEnumerator waiter()
    {
         for (int i = 0; i < 5; i++)
        {
            gateRotate = wall.transform.eulerAngles.y;
            mainCamera.gameObject.SetActive(false);
            gateCam.gameObject.SetActive(true);
            wall.transform.Rotate(0.0f, -20.0f, 0.0f);
            yield return new WaitForSeconds(1);
        }
        gateCam.gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(true);
        StopCoroutine(waiter());
    }

}
