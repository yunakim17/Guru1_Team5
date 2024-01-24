using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeButton : MonoBehaviour
{
   

    public void RecipeBtnPressed()
    {
        RandomRecipe.Instance.PickRandomRecipe();//��ư Ŭ���ϸ� ���� ������ �ϳ� �����ؼ� �����ִ� �Լ� ȣ��

        Timer.Instance.TimerStart();

        Invoke("RecipeButtonDisappear", 4f);//5�� �Ŀ� �����ǹ�ư�� ������ ��������ϴ� �Լ� ȣ��
        

    }

  

    void RecipeButtonDisappear()
    {
        // ���� ������Ʈ ��Ȱ��ȭ
        GameObject.Find("button").SetActive(false);
        GameObject.Find("Recipes").SetActive(false); //��ư�� �����ǰ� ����â���� �����

        HintButton.Instance.gameObject.SetActive(true);
        LeftHint.Instance.gameObject.SetActive(true);//������ ��ư�� ����� �ڸ��� ��Ʈ��ư ����â�� ��Ÿ���� �ؾ���~ setActive���


    }



}
  

