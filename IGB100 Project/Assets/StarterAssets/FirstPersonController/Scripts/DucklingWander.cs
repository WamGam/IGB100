using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DucklingWander : MonoBehaviour
{
    public float speed;
    public float directionChangeInterval;
    public float maxHeadingChange;

    private float heading;
    private Vector3 targetRotation;

    void Start()
    {
        heading = UnityEngine.Random.Range(0, 360);
        StartCoroutine(ChangeHeading());
    }

    void Update()
    {
        Vector3 dir = Vector3.forward;
        transform.Translate(dir * speed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetRotation), Time.deltaTime);

    }

    IEnumerator ChangeHeading()
    {
        while (true)
        {
            targetRotation = new Vector3(UnityEngine.Random.Range(-maxHeadingChange, maxHeadingChange), 0, 0);
            yield return new WaitForSeconds(directionChangeInterval);
        }
    }
}
