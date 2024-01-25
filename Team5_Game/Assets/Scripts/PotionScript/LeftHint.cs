using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftHint : MonoBehaviour
{

    public static LeftHint Instance;

    private void Awake()
    {
        if (LeftHint.Instance == null)
        {
            LeftHint.Instance = this;
        }
    }



    int hintCount = 3; //�־��� ��Ʈ�� 3��

    public Text HintCountText;


    void Start()
    {
        gameObject.SetActive(false);
        HintCountText.text = "���� ��Ʈ : " + hintCount + "��"; //ó���� 3���� ���;���
    }

    
}
