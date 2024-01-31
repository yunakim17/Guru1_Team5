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
     static List<string> Recipe3Added = new List<string>(); //드래그해서 담기

    static bool FirstRecipeOn = false;
    static bool SecondRecipeOn = false;
    static bool ThirdRecipeOn = false;

    private Vector2 OriginPos;//유니티에서 원래위치 xy값 복붙해서 붙여넣기해야함
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
        objectToDrag.transform.position = Input.mousePosition;//드래그 모션

    }

    public void DropObject()//오브젝트를 드랍하면 호출되는 함수
    {
        float distance = Vector3.Distance(objectToDrag.transform.position, magicPotPos.transform.position);//스냅기능

        //Debug.Log("드랍한 오브젝트 : " + gameObject.name); //확인용

       

        if (distance < Dropdistance) 
        {
            if (FirstRecipeOn)//첫번째 레시피가 나왔을 때
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
            Debug.Log("너무 멀리 드랍했어!!");
            objectToDrag.transform.position = OriginPos; //아이템이 원래 있던 자리로 돌아감 ///////////////////////////
        }

    }

        void CheckAndHandleRecipe(List<string> recipeNames, List<string> recipeAdded, int recipeNumber)//레시피대로 만들었는지 검사
        {
            if (recipeNames.Contains(gameObject.name))
            {
                objectToDrag.transform.position = magicPotPos.transform.position;
                objectToDrag.SetActive(false);

                Debug.Log(recipeNumber+"번 레시피 재료 맞음!!");

                recipeAdded.Add(objectToDrag.name);



            if (Enumerable.SequenceEqual(recipeNames, recipeAdded))//순서대로 잘만들었을때
            {
                Debug.Log(recipeNumber + "번 물약 완벽 제조!!");

                ScoreManager.AddScore(2);//순서도 맞으면 확인증 2개 추가



                if (recipeNumber == 1)
                {
                    Invoke("CallClearPanelAppear", 3f);
                    ClearPanel.Instance.RedPotionAppear();       //완성된 물약 ui 호출
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
            else if (Enumerable.SequenceEqual(recipeNames, recipeAdded) == false && AreListsEqual(recipeNames, recipeAdded) == true)//순서는 틀리지만 재료는 알맞게 모두 넣었을때
            {
                Debug.Log("순서는 틀리지만 " + recipeNumber + "번 물약 제조 성공!");

                ScoreManager.AddScore(1);//순서 틀리면 확인증 1개 추가

                if (recipeNumber == 1)
                {
                    Invoke("CallClearPanelAppear", 3f);
                    ClearPanel.Instance.RedPotionAppear();       //완성된 물약 ui 호출
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
            else //레시피에 없는 재료를 넣었을 때
            {
                Debug.Log("이 재료 아님!!");
                objectToDrag.SetActive(false);
                Invoke("CallFailPanelAppear", 3f);
            //점수 없이 다음 미니게임으로 넘어감
        }
        }



   public void CallClearPanelAppear() //성공 패널 호출
    {
        ClearPanel.Instance.ClearPanelAppear();
    }
    
    public void CallFailPanelAppear()//실패 패널 호출
    {
        FailPanel.Instance.FailPanelAppear();
    }

     public bool AreListsEqual(List<string> list1, List<string> list2)
    {
    // 두 리스트의 요소를 정렬하여 순서를 무시하고 비교
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

