using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintButton : MonoBehaviour
{
    public static HintButton Instance;

    int hintCount = 3; //�־��� ��Ʈ�� 3��

    

    private void Awake()
    {
        if (HintButton.Instance == null)
        {
            HintButton.Instance = this;
        }
    }
    void Start()
    {
        gameObject.SetActive(false);//�����Ҷ��� �Ⱥ��̰�
       
    }

    public void HintBtnPressed()
    {
       
        HintRecipe.Instance.HintBtnPressedRecipe();//��ư Ŭ���ϸ� ���� ������ �ϳ� �����ؼ� �����ִ� �Լ� ȣ��
        
        hintCount--;//��Ʈ ��ư Ŭ���� ������ ��Ʈ�� �ϳ��� �پ���

        LeftHint.Instance.HintCountText.text = "���� ��Ʈ : " + hintCount + "��";

        Timer.Instance.TimerStart();//Ÿ�̸� ȣ��

        if (hintCount ==0) //��Ʈ�� �� ���� ��
        {
            Invoke("HintButtonDisappear", 5f);//5�� �Ŀ� ��Ʈ��ư�� ������ ��������ϴ� �Լ� ȣ��
        }




    }

    void HintButtonDisappear()
    {
        
        GameObject.Find("HintButton").SetActive(false);
         //��ư�� �����ǰ� ����â���� �����

    }
}
