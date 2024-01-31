using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearPanel : MonoBehaviour
{
    public static ClearPanel Instance;

    private void Awake()
    {
        if (ClearPanel.Instance == null)
        {
            ClearPanel.Instance = this;
        }
    }


    public GameObject RedPotion;
    public GameObject BluePotion;
    public GameObject GreenPotion;

    public GameObject NextBtn;


    void Start()
    {
        gameObject.SetActive(false);

        RedPotion.SetActive(false);
        BluePotion.SetActive(false);
        GreenPotion.SetActive(false);

        NextBtn.SetActive(false);
    }

    public void RedPotionAppear()
    {
        RedPotion.SetActive(true);
    }

    public void BluePotionAppear()
    {
        BluePotion.SetActive(true);
    }

    public void GreenPotionAppear()
    {
        GreenPotion.SetActive(true);
    }

    public void ClearPanelAppear()
    {
        gameObject.SetActive(true);

        NextBtn.SetActive(true);

    }
}
