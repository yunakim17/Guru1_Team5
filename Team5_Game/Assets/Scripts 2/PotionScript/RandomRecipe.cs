using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RandomRecipe : MonoBehaviour
{

    public Text recipe;

    public static RandomRecipe Instance;//다른 스크립트에서 이 스크립트의 함수를 호출할 때 필요


   
 

    private void Awake()
    {
        if (RandomRecipe.Instance == null)//다른 스크립트에서 이 스크립트의 함수를 호출할 때 필요

        {
            RandomRecipe.Instance = this;
        }
    }


   

    public void PickRandomRecipe()
    {
        string[] recipeArray = new string[] { " 1. 불사조의 깃털 \r\n 2. 푸른 꽃 \r\n 3. 빨간 버섯  \r\n 4. 도마뱀의 꼬리  \r\n 5. 뿌리", " 1. 용의 비늘 \r\n 2. 노란 꽃 \r\n 3. 파란 버섯  \r\n 4. 뿌리  \r\n 5. 불사조의 깃털", " 1. 도마뱀의 꼬리 \r\n 2. 뿌리 \r\n 3. 초록 버섯 \r\n 4. 불사조의 깃털  \r\n 5. 푸른 꽃" }; //수정

        string randomRecipes = recipeArray[UnityEngine.Random.Range(0, recipeArray.Length)]; //문자열 randomRecipes에 recipeArray중 하나를 랜덤으로 뽑음

        ArraySegment<string> firstRecipe = new ArraySegment<string>(recipeArray, 0, 1); //첫번째 레시피를 따로 firstRecipe에 저장
        ArraySegment<string> secondRecipe = new ArraySegment<string>(recipeArray, 1, 1); //두번째 레시피를 따로 secondRecipe에 저장
        ArraySegment<string> thirdRecipe = new ArraySegment<string>(recipeArray, 2, 1); //세번째 레시피를 따로 thirdRecipe에 저장

        recipe.text = randomRecipes; // 3개 레시피 중 하나를 랜덤으로 뽑아 유니티 텍스트창으로 출력(조작)

        if (randomRecipes == firstRecipe[0]) // 만약 뽑힌 레시피가 첫번째 레시피라면
        {
            Recipe.FirstRecipe(true);
            HintRecipe.Instance.SaveHint(0); //힌트버튼을 눌럿을 때 텍스트창에도 1번 레시피가 뜨게해야함
        }
        else if(randomRecipes == secondRecipe[0]) // 만약 뽑힌 레시피가 두번째 레시피라면
        {
            Recipe.SecondRecipe(true);
            HintRecipe.Instance.SaveHint(1);
        }
        else if (randomRecipes == thirdRecipe[0]) // 만약 뽑힌 레시피가 세번째 레시피라면
        {
            Recipe.ThirdRecipe(true);
            HintRecipe.Instance.SaveHint(2);
        }

    }




}
