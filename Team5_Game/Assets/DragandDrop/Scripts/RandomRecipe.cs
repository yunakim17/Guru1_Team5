using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RandomRecipe : MonoBehaviour
{
    public Text recipe;
  

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            PickRandomFromList();
        }
    }



    private void PickRandomFromList()
    {
        string[] recipeArray = new string[] { "�һ����� ���� \r\n ���� ���� \r\n ��", "���� ��� \r\n �Ķ� ���� \r\n ��", "���� ��� \r\n �ʷ� ���� \r\n �Ѹ�" };

        string randomRecipes = recipeArray[Random.Range(0, recipeArray.Length)];

        recipe.text = randomRecipes;

    }

    
}
