using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeButton : MonoBehaviour
{
   
    public void RecipeBtnPressed()
    {
        RandomRecipe.Instance.PickRandomRecipe();//��ư Ŭ���ϸ� ���� ������ �ϳ� �����ؼ� �����ִ� �Լ� ȣ��
    }
  
}
