using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Duckling : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public Image textBox;

    private int index;

    public GameObject ducky;

    public void reset()
    {
        if (ducky.gameObject.tag == "Finder")
        {
            SceneManager.LoadScene("Programming");
        }
        else
        {
            return;
        }
    }

    public void StartDialogue()
    {
        index = lines.Length;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        for (int i = 0; i < index; i++)
        {
            foreach (char c in lines[i].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }
        yield return new WaitForSeconds(2);
        StopAllCoroutines();
        textComponent.text = string.Empty;
        textBox.enabled = false;
        ducky.SetActive(false);
    }
}
