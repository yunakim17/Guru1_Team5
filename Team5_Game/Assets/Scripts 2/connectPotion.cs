using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class connectPotion : MonoBehaviour
{
    //public static connectPotion Instance;//�ٸ� ��ũ��Ʈ���� �� ��ũ��Ʈ�� �Լ��� ȣ���� �� �ʿ�
    //private void Awake()
    //{
    //    if (connectPotion.Instance == null)//�ٸ� ��ũ��Ʈ���� �� ��ũ��Ʈ�� �Լ��� ȣ���� �� �ʿ�

    //    {
    //        connectPotion.Instance = this;
    //    }
    //}

    public GameObject redpotion;
    public GameObject bluepotion;
    public GameObject greenpotion;

    private static bool redPotionTrue = false;
    private static bool bluePotionTrue = false;
    private static bool greenPotionTrue = false;
    public static void RedPotionOn()
    {
        redPotionTrue = true;
    }

    public static void BluePotionOn()
    {
        bluePotionTrue = true;
    }

    public static void GreenPotionOn()
    {
        greenPotionTrue = true;
    }


    void Start()
    {
        if (redPotionTrue)
        {
            greenpotion.SetActive(false);
            bluepotion.SetActive(false);
        }
        else if (bluePotionTrue)
        {
            greenpotion.SetActive(false);
            redpotion.SetActive(false);
        }
        else if (greenPotionTrue)
        {
            redpotion.SetActive(false);
            bluepotion.SetActive(false);
        }
        else
        {
            redpotion.SetActive(false);
            bluepotion.SetActive(false);
            greenpotion.SetActive(false);
        }
    }

   
    void Update()
    {
        
    }
}
