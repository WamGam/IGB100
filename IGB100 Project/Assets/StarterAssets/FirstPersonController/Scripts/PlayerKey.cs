using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerKey : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask pickUpLayerMask;

    private MoveWall moveWall;
    private StartTimer startTimer;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float pickUpDistance = 3f;
            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance))
            {
                if (raycastHit.transform.TryGetComponent(out moveWall))
                {
                    moveWall.Open();
                }
                else if (raycastHit.transform.TryGetComponent(out startTimer))
                {
                    startTimer.Begin();
                }
            }
        }
    }
}
