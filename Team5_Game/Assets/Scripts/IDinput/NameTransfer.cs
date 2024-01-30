using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameTransfer : MonoBehaviour
{
    public static string theName = "swu";

    public GameObject inputField;

    public GameObject textDisplay;

    public GameObject startBtn;


    public void StoreName()
    {
        theName = inputField.GetComponent<Text>().text;
        textDisplay.GetComponent<Text>().text = "Welcome " + theName + " to the Game!";

        GameObject.Find("InputField").SetActive(false);
        GameObject.Find("submitBtn").SetActive(false);

        startBtn.SetActive(true);

       
    }
}
