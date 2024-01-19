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
        string[] recipeArray = new string[] { "ºÒ»çÁ¶ÀÇ ±êÅÐ \r\n »¡°£ ¹ö¼¸ \r\n ²É", "¿ëÀÇ ºñ´Ã \r\n ÆÄ¶õ ¹ö¼¸ \r\n ²É", "¿ëÀÇ ºñ´Ã \r\n ÃÊ·Ï ¹ö¼¸ \r\n »Ñ¸®" };

        string randomRecipes = recipeArray[Random.Range(0, recipeArray.Length)];

        recipe.text = randomRecipes;

    }

    
}
