using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class MagicPotDrop : MonoBehaviour, IDropHandler
{

    public static MagicPotDrop Instance; //�ٸ� ��ũ��Ʈ���� �� ��ũ��Ʈ�� �Լ��� ȣ���� �� �ʿ�

    public bool FirstRecipeOn = false;
    public bool SecondRecipeOn = false;
    public bool ThirdRecipeOn = false;

    private void Awake() 
    {
        if(MagicPotDrop.Instance == null)//�ٸ� ��ũ��Ʈ���� �� ��ũ��Ʈ�� �Լ��� ȣ���� �� �ʿ�

        {
            MagicPotDrop.Instance = this;
        }
    }




    public void OnDrop(PointerEventData eventData)
    {
       // Debug.Log("OnDrop");

        if (eventData.pointerDrag != null && FirstRecipeOn == true)
        {

            Debug.Log("firstDropped");

        }
        else if (eventData.pointerDrag != null && FirstRecipeOn == true)
        {

            Debug.Log("secondDropped");
        }

        else if (eventData.pointerDrag != null && FirstRecipeOn == true)
        {

            Debug.Log("thirdDropped");

        }


    }


    public void FirstRecipe()
    {
        FirstRecipeOn = true;
        Debug.Log("first");
    }

    public void SecondRecipe()
    {
        SecondRecipeOn = true;
        Debug.Log("second");
    }

    public void ThirdRecipe()
    {
        ThirdRecipeOn = true;
        Debug.Log("third");
    }

   
}

