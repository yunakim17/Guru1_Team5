using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeButton : MonoBehaviour
{
   
    public void RecipeBtnPressed()
    {
        RandomRecipe.Instance.PickRandomRecipe();//버튼 클릭하면 랜덤 레시피 하나 생성해서 보여주는 함수 호출
    }
  
}
