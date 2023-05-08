using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using TMPro;

public class CollectDuckling : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask pickUpLayerMask;

    public TMP_Text pointsText;
    public int collected = 0;

    private Duckling duckling;
    public StartTimer startTimer;
    public MoveWall moveWall;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float pickUpDistance = 3f;
            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance))
            {
                if (raycastHit.transform.TryGetComponent(out duckling))
                {
                    collected++;
                    startTimer.timeLeft = startTimer.timeLeft + 60.0f;
                    pointsText.text = collected.ToString();
                    raycastHit.collider.gameObject.GetComponent<MeshRenderer>().enabled = false;
                }
            }
        }

        if (collected >= 3)
        {
            moveWall.Open();
        }
    }
}
