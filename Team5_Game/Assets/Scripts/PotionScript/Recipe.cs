using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Recipe : MonoBehaviour 
{
    //public static Recipe Instance;

    //private void Awake()
    //{
    //    if (Recipe.Instance == null)
    //    {
    //        Recipe.Instance = this;
    //    }
    //}

     List<string> Recipe1Names = new List<string>() { "phoenixFeather", "flower", "redMushroom", "lizardTail", "plantRoot" };
     List<string> Recipe2Names = new List<string>() { "dragonScales", "flower2", "blueMushroom", "plantRoot", "phoenixFeather" };
     List<string> Recipe3Names = new List<string>() { "lizardTail", "plantRoot", "greenMushroom", "phoenixFeather", "flower" };


     static List<string> Recipe1Added = new List<string>();
     static List<string> Recipe2Added = new List<string>();
     static List<string> Recipe3Added = new List<string>(); //�巡���ؼ� ���

    static bool FirstRecipeOn = false;
    static bool SecondRecipeOn = false;
    static bool ThirdRecipeOn = false;

    public Vector2 OriginPos;//����Ƽ���� ������ġ xy�� �����ؼ� �ٿ��ֱ��ؾ���
    

    public GameObject objectToDrag;
    public GameObject magicPotPos;

    public float Dropdistance;

    public void DragObject()
    {
        objectToDrag.transform.position = Input.mousePosition;//�巡�� ���

    }

    public void DropObject()//������Ʈ�� ����ϸ� ȣ��Ǵ� �Լ�
    {
        float distance = Vector3.Distance(objectToDrag.transform.position, magicPotPos.transform.position);//�������

        //Debug.Log("����� ������Ʈ : " + gameObject.name); //Ȯ�ο�

       

        if (distance < Dropdistance) 
        {
            if (FirstRecipeOn)//ù��° �����ǰ� ������ ��
            {
                CheckAndHandleRecipe(Recipe1Names, Recipe1Added, 1);
               
            }
            else if (SecondRecipeOn)
            {
                CheckAndHandleRecipe(Recipe2Names,Recipe2Added, 2);
                
            }
            else if (ThirdRecipeOn)
            {
                CheckAndHandleRecipe(Recipe3Names, Recipe3Added, 3);
                
            }
        }
        else
        {
            Debug.Log("�ʹ� �ָ� ����߾�!!");
            objectToDrag.transform.position = OriginPos; //�������� ���� �ִ� �ڸ��� ���ư�
        }

    }

        void CheckAndHandleRecipe(List<string> recipeNames, List<string> recipeAdded, int recipeNumber)
        {
            if (recipeNames.Contains(gameObject.name))
            {
                objectToDrag.transform.position = magicPotPos.transform.position;
                objectToDrag.SetActive(false);

                Debug.Log(recipeNumber+"�� ������ ��� ����!!");

                recipeAdded.Add(objectToDrag.name);

                

                if(Enumerable.SequenceEqual(recipeNames, recipeAdded))//������� �߸��������
                {
                Debug.Log(recipeNumber+ "�� ���� �Ϻ� ����!!");

                //�ϼ��� ���� ui ȣ��

                }
                else if(Enumerable.SequenceEqual(recipeNames, recipeAdded) == false && AreListsEqual(recipeNames, recipeAdded) == true)//������ Ʋ������ ��Ḧ �˸°� �־�����
                {
                Debug.Log("������ Ʋ������ " + recipeNumber +"�� ���� ���� ����!");

                //�ϼ��� ���� ui ȣ��
                }



            }   
            else //�����ǿ� ���� ��Ḧ �־��� ��
            {
                Debug.Log("�� ��� �ƴ�!!");
                objectToDrag.SetActive(false);
            //���ϸ鼭 ���� �߸��ƴٴ� ȿ��.. ���� ���� ���� �̴ϰ������� �Ѿ
        }
        }



   
    

     public bool AreListsEqual(List<string> list1, List<string> list2)
    {
    // �� ����Ʈ�� ��Ҹ� �����Ͽ� ������ �����ϰ� ��
    return list1.OrderBy(item => item).SequenceEqual(list2.OrderBy(item => item));
    }





    public static void FirstRecipe(bool tf)
        {
            FirstRecipeOn = tf;
            Debug.Log("first");
        }

        public static void SecondRecipe(bool tf)
        {
            SecondRecipeOn = tf;
            Debug.Log("second");
        }

        public static void ThirdRecipe(bool tf)
        {
            ThirdRecipeOn = tf;
            Debug.Log("third");
        }


      
    }

