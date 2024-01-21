using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class Recipe : MonoBehaviour
{
    public static Recipe Instance;//다른 스크립트에서 이 스크립트의 함수를 호출할 때 필요

    private void Awake()
    {
        if (Recipe.Instance == null)//다른 스크립트에서 이 스크립트의 함수를 호출할 때 필요

        {
            Recipe.Instance = this;
        }
    }


    public List<GameObject> Recipe1Objects = new List<GameObject>(); //각 레시피 재료에 해당하는 게임 오브젝트들을 담기 위한 리스트
    public List<GameObject> Recipe2Objects = new List<GameObject>();
    public List<GameObject> Recipe3Objects = new List<GameObject>();

    public bool FirstRecipeOn = false;
    public bool SecondRecipeOn = false;
    public bool ThirdRecipeOn = false;


    public GameObject objectToDrag;
    public GameObject objectDragToPos;

    public float Dropdistance;


    public void DragObject()
    {
        objectToDrag.transform.position = Input.mousePosition;// 물체가 커서를 따라가게함
    }

    public void DropObject()
    {
        float Distance = Vector3.Distance(objectToDrag.transform.position, objectDragToPos.transform.position);

        if (FirstRecipeOn == true && Recipe1Objects.Contains(gameObject))
        {
            objectToDrag.transform.position = objectDragToPos.transform.position;
            Debug.Log("1번 레시피 재료 맞음");

        }
        else if (SecondRecipeOn == true && Recipe2Objects.Contains(gameObject))
        {
            objectToDrag.transform.position = objectDragToPos.transform.position;
            Debug.Log("2번 레시피 재료 맞음");
        }
       
        else if (ThirdRecipeOn == true && Recipe3Objects.Contains(gameObject))
        {
            objectToDrag.transform.position = objectDragToPos.transform.position;
            Debug.Log("3번 레시피 재료 맞음");
        }
        else
        {
            Debug.Log("이 재료 아님!!");

        }

    }

    //&& Distance < Dropdistance
    //EventSystem.current.currentSelectedGameObject

    public void FirstRecipe() //첫번째 레시피가 호출되면
    {
        FirstRecipeOn = true;
        Debug.Log("first");
    }

    public void SecondRecipe() //첫번째 레시피가 호출되면
    {
        SecondRecipeOn = true;
        Debug.Log("second");
    }
    
    public void ThirdRecipe() //첫번째 레시피가 호출되면
    {
        ThirdRecipeOn = true;
        Debug.Log("third");
    }
}
