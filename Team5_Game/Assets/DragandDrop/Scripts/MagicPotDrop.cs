using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;


public class MagicPotDrop : MonoBehaviour/*, IDropHandler*/
{

   

    public static MagicPotDrop Instance; //다른 스크립트에서 이 스크립트의 함수를 호출할 때 필요

    public bool FirstRecipeOn = false;
    public bool SecondRecipeOn = false;
    public bool ThirdRecipeOn = false;

    private void Awake() 
    {
        if(MagicPotDrop.Instance == null)//다른 스크립트에서 이 스크립트의 함수를 호출할 때 필요

        {
            MagicPotDrop.Instance = this;
        }
    }






    //public void FirstRecipe()
    //{
    //    FirstRecipeOn = true;
    //    Debug.Log("first");
    //}

    //public void SecondRecipe()
    //{
    //    SecondRecipeOn = true;
    //    Debug.Log("second");
    //}

    //public void ThirdRecipe()
    //{
    //    ThirdRecipeOn = true;
    //    Debug.Log("third");
    //}

   
}

