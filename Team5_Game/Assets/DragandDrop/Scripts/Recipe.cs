using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Recipe : MonoBehaviour, IPointerClickHandler
{
    public static Recipe Instance;

    private void Awake()
    {
        if (Recipe.Instance == null)
        {
            Recipe.Instance = this;
        }
    }

     List<string> Recipe1Names = new List<string>() { "feather", "flower", "redMushroom" };
     List<string> Recipe2Names = new List<string>() { "dragonScales", "flower2", "blueMushroom" };
     List<string> Recipe3Names = new List<string>() { "lizardTail", "plantRoot", "greenMushroom" };


    bool FirstRecipeOn = false;
    bool SecondRecipeOn = false;
    bool ThirdRecipeOn = false;


    public GameObject objectToDrag;
    public GameObject magicPotPos;

    public float Dropdistance;

    public void DragObject()
    {
        objectToDrag.transform.position = Input.mousePosition;//�巡�� ���

    }

    public void DropObject()
    {
        float distance = Vector3.Distance(objectToDrag.transform.position, magicPotPos.transform.position);

        Debug.Log("����� ������Ʈ : " + gameObject.name); //Ȯ�ο�

        //if (FirstRecipeOn && Recipe1Names.Contains(gameObject.name))
        //{
        //    objectToDrag.transform.position = magicPotPos.transform.position;
        //    Debug.Log("1�� ������ ��� ����");
        //}
        //else if (SecondRecipeOn && Recipe2Names.Contains(gameObject.name))
        //{
        //    objectToDrag.transform.position = magicPotPos.transform.position;
        //    Debug.Log("2�� ������ ��� ����");
        //}
        //else if (ThirdRecipeOn && Recipe3Names.Contains(gameObject.name))
        //{
        //    objectToDrag.transform.position = magicPotPos.transform.position;
        //    Debug.Log("3�� ������ ��� ����");
        //}
        //else
        //{
        //    Debug.Log("�� ��� �ƴ�!!");
        //}



        //if (distance < Dropdistance)
        //{
        //    if (FirstRecipeOn && Recipe1Names.Contains(gameObject.name))
        //    {
        //        objectToDrag.transform.position = magicPotPos.transform.position;
        //        Debug.Log("1�� ������ ��� ����");
        //    }
        //    else if (SecondRecipeOn && Recipe2Names.Contains(gameObject.name))
        //    {
        //        objectToDrag.transform.position = magicPotPos.transform.position;
        //        Debug.Log("2�� ������ ��� ����");
        //    }
        //    else if (ThirdRecipeOn && Recipe3Names.Contains(gameObject.name))
        //    {
        //        objectToDrag.transform.position = magicPotPos.transform.position;
        //        Debug.Log("3�� ������ ��� ����");
        //    }
        //    else
        //    {
        //        Debug.Log("�� ��� �ƴ�!!");
        //    }
        //}
        //else
        //{
        //    Debug.Log("Object dropped too far away!");
        //}




        if (distance < Dropdistance)
        {
            if (FirstRecipeOn)
            {
                CheckAndHandleRecipe(Recipe1Names, "1��");
            }
            else if (SecondRecipeOn)
            {
                CheckAndHandleRecipe(Recipe2Names, "2��");
            }
            else if (ThirdRecipeOn)
            {
                CheckAndHandleRecipe(Recipe3Names, "3��");
            }
        }
        else
        {
            Debug.Log("Object dropped too far away!");
        }

    }

        void CheckAndHandleRecipe(List<string> recipeNames, string recipeNumber)
        {
            if (recipeNames.Contains(gameObject.name))
            {
                objectToDrag.transform.position = magicPotPos.transform.position;
                Debug.Log($"{recipeNumber} ������ ��� ����");
            }
            else
            {
                Debug.Log($"�� ��� �ƴ�!!");
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


        public void OnPointerClick(PointerEventData eventData)
        {
            // Output the name of the clicked object
            Debug.Log("Clicked object: " + gameObject.name); //Ȯ�ο�

        }
    }

