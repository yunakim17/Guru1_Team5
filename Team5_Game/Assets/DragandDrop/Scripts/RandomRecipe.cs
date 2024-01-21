using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RandomRecipe : MonoBehaviour
{

    public Text recipe;

    public static RandomRecipe Instance;//�ٸ� ��ũ��Ʈ���� �� ��ũ��Ʈ�� �Լ��� ȣ���� �� �ʿ�

 

    private void Awake()
    {
        if (RandomRecipe.Instance == null)//�ٸ� ��ũ��Ʈ���� �� ��ũ��Ʈ�� �Լ��� ȣ���� �� �ʿ�

        {
            RandomRecipe.Instance = this;
        }
    }


   

    public void PickRandomRecipe()
    {
        string[] recipeArray = new string[] { "�һ����� ���� \r\n ���� ���� \r\n ��", "���� ��� \r\n �Ķ� ���� \r\n ��", "���� ��� \r\n �ʷ� ���� \r\n �Ѹ�" };

        string randomRecipes = recipeArray[UnityEngine.Random.Range(0, recipeArray.Length)]; //���ڿ� randomRecipes�� recipeArray�� �ϳ��� �������� ����

        ArraySegment<string> firstRecipe = new ArraySegment<string>(recipeArray, 0, 1); //ù��° �����Ǹ� ���� firstRecipe�� ����
        ArraySegment<string> secondRecipe = new ArraySegment<string>(recipeArray, 1, 1); //�ι�° �����Ǹ� ���� secondRecipe�� ����
        ArraySegment<string> thirdRecipe = new ArraySegment<string>(recipeArray, 2, 1); //����° �����Ǹ� ���� thirdRecipe�� ����

        recipe.text = randomRecipes; // 3�� ������ �� �ϳ��� �������� �̾� ����Ƽ �ؽ�Ʈâ���� ���(����)

        if (randomRecipes == firstRecipe[0]) // ���� ���� �����ǰ� ù��° �����Ƕ��
        {
            Recipe.Instance.FirstRecipe(); //
        }
        else if(randomRecipes == secondRecipe[0]) // ���� ���� �����ǰ� �ι�° �����Ƕ��
        {
            Recipe.Instance.SecondRecipe(); //
        }
        else if (randomRecipes == thirdRecipe[0]) // ���� ���� �����ǰ� ����° �����Ƕ��
        {
            Recipe.Instance.ThirdRecipe(); // 
        }

    }




}
