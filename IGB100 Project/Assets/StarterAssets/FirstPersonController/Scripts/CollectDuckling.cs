using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CollectDuckling : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask pickUpLayerMask;

    private Duckling duckling;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float pickUpDistance = 3f;
            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance))
            {
                if (raycastHit.transform.TryGetComponent(out duckling))
                {
                    duckling.reset();
                }
            }
        }
    }
}
