using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using TMPro;

public class canBePicked : MonoBehaviour
{

    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] private LayerMask pickUpLayerMask;

    private ObjectGrabbable objectGrabbable;
    public TMP_Text pickupInfo;
    private float pickUpDistance = 5f;

    private void Update()
    {
        StartCoroutine(ispickUp());
    }

    IEnumerator ispickUp()
    {
        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit2, pickUpDistance))
        {
            if (raycastHit2.transform.TryGetComponent(out objectGrabbable))
            {
                pickupInfo.gameObject.SetActive(true);
            }
            else
            {
                pickupInfo.gameObject.SetActive(false);
            }
        }
        yield return null;
    }

}