using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintButton : MonoBehaviour
{
    public static HintButton Instance;

    int hintCount = 3; //�־��� ��Ʈ�� 3��

    public Button HintBtn;

    

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

        Invoke("HintBtnFalse", 0f);//�����ڸ��� ��Ʈ��ư ��ȣ�ۿ� �Ұ����ϰ� -> ��Ʈ��ư�� ����켭 ���� �� ������

        Invoke("HintBtnTrue", 4f);//��Ʈ�ð� = 4�� ������ �ٽ� ��ȣ�ۿ� �����ϰ� ����� 



        if (hintCount ==0) //��Ʈ�� �� ���� ��
        {
            Invoke("HintButtonDisappear", 4f);//5�� �Ŀ� ��Ʈ��ư�� ������ ��������ϴ� �Լ� ȣ��
        }


    }


    void HintBtnFalse()
    {
        HintBtn.interactable = false;
    }

    void HintBtnTrue()
    {
        HintBtn.interactable = true;
    }

    void HintButtonDisappear()
    {
        
        GameObject.Find("HintButton").SetActive(false);
         //��ư�� �����ǰ� ����â���� �����

    }
}
