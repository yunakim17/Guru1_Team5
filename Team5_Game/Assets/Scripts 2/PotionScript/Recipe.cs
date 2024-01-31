using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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

     List<string> Recipe1Names = new List<string>() { "phoenixFeather", "blueFlower", "redMushroom", "lizardTail", "plantRoot" };
     List<string> Recipe2Names = new List<string>() { "dragonScales", "yellowFlower", "blueMushroom", "plantRoot", "phoenixFeather" };
     List<string> Recipe3Names = new List<string>() { "lizardTail", "plantRoot", "greenMushroom", "phoenixFeather", "blueFlower" };


     static List<string> Recipe1Added = new List<string>();
     static List<string> Recipe2Added = new List<string>();
     static List<string> Recipe3Added = new List<string>(); //�巡���ؼ� ���

    static bool FirstRecipeOn = false;
    static bool SecondRecipeOn = false;
    static bool ThirdRecipeOn = false;

    private Vector2 OriginPos;//����Ƽ���� ������ġ xy�� �����ؼ� �ٿ��ֱ��ؾ���
    private RectTransform rectTransform;


    public GameObject objectToDrag;
    public GameObject magicPotPos;

    public float Dropdistance;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        OriginPos = rectTransform.position;
    }

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
            objectToDrag.transform.position = OriginPos; //�������� ���� �ִ� �ڸ��� ���ư� ///////////////////////////
        }

    }

        void CheckAndHandleRecipe(List<string> recipeNames, List<string> recipeAdded, int recipeNumber)//�����Ǵ�� ��������� �˻�
        {
            if (recipeNames.Contains(gameObject.name))
            {
                objectToDrag.transform.position = magicPotPos.transform.position;
                objectToDrag.SetActive(false);

                Debug.Log(recipeNumber+"�� ������ ��� ����!!");

                recipeAdded.Add(objectToDrag.name);



            if (Enumerable.SequenceEqual(recipeNames, recipeAdded))//������� �߸��������
            {
                Debug.Log(recipeNumber + "�� ���� �Ϻ� ����!!");

                ScoreManager.AddScore(2);//������ ������ Ȯ���� 2�� �߰�



                if (recipeNumber == 1)
                {
                    Invoke("CallClearPanelAppear", 3f);
                    ClearPanel.Instance.RedPotionAppear();       //�ϼ��� ���� ui ȣ��
                }
                else if (recipeNumber == 2)
                {
                    Invoke("CallClearPanelAppear", 3f);
                    ClearPanel.Instance.BluePotionAppear();
                }
                else if (recipeNumber == 3)
                {
                    Invoke("CallClearPanelAppear", 3f);
                    ClearPanel.Instance.GreenPotionAppear();
                }

            }
            else if (Enumerable.SequenceEqual(recipeNames, recipeAdded) == false && AreListsEqual(recipeNames, recipeAdded) == true)//������ Ʋ������ ���� �˸°� ��� �־�����
            {
                Debug.Log("������ Ʋ������ " + recipeNumber + "�� ���� ���� ����!");

                ScoreManager.AddScore(1);//���� Ʋ���� Ȯ���� 1�� �߰�

                if (recipeNumber == 1)
                {
                    Invoke("CallClearPanelAppear", 3f);
                    ClearPanel.Instance.RedPotionAppear();       //�ϼ��� ���� ui ȣ��
                }
                else if (recipeNumber == 2)
                {
                    Invoke("CallClearPanelAppear", 3f);
                    ClearPanel.Instance.BluePotionAppear();
                }
                else if (recipeNumber == 3)
                {
                    Invoke("CallClearPanelAppear", 3f);
                    ClearPanel.Instance.GreenPotionAppear();
                } 
            }



            }   
            else //�����ǿ� ���� ��Ḧ �־��� ��
            {
                Debug.Log("�� ��� �ƴ�!!");
                objectToDrag.SetActive(false);
                Invoke("CallFailPanelAppear", 3f);
            //���� ���� ���� �̴ϰ������� �Ѿ
        }
        }



   public void CallClearPanelAppear() //���� �г� ȣ��
    {
        ClearPanel.Instance.ClearPanelAppear();
    }
    
    public void CallFailPanelAppear()//���� �г� ȣ��
    {
        FailPanel.Instance.FailPanelAppear();
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

