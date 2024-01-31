using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class RolledPaper : MonoBehaviour
{
    public Text clickIt;

    public GameObject graduationCertificate;

    private string Name;

    public Text NameText;

    public void click()
    {
        gameObject.SetActive(false);

        graduationCertificate.SetActive(true);

        NameText.text = Name;
    }

    void Start()
    {
        clickIt.text = "Click it!";
        graduationCertificate.SetActive(false);

        Name = NameTransfer.theName;


    }

   
}
