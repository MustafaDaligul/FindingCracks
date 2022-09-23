using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public GameManager gameManager;
    public CountDown countDown;
    public TextMeshProUGUI textComponent;
    public string[] lines, lines2, lines3;
    public float textSpeed;
    private int index;

    void Start()
    {
        textComponent.text = string.Empty;
    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLines());
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLines());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    IEnumerator TypeLines()
    {
        if (countDown.currentTime >= 20 && gameManager.playerHealt == 0)
        {
            for (int i = 0; i < lines2.Length; i++)
            {
                lines[i] = lines2[i];
            }
            foreach (char c in lines[index].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }
        else if (countDown.currentTime <= 0)
        {
            for (int i = 0; i < lines3.Length; i++)
            {
                lines[i] = lines3[i];
            }
            foreach (char c in lines[index].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }
        else if (gameManager.playerHealt == 0)
        {
            foreach (char c in lines[index].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }
    }

    public void dialogueSkip()
    {
        if (textComponent.text == lines[index])
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            textComponent.text = lines[index];
        }
    }
}
