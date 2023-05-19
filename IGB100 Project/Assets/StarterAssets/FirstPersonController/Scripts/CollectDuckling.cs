using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollectDuckling : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask pickUpLayerMask;

    public TMP_Text pointsText;
    public int collected = 0;
    public TextMeshProUGUI textComponent;
    public Image textBox;

    private Duckling duckling;
    public StartTimer startTimer;
    public MoveWall moveWall;

    private bool firstFive = true;

    private void Start()
    {
        textBox.enabled = false;
        textComponent.text = string.Empty;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float pickUpDistance = 3f;
            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance))
            {
                if (raycastHit.transform.TryGetComponent(out duckling))
                {
                    if (raycastHit.transform.gameObject.tag == "Finder")
                    {
                        raycastHit.transform.GetComponent<BoxCollider>().enabled = false;
                        collected++;
                        startTimer.timeLeft = startTimer.timeLeft + 30.0f;
                        pointsText.text = collected.ToString();
                        textBox.enabled = true;
                        duckling.StartDialogue();
                    }
                }
            }
        }

        if (collected >= 5 && firstFive)
        {
            moveWall.Open();
            firstFive = false;
        }
        if (collected >= 10)
        {
            SceneManager.LoadScene("Animation");
        }
    }
}
