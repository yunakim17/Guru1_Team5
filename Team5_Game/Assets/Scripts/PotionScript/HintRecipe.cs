using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintRecipe : MonoBehaviour
{

    public static HintRecipe Instance;

    public Text hintRecipe;

    public GameObject RecipePanel;

    string[] recipeArray = new string[] { " 1. �һ����� ���� \r\n 2. Ǫ�� �� \r\n 3. ���� ����  \r\n 4. �������� ����  \r\n 5. �Ѹ�", " 1. ���� ��� \r\n 2. ��� �� \r\n 3. �Ķ� ����  \r\n 4. �Ѹ�  \r\n 5. �һ����� ����", " 1. �������� ���� \r\n 2. �Ѹ� \r\n 3. �ʷ� ���� \r\n 4. �һ����� ����  \r\n 5. Ǫ�� ��" }; //����

    string hint;
    private void Awake()
    {
        if (HintRecipe.Instance == null)
        {
            HintRecipe.Instance = this;
        }
    }

    public void SaveHint(int num)
    {
        hint = recipeArray[num];
    }


    public void HintBtnPressedRecipe()
    {
        gameObject.SetActive(true);
        RecipePanel.SetActive(true);
        hintRecipe.text = hint;
        Invoke("HintRecipeDisappear", 4f);
    }

    void Start()
    {
        gameObject.SetActive(false);

        RecipePanel.SetActive(false);
    }


    void HintRecipeDisappear()
    {
        gameObject.SetActive(false);
        RecipePanel.SetActive(false);
    }
}
