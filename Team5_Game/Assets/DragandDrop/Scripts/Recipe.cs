using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Recipe : MonoBehaviour //, IPointerClickHandler
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
     static List<string> Recipe3Added = new List<string>(); //드래그해서 담기

    static bool FirstRecipeOn = false;
    static bool SecondRecipeOn = false;
    static bool ThirdRecipeOn = false;

    public Vector2 OriginPos;//유니티에서 원래위치 xy값 복붙해서 붙여넣기해야함
    

    public GameObject objectToDrag;
    public GameObject magicPotPos;

    public float Dropdistance;

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
            objectToDrag.transform.position = OriginPos; //아이템이 원래 있던 자리로 돌아감
        }

    }

        void CheckAndHandleRecipe(List<string> recipeNames, List<string> recipeAdded, int recipeNumber)
        {
            if (recipeNames.Contains(gameObject.name))
            {
                objectToDrag.transform.position = magicPotPos.transform.position;
                objectToDrag.SetActive(false);

                Debug.Log(recipeNumber+"번 레시피 재료 맞음!!");

                recipeAdded.Add(objectToDrag.name);

                

                if(Enumerable.SequenceEqual(recipeNames, recipeAdded))//순서대로 잘만들었을때
                {
                Debug.Log(recipeNumber+ "번 물약 완벽 제조!!");

                //완성된 물약 ui 호출

                }
                else if(Enumerable.SequenceEqual(recipeNames, recipeAdded) == false && AreListsEqual(recipeNames, recipeAdded) == true)//순서는 틀리지만 재료를 알맞게 넣었을때
                {
                Debug.Log("순서는 틀리지만 " + recipeNumber +"번 물약 제조 성공!");

                //완성된 물약 ui 호출
                }



            }   
            else //레시피에 없는 재료를 넣었을 때
            {
                Debug.Log("이 재료 아님!!");
                objectToDrag.SetActive(false);
            //펑하면서 뭔가 잘못됐다는 효과.. 점수 없이 다음 미니게임으로 넘어감
        }
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


        //public void OnPointerClick(PointerEventData eventData)
        //{
        //    // Output the name of the clicked object
        //    Debug.Log("Clicked object: " + gameObject.name); //확인용

        //}
    }

