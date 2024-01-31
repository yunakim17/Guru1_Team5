using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeButton : MonoBehaviour
{
    public Button SeeRecipeBtn;

    public GameObject RecipePanel;

    public void RecipeBtnPressed()
    {
        RandomRecipe.Instance.PickRandomRecipe();//��ư Ŭ���ϸ� ���� ������ �ϳ� �����ؼ� �����ִ� �Լ� ȣ��

        RecipePanel.SetActive(true);

        Timer2.Instance.TimerStart();


        SeeRecipeBtn.interactable = false; //�����ǹ�ư�� �ѹ� ������ �ٽ� Ŭ���� �� ����

        Invoke("RecipeButtonDisappear", 4f);//5�� �Ŀ� �����ǹ�ư�� ������ ��������ϴ� �Լ� ȣ��
        

    }

  

    void RecipeButtonDisappear()
    {
        // ���� ������Ʈ ��Ȱ��ȭ
        GameObject.Find("button").SetActive(false);
        GameObject.Find("Recipes").SetActive(false);
        RecipePanel.SetActive(false);//��ư�� �����ǰ� ����â���� �����

        HintButton.Instance.gameObject.SetActive(true);
        LeftHint.Instance.gameObject.SetActive(true);//������ ��ư�� ����� �ڸ��� ��Ʈ��ư ����â�� ��Ÿ���� �ؾ���~ setActive���


    }



}
  

