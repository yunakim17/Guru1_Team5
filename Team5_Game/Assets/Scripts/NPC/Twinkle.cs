using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class twinkle : MonoBehaviour
{
    private string text;
    public TMP_Text targetText1;
    public TMP_Text targetText2;
    private float delay = 0.125f;

    void Start()
    {
        text = targetText1.text.ToString();
        targetText1.text = " ";

        text = targetText2.text.ToString();
        targetText2.text = " ";

        StartCoroutine(textPrint(delay));
    }

    IEnumerator textPrint(float d)
    {
        int count = 0;

        while (count != text.Length)
        {
            if (count < text.Length)
            {
                targetText1.text += text[count].ToString();
                targetText2.text += text[count].ToString();
                count++;
            }

            yield return new WaitForSeconds(delay);
        }
    }
}