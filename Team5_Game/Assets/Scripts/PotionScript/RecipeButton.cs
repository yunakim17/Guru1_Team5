using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeButton : MonoBehaviour
{
    public Button SeeRecipeBtn;

    public void RecipeBtnPressed()
    {
        RandomRecipe.Instance.PickRandomRecipe();//버튼 클릭하면 랜덤 레시피 하나 생성해서 보여주는 함수 호출

        Timer.Instance.TimerStart();


        SeeRecipeBtn.interactable = false; //레시피버튼을 한번 누르면 다시 클릭할 수 없음

        Invoke("RecipeButtonDisappear", 4f);//5초 후에 레시피버튼과 레시피 사라지게하는 함수 호출
        

    }

  

    void RecipeButtonDisappear()
    {
        // 게임 오브젝트 비활성화
        GameObject.Find("button").SetActive(false);
        GameObject.Find("Recipes").SetActive(false); //버튼과 레시피가 게임창에서 사라짐

        HintButton.Instance.gameObject.SetActive(true);
        LeftHint.Instance.gameObject.SetActive(true);//레시피 버튼이 사라진 자리에 힌트버튼 게임창에 나타나게 해야함~ setActive사용


    }



}
  

