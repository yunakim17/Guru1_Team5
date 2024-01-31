using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailPanel : MonoBehaviour
{
    public static FailPanel Instance;

    private void Awake()
    {
        if (FailPanel.Instance == null)
        {
            FailPanel.Instance = this;
        }
    }


    public GameObject NextBtn;


    void Start()
    {
        gameObject.SetActive(false);

        NextBtn.SetActive(false);
    }

    public void FailPanelAppear()
    {
        gameObject.SetActive(true);

        NextBtn.SetActive(true);
    }

    
}
